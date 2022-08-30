using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.API.Controllers
{
    public class BlogController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _service;

        public BlogController(IMapper mapper, IBlogService blogService)
        {
            _mapper = mapper;
            _service = blogService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = _service.GetbyId(id);
            return CreateActionResult(CustomResponseDTO<BlogDTO>.Success(200, _mapper.Map<BlogDTO>(blog)));
        }

        [HttpPost]
        public IActionResult Add(BlogDTO blogDto)
        {
            var blog = _service.Add(_mapper.Map<Blog>(blogDto));
            return CreateActionResult(CustomResponseDTO<BlogDTO>.Success(201, _mapper.Map<BlogDTO>(blog)));
        }

        [HttpPut]
        public IActionResult Update(BlogDTO blogDto)
        {
            _service.Update(_mapper.Map<Blog>(blogDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var blog = _service.GetbyId(id);
            _service.Delete(blog);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _service.GetList();
            var blogDtos = _mapper.Map<List<BlogDTO>>(blogs);
            return CreateActionResult(CustomResponseDTO<List<BlogDTO>>.Success(200,blogDtos));
        }
        [HttpGet("[action]")]
        public IActionResult GetBlogwithCategory()
        {
            return CreateActionResult(_service.GetBlogwithCategory());
        }
    }
}
