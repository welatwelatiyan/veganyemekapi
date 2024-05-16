using System.Reflection.Metadata.Ecma335;
using VY.Business.Layer.Auth.Abstarct;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.Business.Layer.Auth.Concreate
{
    public class UserStoreAdressService: IUserStoreAdressService
    {
        private IDistanceService distanceService;
        private IStoreAdressManager storeAdressManager;
        private IUserStoreAdressManager userStoreAdressManager;

        public UserStoreAdressService(IDistanceService distanceService,
                                      IUserAdressManager userAdressManager,
                                      IStoreAdressManager storeAdressManager,
                                      IUserStoreAdressManager userStoreAdressManager)
        {
            this.distanceService = distanceService;
            this.storeAdressManager = storeAdressManager;
            this.userStoreAdressManager = userStoreAdressManager;
        }

        public async Task<IResult> setStoreAdress(VyStoreAdressTable adressTable)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> setUserAdress(VyUserAdressTable adressTable)
        {
            try
            {
                List<VyStoreAdressTable> vyStoreAdressesLs =
                                     storeAdressManager.
                                     getByFilterOrAll().
                                     ToList();
                if(vyStoreAdressesLs.Count==0)
                    return new ErrorResult("0", ExceptionMessage.
                            StoreAdressNotFoundForUser[(int)language.Turkish]);
                IDataResult<List<VyUserStoreAdressTable>> userstoreres =
                    await distanceService.DistanceCalculate(adressTable, vyStoreAdressesLs);
                if(!userstoreres.isSuccess)
                    return new ErrorResult("0", ExceptionMessage.
                        StoreAdressNotFoundForUser[(int)language.Turkish]);
                bool sonuc = await userStoreAdressManager.addRange(userstoreres.data);

                return sonuc ? new SuccesResult() : 
                    new ErrorResult("0", 
                    ExceptionMessage.
                    userStoreAdressNotSaved[(int)language.Turkish]);



            }
            catch (Exception e)
            {
                return new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }


        }
    }
}
