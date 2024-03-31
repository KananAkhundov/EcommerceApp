using Core.Results.Abstract;
using Entities.DataTransferObjects;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(ProductCreateOrUpdateDto dto);
        IResult AddRange(List<Product> models);
        IResult Update(ProductCreateOrUpdateDto dto);
        IResult Delete(int id);
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAll(int pageNumber, int pageSize);
    }
}
