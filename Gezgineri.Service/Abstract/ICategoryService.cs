using Gezgineri.Service.Dto.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface ICategoryService
    {
        public Task<bool> AddOrUpdateCategoryAsync(CategoryDto categoryDto);
        public Task<bool> DeleteCategoryAsync(Guid id);
        public Task<IEnumerable<CategoryDto?>> GetAllCategoriesAsync();
        public Task<CategoryDto?> GetCategoryByIdAsync(Guid id);
    }
}
