using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Product;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.Product;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Concreate
{
    public class ProductService : IProductService
    {
        private IProductManager productManager;
        private IStoreManager storeManager;
        private IMapper mapper;
        public ProductService(IProductManager productManager, 
                              IStoreManager storeManager,
                              IMapper mapper)
        {
            this.productManager = productManager;
            this.storeManager = storeManager;
            this.mapper = mapper;
        }

        public IResult set(ProductDTO product, Guid userid)
        {
            try
            {
                List<VyStoreTable> vyStores = storeManager.
                    getByFilterOrAll(x=>x.userId.Equals(userid)).ToList();
                if (vyStores.Count == 0)
                    return new ErrorResult("0", ExceptionMessage.
                        StoreNotFound[(int)language.Turkish]);
                bool isAdded = productManager.add(new VyProductTable
                {
                    StoreId = vyStores[0].Id,
                    CreateDate = DateTime.UtcNow,
                    Description = product.Description,
                    IsActive = true,
                    Name = product.Name,
                    Price = product.Price,
                    UpdateTime = DateTime.UtcNow
                });
                return isAdded ? new SuccesResult() :
                    new 
                    ErrorResult("0", ExceptionMessage.productIsNotAdded[(int)language.Turkish]);
            }
            catch (Exception e) 
            {

                return new ErrorResult("0",
                    ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public async Task<IResult> update(ProductDTO product, Guid productid, Guid userid)
        {
            try
            {
                Guid? storeId = null;
                VyProductTable? vyProduct = null;
                Task task = Task.Run(() =>
                {
                    List<VyStoreTable> vyStores =
                    storeManager.getByFilterOrAll(x => x.userId.Equals(userid)).ToList();
                    storeId = vyStores.Count > 0 ? vyStores[0].Id : null;
                });
                Task task1 = Task.Run(() =>
                {
                    List<VyProductTable> productTables =
                    productManager.getByFilterOrAll(x => x.Id.Equals(productid)).ToList();

                    vyProduct = productTables.Count > 0 ? productTables[0] : null;
                    
                });

                 Task.WaitAll(task,task1);


                if (storeId == null || vyProduct == null || !vyProduct.StoreId.Equals(storeId))
                    return new ErrorResult("0", 
                        ExceptionMessage.productIsNotFound[(int)language.Turkish]);
                vyProduct.UpdateTime = DateTime.UtcNow;
                vyProduct.Name = product.Name;
                vyProduct.Price = product.Price;
                vyProduct.Description = product.Description;
                bool isUpdated = productManager.update(vyProduct);

                return isUpdated?new SuccesResult():
                    new ErrorResult("0", ExceptionMessage.productIsNotAdded[(int)language.Turkish]);

                 
            }
            catch (Exception e)
            {

                return new
                    ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public IDataResult<List<ProductGetDTO>> get(Guid userid)
        {
            try
            {
                List<VyStoreTable> vyStores = storeManager.
                getByFilterOrAll(x => x.userId == userid).ToList();

                if(vyStores.Count == 0)
                    return new ErrorDataResult<List<ProductGetDTO>>(new List<ProductGetDTO>(),
                        "0", ExceptionMessage.StoreNotFound[(int)language.Turkish]);

                List<VyProductTable> vyProducts = productManager.
                    getByFilterOrAll(x => x.StoreId.Equals(vyStores[0].Id)).ToList();

                if (vyProducts.Count == 0)
                    return new 
                        ErrorDataResult<List<ProductGetDTO>>(new List<ProductGetDTO>(),
                        "0", ExceptionMessage.productIsNotFound[(int)language.Turkish]);

                return new SuccessDataResult<List<ProductGetDTO>>
                    (mapper.Map<List<VyProductTable>, List<ProductGetDTO>>
                    (vyProducts));
                    


            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<ProductGetDTO>>
                    (new List<ProductGetDTO>(),"0", 
                    ExceptionMessage.
                    systemException[(int)language.Turkish]);
            }
        }
    }
}
