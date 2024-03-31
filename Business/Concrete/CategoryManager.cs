using Business.Abstract;
using Business.Messages;
using Business.Validations;
using Core.Business;
using Core.Constants;
using Core.Extensions;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using Entities.DataTransferObjects;
using Entities.TableModels;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IProductDal _productDal;
        public CategoryManager(ICategoryDal categoryDal, IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
        }

        public IResult Add(CategoryCreateOrUpdateDto dto)
        {
            var model = CategoryCreateOrUpdateDto.ToCategory(dto);

            var validationResult = ValidationTool.Validate(new CategoryValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            var failedBusinessLogic = BusinessRules.Execute(CheckNameExistOrNot(model));

            if (failedBusinessLogic is not null)
                return failedBusinessLogic;

            _categoryDal.Add(model);
            _categoryDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult AddRange(List<Category> models)
        {
            _categoryDal.AddRange(models);
            _categoryDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(int id)
        {
            var deletedEntity = _categoryDal.GetById(x => x.Id == id);
            if (deletedEntity is null)
                return new ErrorResult(DefaultConstantValues.RECORD_NOT_FOUND);

            var failedBusinessLogic = BusinessRules.Execute(CheckRelationsOfCategoryForDelete(deletedEntity));
            if (failedBusinessLogic is not null)
                return failedBusinessLogic;

            deletedEntity.Deleted = id;
            _categoryDal.Update(deletedEntity);
            _categoryDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_DELETED_SUCCESSFULLY);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Category>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(pageNumber, pageSize, filter: x => x.Deleted == 0));
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetById(x => x.Id == id && x.Deleted ==0));
        }

        public IResult Update(CategoryCreateOrUpdateDto dto)
        {
            var model = CategoryCreateOrUpdateDto.ToCategory(dto);

            var validationResult = ValidationTool.Validate(new CategoryValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            var failedBusinessLogic = BusinessRules.Execute(CheckNameExistOrNot(model));
            if (failedBusinessLogic is not null)
                return failedBusinessLogic;

            _categoryDal.Update(model);
            _categoryDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_UPDATED_SUCCESSFULLY);
        }

        private IResult CheckNameExistOrNot(Category category)
        {
            var allData = _categoryDal.GetAll(x => x.Deleted == 0);
            var existingRow = allData.FirstOrDefault(x => x.Name == category.Name);
            if (existingRow != null)
                return new ErrorResult(DefaultConstantValues.DUPLICATE_RECORD_FOUND);

            return new SuccessResult();
        }

        private IResult CheckRelationsOfCategoryForDelete(Category category)
        {
            var productData = _productDal.GetAll(x => x.Deleted == 0);
            var existingRow = productData.FirstOrDefault(x => x.CategoryId == category.Id);
            if (existingRow != null) return new ErrorResult(CategoryMessages.HaveRelationWithCityTable);

            return new SuccessResult();
        }
    }
}
