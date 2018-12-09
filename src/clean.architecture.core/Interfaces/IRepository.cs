using clean.architecture.core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
