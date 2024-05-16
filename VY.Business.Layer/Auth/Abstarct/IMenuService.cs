using VY.Business.Layer.Auth.DTO.Menu;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IMenuService
    {
        IDataResult<MenuGetDTO> setMenu(MenuDTO  menu, Guid storeid);
        IDataResult<MenuGetDTO> updateMenu(MenuDTO menu, Guid menuid,Guid storeid);
        IDataResult<List<MenuGetDTO>> get(Guid storeid);
        
    }
}
