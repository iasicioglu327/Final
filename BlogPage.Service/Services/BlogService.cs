using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Repositories;
using BlogPage.Core.Services;
using BlogPage.Core.UnitofWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Service.Services
{
    public class BlogService : Service<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IRepository<Blog> repository, IUnitofWork work, IBlogRepository blogRepository, IMapper mapper) : base(repository, work)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public CustomResponseDTO<List<BlogwithCategoryDTO>> GetBlogwithCategory()
        {
            var blogs = _blogRepository.GetBlogwithCategory();
            return CustomResponseDTO<List<BlogwithCategoryDTO>>.Success(200, _mapper.Map<List<BlogwithCategoryDTO>>(blogs));
        }
    }
}
