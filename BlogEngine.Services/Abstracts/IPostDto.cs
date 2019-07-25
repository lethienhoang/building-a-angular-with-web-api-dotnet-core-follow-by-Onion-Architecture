using BlogEngine.Services.Dtos.Posts;
using System;
using System.Threading.Tasks;

namespace BlogEngine.Services.Abstracts
{
    public interface IPostDto
    {
        Task<PostDto> GetAll();

    }
}