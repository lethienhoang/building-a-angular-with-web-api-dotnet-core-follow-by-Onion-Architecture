using BlogEngine.Core;
using BlogEngine.Core.Context;
using BlogEngine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Infrastructure.Data.Infrastructure
{
    public class GenericUnitOfWork : IDisposable
    {
        private DatabaseContext context;
        private bool disposed = false;

        public GenericUnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        private GenericRepository<Post> postRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Comment> commentRepository;
        private GenericRepository<User> userRepository;



        public GenericRepository<Post> PostRepository
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


        public GenericRepository<Category> CategoryRepository
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


        public GenericRepository<Comment> CommentRepository
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


        public GenericRepository<User> UserRepository
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
