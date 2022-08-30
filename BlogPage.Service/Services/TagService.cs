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
    public class TagService : Service<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(IRepository<Tag> repository, IUnitofWork work, ITagRepository tagRepository, IMapper mapper) : base(repository, work)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public CustomResponseDTO<List<BlogTagDTO>> GetBlogTag()
        {
            var tags = _tagRepository.GetBlogTag();
            return CustomResponseDTO<List<BlogTagDTO>>.Success(200, _mapper.Map<List<BlogTagDTO>>(tags));
        }
    }
}
