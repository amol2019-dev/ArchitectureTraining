using System;
using System.Collections.Generic;
using System.Text;
using ArchitectureTraining.Common.Models.Interfaces;
namespace ArchitectureTraining.Common.Repository
{
   public class RepositoryBase<T> : RepositoryBase, IRepository<T>
    {
        public RepositoryBase(ICouchbaseService couchbaseService) : base(couchbaseService)
        {
        }

        public string GenrateKey(string id)
        {
            return $"{typeof(T).Name}::{id}";
        }

        public virtual bool Create(T item)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(T item)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(string id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class RepositoryBase
    {
        public readonly ICouchbaseService _couchbaseService;
        public RepositoryBase(ICouchbaseService couchbaseService)
        {
            _couchbaseService = couchbaseService;
        }
    }
}
