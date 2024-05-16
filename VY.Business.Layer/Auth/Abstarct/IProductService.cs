using VY.Business.Layer.Auth.DTO.Product;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IProductService
    {
        IResult set(ProductDTO product,Guid userid);
        Task<IResult> update(ProductDTO product, Guid productid ,Guid userid);
        IDataResult<List<ProductGetDTO>> get(Guid userid);
    }
}
