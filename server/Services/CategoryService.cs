using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Category;
using server.Repositories.Categories;
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
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subCategoryRepository;
        private readonly ChildCategoryRepository _childCategoryRepository;
        public CategoryService(CategoryRepository categoryRepository, SubCategoryRepository subCategoryRepository, ChildCategoryRepository childCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _childCategoryRepository = childCategoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {

            var list = await _categoryRepository.ListAsync(x => x.Status == CategoryStatus.ACTIVE);
            foreach(var item in list)
            {
                var subCategories = await _subCategoryRepository.ListAsync(x => x.ParentCategoryId == item.CategoryId && x.Status == CategoryStatus.ACTIVE);
                item.SubCategories = subCategories.ToList();
                foreach(var sub in item.SubCategories)
                {
                    var childCategories = await _childCategoryRepository.ListAsync(x => x.SubCategoryId == sub.SubCategoryId && x.Status == CategoryStatus.ACTIVE);
                    sub.ChildCategories = childCategories.ToList();
                }
            }
            return list;
        }
        public async Task<Category> GetCategoryById(long id)
        {
            var Category = await _categoryRepository.FindByIdAsync(id);
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
            var sub = await _subCategoryRepository.FindByIdAsync(id);
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
            var child = await _childCategoryRepository.FindByIdAsync(id);
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
