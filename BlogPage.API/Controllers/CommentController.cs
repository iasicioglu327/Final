using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogPage.API.Controllers
{
    public class CommentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _service;

        public CommentController(IMapper mapper, ICommentService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPut]
        public IActionResult Update(CommentDTO commentDto)
        {
            _service.Update(_mapper.Map<Comment>(commentDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = _service.GetbyId(id);
            _service.Delete(comment);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpPost]
        public IActionResult Add(CommentDTO commentDto)
        {
            var comment = _service.Add(_mapper.Map<Comment>(commentDto));
            return CreateActionResult(CustomResponseDTO<CommentDTO>.Success(201, _mapper.Map<CommentDTO>(comment)));
        }

        [HttpGet("[action]")]
        public IActionResult GetCommentwithBlog()
        {
            return CreateActionResult(_service.GetCommentwithBlog());
        }
    }
}
