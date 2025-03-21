﻿using Stock.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface IProdutoDomain
    {
        Task<Produto> Create(Produto item);
        Task<int> Delete(int id);
        Task<Produto> GetById(int id);
        Task<IEnumerable<Produto>> List();
        Task<int> Update(Produto item);
    }
}