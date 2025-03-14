using ProductManager.Models.Entities;
using ProductManager.Repositories;

namespace ProductManager.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _repository.GetProdutosAsync();
        }

        public async Task InsertProdutoAsync(Produto produto)
        {
            await _repository.InsertProdutoAsync(produto);
        }
    }
}
