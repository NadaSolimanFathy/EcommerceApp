﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        Task<T> GetByIdAsync(int? id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task Add  (T entity);
        void Update (T entity);
        void Delete (T entity);

    }
}
