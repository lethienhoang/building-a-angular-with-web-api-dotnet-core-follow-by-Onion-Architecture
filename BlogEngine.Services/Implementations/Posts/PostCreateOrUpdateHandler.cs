using BlogEngine.Services.Abstracts;
using BlogEngine.Services.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Services.Implementations.Posts
{
    public class PostCreateOrUpdate : IPostCreateOrUpdate
    {
        public Task<PostDto> Create(PostCreateOrUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
