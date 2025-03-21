using Stock.Interfaces;
using Stock.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Domain
{
    internal class MovimentacaoDomain : IMovimentacaoDomain
    {
        private readonly IMovimentacaoRepository _repository;

        public MovimentacaoDomain(IMovimentacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Movimentacao> Create(Movimentacao item)
        {
            return await _repository.Create(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Movimentacao> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Movimentacao>> List()
        {
            return await _repository.List();
        }

        public async Task<int> Update(Movimentacao item)
        {
            return await _repository.Update(item);
        }
    }
}
