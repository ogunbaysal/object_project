using Microsoft.EntityFrameworkCore;
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
        Task<Category> GetCategoryById(long id);
        Task<SubCategory> GetSubCategoryById(long id);
        Task<ChildCategory> GetChildCategoryById(long id);
        Task<IEnumerable<Category>> GetAll();

    }
    public class CategoryService : ICategoryService
    {
        private readonly ModelContext _context;

        public CategoryService(ModelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {

            var list = await _context.Categories
                .AsNoTracking()
                .AsQueryable()
                .Where(x => x.Status == CategoryStatus.ACTIVE)
                .Include(x => x.SubCategories)
                .ToListAsync();
            foreach(var item in list)
            {
                foreach(var sub in item.SubCategories)
                {
                    var childs = await _context.ChildCategories
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(x => x.SubCategoryId == sub.SubCategoryId && x.Status == CategoryStatus.ACTIVE)
                        .ToListAsync();
                    sub.ChildCategories = childs;
                }
            }
            return list;
        }
        public async Task<Category> GetCategoryById(long id)
        {
            var Category = await _context.Categories.FindAsync(id);
            if (Category != null)
            {
                return Category;
            }
            else
            {
                throw new AppException("Category Not Found");
            }
        }
        public async Task<SubCategory> GetSubCategoryById(long id)
        {
            var sub = await _context.SubCategories.FindAsync(id);
            if (sub != null)
            {
                return sub;
            }
            else
            {
                throw new AppException("Sub Category Not Found");
            }
        }
        public async Task<ChildCategory> GetChildCategoryById(long id)
        {
            var child = await _context.ChildCategories.FindAsync(id);
            if (child != null)
            {
                return child;
            }
            else
            {
                throw new AppException("Child Category Not Found");
            }
        }
    }
}
