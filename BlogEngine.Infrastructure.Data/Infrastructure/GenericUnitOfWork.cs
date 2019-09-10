using BlogEngine.Core;
using BlogEngine.Core.Context;
using BlogEngine.Core.Entities;
using BlogEngine.Infrastructure.Data.Abstract;
using BlogEngine.Infrastructure.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Infrastructure.Data.Infrastructure
{
    public class GenericUnitOfWork : IDisposable, IBaseUnitOfWork
    {
        private BlogContext context;
        private bool disposed = false;

        public GenericUnitOfWork(BlogContext context)
        {
            this.context = context;
        }

        private IEntityBaseRepository<Post> postRepository;
        private IEntityBaseRepository<Category> categoryRepository;
        private IEntityBaseRepository<Comment> commentRepository;
        private IEntityBaseRepository<User> userRepository;



        public IEntityBaseRepository<Post> PostRepository
        {
            get
            {
                if (postRepository == null)
                {
                    postRepository = new GenericRepository<Post>(context);
                }

                return postRepository;
            }
        }


        public IEntityBaseRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(context);
                }

                return categoryRepository;
            }
        }


        public IEntityBaseRepository<Comment> CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new GenericRepository<Comment>(context);
                }

                return commentRepository;
            }
        }


        public IEntityBaseRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(context);
                }

                return UserRepository;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            context.SaveChanges();

            // after savechange then dispose

            Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            Dispose();
        }

    }
}
