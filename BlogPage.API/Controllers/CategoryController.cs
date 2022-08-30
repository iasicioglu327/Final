using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.API.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _categoryService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categ = _categoryService.GetbyId(id);
            return CreateActionResult(CustomResponseDTO<CategoryDTO>.Success(200, _mapper.Map<CategoryDTO>(categ)));
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categ = _categoryService.GetbyId(id);
            _categoryService.Delete(categ);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categs = _categoryService.GetList();
            var categDtos = _mapper.Map<List<CategoryDTO>>(categs);
            return CreateActionResult(CustomResponseDTO<List<CategoryDTO>>.Success(200, categDtos));
        }
        [HttpPost]
        public IActionResult Add(CategoryDTO categoryDto)
        {
            var categ = _categoryService.Add(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDTO<CategoryDTO>.Success(201, _mapper.Map<CategoryDTO>(categ)));
        }
    }
}
