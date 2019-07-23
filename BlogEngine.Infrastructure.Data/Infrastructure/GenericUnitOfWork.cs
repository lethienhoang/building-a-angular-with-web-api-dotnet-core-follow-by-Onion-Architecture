using BlogEngine.Core;
using BlogEngine.Core.Context;
using BlogEngine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        private GenericRepository<IdentityUser> identityUserRepository;



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


        GenericRepository<Category> CategoryRepository
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


        GenericRepository<Comment> CommentRepository
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


        GenericRepository<IdentityUser> IdentityUserRepository
        {
            get
            {
                if (identityUserRepository == null)
                {
                    identityUserRepository = new GenericRepository<IdentityUser>(context);
                }

                return identityUserRepository;
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
    }
}
