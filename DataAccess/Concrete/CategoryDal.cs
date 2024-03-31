using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class CategoryDal : RepositoryBase<Category, ApplicationDbContext>, ICategoryDal
    {
        private readonly ApplicationDbContext _context;
        public CategoryDal(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }
    }
}
