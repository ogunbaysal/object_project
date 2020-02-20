using Fop;
using server.Helpers;
using server.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface ICategoryService
    {
        Category GetById(long id);
        Category GetBySlug(string slug);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAll(IFopRequest request);

    }
    public class CategoryService : ICategoryService
    {
        private readonly ModelContext _context;

        public CategoryService(ModelContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {

            return _context.Categories.Where(x => x.Status == CategoryStatus.ACTIVE).ToList();
        }
        public IEnumerable<Category> GetAll(IFopRequest request)
        {
            var (categories, totalCount) = _context.Categories.Where(x => x.Status == CategoryStatus.ACTIVE).ApplyFop(request);
            if (totalCount == 0)
            {
                throw new AppException("No Category Found");
            }
            return categories;
        }

        public Category GetById(long id)
        {
            var Category = _context.Categories.Find(id);
            if (Category != null)
            {
                return Category;
            }
            else
            {
                throw new AppException("Category Not Found");
            }
        }

        public Category GetBySlug(string slug)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Slug == slug);
            if (Category != null)
            {
                return Category;
            }
            else
            {
                throw new AppException("Category Not Found");
            }
        }
    }
}
