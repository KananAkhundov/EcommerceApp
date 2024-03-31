using Business.Abstract;
using Business.Validations;
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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(ProductCreateOrUpdateDto dto)
        {
            var model = ProductCreateOrUpdateDto.ToProduct(dto);

            var validationResult = ValidationTool.Validate(new ProductValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _productDal.Add(model);
            _productDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult AddRange(List<Product> models)
        {
            _productDal.AddRange(models);
            _productDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESSFULLY);
        }

        public IResult Delete(int id)
        {
            var deletedEntity = _productDal.GetById(x => x.Id == id);
            if (deletedEntity is null)
                return new ErrorResult(DefaultConstantValues.RECORD_NOT_FOUND);

            deletedEntity.Deleted = id;
            _productDal.Update(deletedEntity);
            _productDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_DELETED_SUCCESSFULLY);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Product>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(pageNumber, pageSize, filter: x => x.Deleted == 0));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetById(x => x.Id == id && x.Deleted == 0));
        }

        public IResult Update(ProductCreateOrUpdateDto dto)
        {
            var model = ProductCreateOrUpdateDto.ToProduct(dto);

            var validationResult = ValidationTool.Validate(new ProductValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _productDal.Update(model);
            _productDal.SaveChanges();
            return new SuccessResult(DefaultConstantValues.DATA_UPDATED_SUCCESSFULLY);
        }
    }
}
