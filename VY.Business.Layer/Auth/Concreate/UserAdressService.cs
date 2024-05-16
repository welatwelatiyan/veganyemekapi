using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.Business.Layer.Auth.Concreate
{
    public class UserAdressService : IUserAdressService
    {
        private IUserAdressManager userAdressManager;
        private IMapper mapper;
        private IUserStoreAdressService userStoreAdressService;
        private IDistanceService distanceService;
        public UserAdressService(IUserAdressManager userAdressManager,
                                  IMapper mapper ,
                                  IDistanceService distanceService,
                                  IUserStoreAdressService userStoreAdressService)
        {
            this.userAdressManager = userAdressManager;
            this.mapper = mapper;
            this.distanceService = distanceService;
            this.userStoreAdressService = userStoreAdressService;
        }
        public IDataResult<List<UserAdressGetDTO>> getUserAdresses(Guid userId)
        {
            try
            {
                List<VyUserAdressTable> userAdress= userAdressManager.
                    getByFilterOrAll(x=>x.UserId == userId).ToList();

                if (userAdress.Count == 0)
                    return new ErrorDataResult<List<UserAdressGetDTO>>
                        (new List<UserAdressGetDTO>(), "0",
                        ExceptionMessage.AddresNotFound[(int)language.Turkish]);

                return new SuccessDataResult<List<UserAdressGetDTO>>
                    (mapper.Map<List<VyUserAdressTable>,
                    List<UserAdressGetDTO>>(userAdress), "1", "");
                    

            }
            catch (Exception e)
            {
                return
                    new ErrorDataResult<List<UserAdressGetDTO>>
                    (new List<UserAdressGetDTO>(), "0",
                    ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public async Task<IResult> setAddress(UserAdressDTO userAdress, Guid userId)
        {

            try
            {
                VyUserAdressTable vyUser = new VyUserAdressTable
                {
                    UserId = userId,
                    CreateDate = DateTime.UtcNow,
                    Description = userAdress.Description,
                    IsActive = true,
                    latitude = userAdress.latitude,
                    longitude = userAdress.longitude,
                    Name = userAdress.Name,
                    UpdateTime = DateTime.UtcNow,
                    TelNumber = userAdress.TelNumber,
                    Il = userAdress.Il,
                };
                bool isAddetAdress = userAdressManager.add(vyUser);
                if(!isAddetAdress)
                    return new ErrorResult
                        ("0", ExceptionMessage.AddresNotAdded[(int)language.Turkish]); 
                
                 userStoreAdressService.setUserAdress(vyUser);

                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ErrorResult
                     ("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public IResult updateAddress(UserAddresUpdateDTO userAdress, Guid addresId, Guid userId)
        {
            try
            {
                List<VyUserAdressTable> userAdressls = userAdressManager.
                    getByFilterOrAll(x => x.UserId == userId && x.Id == addresId).ToList();
                if (userAdressls.Count==0)
                    return 
                        new ErrorResult("0", ExceptionMessage.AddresNotFound[(int)language.Turkish]);

                userAdressls[0].Description = userAdress.Description;
                userAdressls[0].UpdateTime = DateTime.UtcNow;
                userAdressls[0].TelNumber = userAdress.TelNumber;
                userAdressls[0].Name = userAdress.Name;
                userAdressls[0].Il=userAdress.Il;


                bool isUpdateAdress = userAdressManager.update(userAdressls[0]);
                return isUpdateAdress ? new SuccesResult() :
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
