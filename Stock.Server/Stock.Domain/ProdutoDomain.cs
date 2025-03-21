using Stock.Interfaces;
using Stock.Model.Dto;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ProdutoResponse> Create(ProdutoRequest item)
        {
            return new ProdutoResponse(await _repository.Create(item.ToEntity()));
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ProdutoResponse> GetById(int id)
        {
            return new ProdutoResponse(await _repository.GetById(id));
        }

        public async Task<IEnumerable<ProdutoResponse>> List()
        {
            return (await _repository.List()).Select(x => new ProdutoResponse(x));
        }

        public async Task<int> Update(ProdutoRequest item)
        {
            return await _repository.Update(item.ToEntity());
        }
    }
}
