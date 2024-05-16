using VY.Business.Layer.Auth.DTO.MenuKategori;
using VY.Core.Layer.Utilities.Results.DataResult;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IMenuKategoriService
    {
        IDataResult<List<MenuKategoriGetDTO>> get(Guid storeid);
        IDataResult<MenuKategoriGetDTO> set(MenuKategoriDTO menuKategori, Guid storeid);
        IDataResult<MenuKategoriGetDTO> update(MenuKategoriDTO menuKategori,Guid kategoriid, Guid storeid);
    }
}
