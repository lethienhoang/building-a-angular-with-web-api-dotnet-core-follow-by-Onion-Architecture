using BlogEngine.Core;
using BlogEngine.Core.Entities;
using BlogEngine.Infrastructure.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Infrastructure.Data.Abstracts
{
    public interface IBaseUnitOfWork
    {
        IEntityBaseRepository<Post> PostRepository { get; }
        IEntityBaseRepository<Category> CategoryRepository { get; }
        IEntityBaseRepository<Comment> CommentRepository { get; }
        IEntityBaseRepository<User> UserRepository { get; }

        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
