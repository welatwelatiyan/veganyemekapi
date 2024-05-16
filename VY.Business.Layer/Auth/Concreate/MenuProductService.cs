using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.MenuProduct;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.Product;

namespace VY.Business.Layer.Auth.Concreate
{
    public class MenuProductService : IMenuProductService
    {
        private IMenuProductManager menuProductManager;
        private IMapper mapper;

        public MenuProductService(IMenuProductManager menuProductManager,
                                  IMapper mapper)
        {
            this.menuProductManager = menuProductManager;
            this.mapper = mapper;
            
        }

        public IDataResult<List<MenuProductGetDTO>> get(Guid storeid)
        {
            try
            {
                List<VyMenuProductTable> vyMenuProducts = menuProductManager
                .getByFilterOrAll(x => x.StoreId == storeid).ToList();

                return vyMenuProducts.Count == 0 ?
                    new ErrorDataResult<List<MenuProductGetDTO>>
                    (new List<MenuProductGetDTO>(), "0",
                    ExceptionMessage.dataIsNotFounded[(int)language.Turkish]) : 
                    new SuccessDataResult<List<MenuProductGetDTO>>(
                        mapper.Map<List<VyMenuProductTable>,
                                   List<MenuProductGetDTO>>(vyMenuProducts));
            }
            catch (Exception e)
            {
                return new 
                    ErrorDataResult<List<MenuProductGetDTO>>
                    (new List<MenuProductGetDTO>(), "0",
                    ExceptionMessage.systemException[(int)language.Turkish]);
            }             
        }

        public IDataResult<MenuProductGetDTO> set(MenuProductDTO menuproduct, Guid storeid)
        {

            try
            {
                VyMenuProductTable vyMenuProduct = new VyMenuProductTable
                {
                    CreateDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow,
                    StoreId = storeid,
                    SortingNumber = menuproduct.SortingNumber,
                    ExternalPrice = menuproduct.ExternalPrice,
                    MenuId = menuproduct.MenuId,
                    ProductId = menuproduct.ProductId,
                    MenuKategoriId = menuproduct.MenuKategoriId
                };
                bool isadded = menuProductManager.add(vyMenuProduct);
                return isadded ? new SuccessDataResult<MenuProductGetDTO>
                    (mapper.Map<VyMenuProductTable, MenuProductGetDTO>(vyMenuProduct)) :
                    new ErrorDataResult<MenuProductGetDTO>(new MenuProductGetDTO(), "0",
                        ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);
            }
            catch (Exception e)
            {

                return new
                     ErrorDataResult<MenuProductGetDTO>(new MenuProductGetDTO(), "0",
                     ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);
            }
        }

        public IDataResult<MenuProductGetDTO> update(MenuProductDTO menuproduct, Guid id, Guid storeid)
        {
            try
            {
                List<VyMenuProductTable> vyMenuProducts = menuProductManager
                .getByFilterOrAll(x => x.StoreId == storeid && x.Id == id).ToList();
                if (vyMenuProducts.Count == 0)
                    return new
                        ErrorDataResult<MenuProductGetDTO>
                       (new MenuProductGetDTO(), "0",
                       ExceptionMessage.dataIsNotFounded[(int)language.Turkish]);
                vyMenuProducts[0].MenuId = menuproduct.MenuId;
                vyMenuProducts[0].MenuKategoriId = menuproduct.MenuKategoriId;
                vyMenuProducts[0].ProductId = menuproduct.ProductId;
                vyMenuProducts[0].ExternalPrice = menuproduct.ExternalPrice;
                vyMenuProducts[0].SortingNumber = menuproduct.SortingNumber;
                vyMenuProducts[0].UpdateTime = DateTime.UtcNow;

                bool isupteded = menuProductManager.update(vyMenuProducts[0]);

                return isupteded ? new SuccessDataResult<MenuProductGetDTO>
                        (mapper.Map<VyMenuProductTable, MenuProductGetDTO>(vyMenuProducts[0])) :
                        new ErrorDataResult<MenuProductGetDTO>(new MenuProductGetDTO(), "0",
                            ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);
            }
            catch (Exception e)
            {

                return new
                    ErrorDataResult<MenuProductGetDTO>(new MenuProductGetDTO(), "0",
                    ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);            
            }
        }
    }
}
