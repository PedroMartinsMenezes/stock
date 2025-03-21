using Stock.Interfaces;
using Stock.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Domain
{
    internal class ProdutoDomain : IProdutoDomain
    {
        private readonly IProdutoRepository _repository;

        public ProdutoDomain(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> Create(Produto item)
        {
            return await _repository.Create(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Produto> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Produto>> List()
        {
            return await _repository.List();
        }

        public async Task<int> Update(Produto item)
        {
            return await _repository.Update(item);
        }
    }
}
