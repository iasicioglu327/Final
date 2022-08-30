using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.API.Controllers
{
    public class TagController:CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITagService _service;

        public TagController(IMapper mapper, ITagService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpDelete]
        public IActionResult Delete(TagDTO tagDto)
        {
            _service.Delete(_mapper.Map<Tag>(tagDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpPost]
        public IActionResult Add(TagDTO tagDto)
        {
            var tag = _service.Add(_mapper.Map<Tag>(tagDto));
            return CreateActionResult(CustomResponseDTO<TagDTO>.Success(201, _mapper.Map<TagDTO>(tag)));
        }

        [HttpGet("[action]")]
        public IActionResult GetBlogTag()
        {
            return CreateActionResult(_service.GetBlogTag());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _service.GetList();
            var tagDtos = _mapper.Map<List<TagDTO>>(tags);
            return CreateActionResult(CustomResponseDTO<List<TagDTO>>.Success(200, tagDtos));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tag = _service.GetbyId(id);
            return CreateActionResult(CustomResponseDTO<TagDTO>.Success(200, _mapper.Map<TagDTO>(tag)));
        }
    }
}
