﻿using BlogEngine.Services.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Services.Abstracts
{
    public interface IPostQueryByCondition
    {
        Task<PostDto> GetByCondition(PostQueryByConditionDto condition);
        Task<PostDto> GetById(Guid id);


    }
}