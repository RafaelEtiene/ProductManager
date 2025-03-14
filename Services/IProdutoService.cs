using ProductManager.Models.Entities;

namespace ProductManager.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task InsertProdutoAsync(Produto produto);
    }
}
