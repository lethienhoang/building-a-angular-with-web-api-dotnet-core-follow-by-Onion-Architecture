using AutoMapper;
using BlogEngine.Core.Entities;
using BlogEngine.Services.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Http.Utilities.Mappers
{
    public class MappingEntityToViewModel : Profile
    {
        
        public MappingEntityToViewModel()
        {
            CreateMap<Post, PostViewModel>();
        }


    }
}
