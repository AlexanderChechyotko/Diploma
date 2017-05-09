using DAL.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private IGenericRepository<Category> _categoryRepository;

        private IGenericRepository<Post> _postRepository;

        private IGenericRepository<Tag> _tagRepository;

        private IGenericRepository<Comment> _commentRepository;

        private IGenericRepository<Auction> _auctionRepository;

        public IGenericRepository<Auction> Auctions
        {
            get
            {
                if (_auctionRepository == null)
                    _auctionRepository = new GenericRepository<Auction>(_dbContext);
                return _auctionRepository;
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new GenericRepository<Category>(_dbContext);
                return _categoryRepository;
            }
        }

        public IGenericRepository<Post> Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new GenericRepository<Post>(_dbContext);
                return _postRepository;
            }
        }

        public IGenericRepository<Tag> Tags
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new GenericRepository<Tag>(_dbContext);
                return _tagRepository;
            }
        }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new GenericRepository<Comment>(_dbContext);
                return _commentRepository;
            }
        }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            List<string> errors = new List<string>();
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errors.Add("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errors.Add(err.ErrorMessage + "");
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
                this.disposed = true;
            }
        }
    }
}
