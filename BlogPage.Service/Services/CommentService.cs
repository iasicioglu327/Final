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
    public class CommentService : Service<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IUnitofWork work, IMapper mapper, ICommentRepository commentRepository) : base(repository, work)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public CustomResponseDTO<List<CommentwithBlogDTO>> GetCommentwithBlog()
        {
            var comments = _commentRepository.GetCommentwithBlog();
            return CustomResponseDTO<List<CommentwithBlogDTO>>.Success(200, _mapper.Map<List<CommentwithBlogDTO>>(comments));
        }
    }
}
