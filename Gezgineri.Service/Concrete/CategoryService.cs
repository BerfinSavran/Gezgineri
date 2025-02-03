using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Repository.Concrete;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.CategoryDtos;

namespace Gezgineri.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddOrUpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            if (categoryDto.ID == null)
            {
                return await _categoryRepository.AddAsync(category);
            }
            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No category exists with the provided identifier.");
            }
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto?>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("No category exists with the provided identifier.");
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
