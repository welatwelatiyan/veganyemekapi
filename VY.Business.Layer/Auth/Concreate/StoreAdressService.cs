using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Store;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.AddressTables;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Concreate
{
    public class StoreAdressService : IStoreAdressService
    {
        private IStoreAdressManager storeAdressManager;
        private IStoreManager storeManager;
        private IMapper mapper;

        public StoreAdressService(IStoreAdressManager storeAdressManager, 
                                  IStoreManager storeManager,
                                  IMapper mapper)
        {
            this.storeAdressManager = storeAdressManager;
            this.storeManager = storeManager;
            this.mapper = mapper;

        }
        public IDataResult<StoreAdressDTO> get(Guid userid)
        {
            try
            {
                List<VyStoreAdressTable> adressls = 
                    storeAdressManager.
                    getByFilterOrAll(x=>x.UserId == userid).ToList();
                return adressls.Count > 0 ?
                    new SuccessDataResult<StoreAdressDTO>(mapper.Map<StoreAdressDTO>(adressls[0])):
                    new ErrorDataResult<StoreAdressDTO>(
                            new StoreAdressDTO(), "0",
                            ExceptionMessage.AddresNotFound[(int)language.Turkish]);
            }
            catch (Exception e)
            {

                return
                    new ErrorDataResult<StoreAdressDTO>(
                             new StoreAdressDTO(), "0",
                             ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public IResult set(StoreAdressDTO adress, Guid userid)
        {
            try
            {
                List<VyStoreAdressTable> adressls =
                    storeAdressManager.
                    getByFilterOrAll(x => x.UserId == userid).ToList();
                if (adressls.Count > 0)
                    return new ErrorResult("0", ExceptionMessage.StoreAdressDublicate[(int)language.Turkish]);

                List<VyStoreTable> vyStores = storeManager.getByFilterOrAll(x => x.userId == userid).ToList();

                if (vyStores.Count == 0)
                    return new ErrorResult("0", ExceptionMessage.StoreNotFound[(int)language.Turkish]);

                bool isAdressAdded = storeAdressManager.
                    add(new VyStoreAdressTable
                    {
                        CreateDate = DateTime.UtcNow,
                        UpdateTime = DateTime.UtcNow,
                        UserId = userid,
                        Description = adress.Description,
                        Il = adress.Il,
                        IsActive = true,
                        latitude = adress.latitude,
                        longitude = adress.longitude,
                        MaxOrderDistance = adress.MaxOrderDistance,
                        Name = adress.Name,
                        TelNumber = adress.TelNumber,
                        StoreId = vyStores[0].Id
                    });

                return isAdressAdded?
                    new  SuccesResult():
                    new ErrorResult("0", ExceptionMessage.AddresNotAdded[(int)language.Turkish]);
            }
            catch (Exception e)
            {
                return
                    new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }

        }

        public IResult update(StoreAdressDTO adress, Guid userid)
        {
            try
            {
                List<VyStoreAdressTable> adressls =
                    storeAdressManager.
                    getByFilterOrAll(x => x.UserId == userid).ToList();
                if (adressls.Count == 0)
                    return new ErrorResult("0", ExceptionMessage.AddresNotFound[(int)language.Turkish]);



                adressls[0].Description = adress.Description;
                adressls[0].UpdateTime = DateTime.UtcNow;
                adressls[0].MaxOrderDistance = adress.MaxOrderDistance;
                adressls[0].longitude = adress.longitude;
                adressls[0].latitude = adress.latitude;
                adressls[0].TelNumber = adress.TelNumber;
                adressls[0].Il = adress.Il;
                adressls[0].Name = adress.Name;

                bool isAdressUpdate = storeAdressManager.update(adressls[0]);

                return isAdressUpdate  ?
                    new SuccesResult() :
                    new ErrorResult("0", ExceptionMessage.AddresNotAdded[(int)language.Turkish]);
            }
            catch (Exception e)
            {
                return
                    new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }
    }
}
