using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoriRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoriRepository,
                           IMapper mapper)
    {
        _categoriRepository = categoriRepository;
        _mapper = mapper;
    }

    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoriRepository.CreateAsync(categoryEntity);
    }

    public async Task<CategoryDTO> GetById(int? id)
    {
        var categoryEntity = await _categoriRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        try
        {
            var categoriesEntity = await _categoriRepository.GetCategoriesAsync();

            return _mapper
                    .Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar as categorias:" + ex.Message);
        }
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoriRepository.GetByIdAsync(id).Result;
        await _categoriRepository.RemoveAsync(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoriRepository.UpdateAsync(categoryEntity);
    }

}
