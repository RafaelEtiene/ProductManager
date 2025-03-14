using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Entities;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProdutosAsync());
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View(new Produto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Preco,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertProdutoAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            // Caso a validação falhe, retorne com os erros
            return View(produto);
        }

        //public async Task<IActionResult> Edit(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }

        //    var produto = await _context.produtos.findasync(id);
        //    if (produto == null)
        //    {
        //        return notfound();
        //    }
        //    return view(produto);
        //}

        //// POST: Produto/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] Produto produto)
        //{
        //    if (id != produto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(produto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProdutoExists(produto.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(produto);
        //}

        //// GET: Produto/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var produto = await _context.Produtos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(produto);
        //}

        //// POST: Produto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var produto = await _context.Produtos.FindAsync(id);
        //    _context.Produtos.Remove(produto);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProdutoExists(int id)
        //{
        //    return _context.Produtos.Any(e => e.Id == id);
        //}
    }
}
