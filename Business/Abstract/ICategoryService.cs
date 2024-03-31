using Core.Results.Abstract;
using Entities.DataTransferObjects;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(CategoryCreateOrUpdateDto dto);
        IResult AddRange(List<Category> models);
        IResult Update(CategoryCreateOrUpdateDto dto);
        IResult Delete(int id);
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetAll(int pageNumber, int pageSize);
    }
}
