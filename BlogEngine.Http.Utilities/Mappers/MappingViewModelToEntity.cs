using AutoMapper;
using BlogEngine.Core.Entities;
using BlogEngine.Services.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Http.Utilities.Mappers
{
    public class MappingViewModelToEntity : Profile
    {
        public MappingViewModelToEntity()
        {
            CreateMap<PostDto, Post>();
        }
    }
}
