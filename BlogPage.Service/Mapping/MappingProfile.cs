using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Service.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Blog, BlogwithCategoryDTO>().ReverseMap();
            CreateMap<Category, CategorywithBlogDTO>().ReverseMap();
            CreateMap<Comment, BlogwithCommentsDTO>().ReverseMap();
            CreateMap<Comment, CommentwithBlogDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, BlogTagDTO>().ReverseMap();
            CreateMap<Blog, BlogTagDTO>().ReverseMap();
        }
    }
}
