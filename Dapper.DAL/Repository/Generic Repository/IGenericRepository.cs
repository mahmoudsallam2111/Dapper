﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DAL.Repository.Generic_Repository
{
   public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(int id);

        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
            
    }
}
