using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galvanic.Model;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Galvanic.Infrastructure
{
    public class GalvanicRepositoryBase<T> : IRepository<T> where T : class
    {
        private GalvanicModelContainer _context;
        private IDbSet<T> _dbset;

        protected GalvanicRepositoryBase()
        {
            _context = new GalvanicModelContainer();
            _dbset = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }


        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            Commit();
        }

        private void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var exceptionMessage = new StringBuilder();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        exceptionMessage.AppendFormat("Property: {0} Error: {1}", validationError.PropertyName,
                                                   validationError.ErrorMessage);
                    }
                }

                throw; //so that we see the exception right away when we develop
            }
        }
    }
}
