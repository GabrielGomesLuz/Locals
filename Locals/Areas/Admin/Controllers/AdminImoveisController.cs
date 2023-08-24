using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locals.Context;
using Locals.Models;

namespace Locals.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminImoveisController : Controller
    {
        private readonly AppDbContext _context;

        public AdminImoveisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminImoveis
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Imoveis.Include(i => i.Categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminImoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaID", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminImoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelId,NomeImovel,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsImovelDestaque,Disponivel,CategoriaId,Imagem1,Imagem2,ImagemUrl3,ImagemUrl4,ImagemUrl5")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaID", "CategoriaNome", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaID", "CategoriaNome", imovel.CategoriaId);
            return View(imovel);
        }

        // POST: Admin/AdminImoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,NomeImovel,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsImovelDestaque,Disponivel,CategoriaId,Imagem1,Imagem2,ImagemUrl3,ImagemUrl4,ImagemUrl5")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaID", "CategoriaNome", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Admin/AdminImoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imoveis == null)
            {
                return Problem("Entity set 'AppDbContext.Imoveis'  is null.");
            }
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
          return _context.Imoveis.Any(e => e.ImovelId == id);
        }
    }
}
