using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Category;
using server.Repositories.Categories;
using server.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace server.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetSubCategoriesAsync(long id);
        Task<IEnumerable<ChildCategory>> GetChildCategoriesAsync(long id);

        Task<Category> GetCategoryByIdAsync(long id);
        Task<SubCategory> GetSubCategoryByIdAsync(long id);
        Task<ChildCategory> GetChildCategoryByIdAsync(long id);

    }
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<SubCategory> _subCategoryRepository;
        private readonly IRepository<ChildCategory> _childCategoryRepository;
        public CategoryService(IRepository<Category> categoryRepository, IRepository<SubCategory> subCategoryRepository, IRepository<ChildCategory> childCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _childCategoryRepository = childCategoryRepository;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> list = await _categoryRepository.ListAsync(x => x.Status == CategoryStatus.ACTIVE);
            return list;
        }
        public async Task<IEnumerable<SubCategory>> GetSubCategoriesAsync(long categoryId)
        {
            var list = await _subCategoryRepository.ListAsync(x => x.ParentCategoryId == categoryId && x.Status == CategoryStatus.ACTIVE);
            return list;
        }
        public async Task<IEnumerable<ChildCategory>> GetChildCategoriesAsync(long subCategoryId)
        {
            var list = await _childCategoryRepository.ListAsync(x => x.SubCategoryId == subCategoryId && x.Status == CategoryStatus.ACTIVE);
            return list;
        }
        public async Task<Category> GetCategoryByIdAsync(long id)
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
        public async Task<SubCategory> GetSubCategoryByIdAsync(long id)
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
        public async Task<ChildCategory> GetChildCategoryByIdAsync(long id)
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
