using AutoMapper;
using BlogEngine.Core.Entities;
using BlogEngine.Services.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Http.Utilities.Mappers
{
    public class MappingViewModelToEntity : Profile
    {
        public MappingViewModelToEntity()
        {
            CreateMap<PostViewModel, Post>();
        }
    }
}
