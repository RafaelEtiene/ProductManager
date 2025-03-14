using ProductManager.Models.Entities;

namespace ProductManager.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task InsertProdutoAsync(Produto produto);
    }
}
