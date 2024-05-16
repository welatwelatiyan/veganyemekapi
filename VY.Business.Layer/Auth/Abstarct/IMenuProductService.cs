using VY.Business.Layer.Auth.DTO.MenuProduct;
using VY.Core.Layer.Utilities.Results.DataResult;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IMenuProductService
    {
        IDataResult<MenuProductGetDTO> set(MenuProductDTO menuproduct, Guid storeid);
        IDataResult<MenuProductGetDTO> update(MenuProductDTO menuproduct, Guid id, Guid storeid);
        IDataResult<List<MenuProductGetDTO>> get(Guid storeid);
    }
}
