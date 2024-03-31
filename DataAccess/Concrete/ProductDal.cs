using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class ProductDal : RepositoryBase<Product, ApplicationDbContext>, IProductDal
    {
        private readonly ApplicationDbContext _context;
        public ProductDal(ApplicationDbContext context) : base(context)
        {

            _context = context;

        }
    }
}
