using Core.DataAccess.Abstract;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
    }
}
