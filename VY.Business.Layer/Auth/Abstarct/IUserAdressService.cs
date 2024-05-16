using VY.Business.Layer.Auth.DTO;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IUserAdressService
    {
        Task<IResult> setAddress(UserAdressDTO userAdress, Guid userId);
        IResult updateAddress(UserAddresUpdateDTO userAdress, Guid addresId, Guid userId);
        IDataResult<List<UserAdressGetDTO>> getUserAdresses(Guid userId);
        //IDataResult<UserAdressGetDTO> getUserAdressesById(Guid adressId, Guid userId);
    }
}
