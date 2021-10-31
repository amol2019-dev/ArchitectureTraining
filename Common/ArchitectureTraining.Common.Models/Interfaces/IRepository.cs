using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectureTraining.Common.Models.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(string id);

        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}
