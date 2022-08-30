using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Repositories;
using BlogPage.Core.Services;
using BlogPage.Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Service.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Category> repository, IUnitofWork work, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, work)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public CustomResponseDTO<CategorywithBlogDTO> GetCategorybyId(int categoryId)
        {
            var categ = _categoryRepository.GetCategorybyId(categoryId);
            var categDto = _mapper.Map<CategorywithBlogDTO>(categ);
            return CustomResponseDTO<CategorywithBlogDTO>.Success(200, categDto);
        }
    }
}
