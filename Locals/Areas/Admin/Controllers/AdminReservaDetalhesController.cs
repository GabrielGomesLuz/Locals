using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locals.Context;
using Locals.Models;
using Microsoft.IdentityModel.Tokens;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Authorization;

namespace Locals.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]

    public class AdminReservaDetalhesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminReservaDetalhesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminReservaDetalhes
        
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ReservaDetalhe.Include(r => r.Imovel).Include(r => r.Reserva);
            return View(await appDbContext.ToListAsync());
        }
        


     






        // GET: Admin/AdminReservaDetalhes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReservaDetalhe == null)
            {
                return NotFound();
            }

            var reservaDetalhe = await _context.ReservaDetalhe
                .Include(r => r.Imovel)
                .Include(r => r.Reserva)
                .FirstOrDefaultAsync(m => m.ReservaDetalheId == id);
            if (reservaDetalhe == null)
            {
                return NotFound();
            }

            return View(reservaDetalhe);
        }

        // GET: Admin/AdminReservaDetalhes/Create
        public IActionResult Create()
        {
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "DescricaoCurta");
            ViewData["ReservaInteresseId"] = new SelectList(_context.ReservaInteresse, "ReservaInteresseId", "Email");
            return View();
        }

        // POST: Admin/AdminReservaDetalhes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaDetalheId,Preco,ImovelId,ReservaInteresseId")] ReservaDetalhe reservaDetalhe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaDetalhe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "DescricaoCurta", reservaDetalhe.ImovelId);
            ViewData["ReservaInteresseId"] = new SelectList(_context.ReservaInteresse, "ReservaInteresseId", "Email", reservaDetalhe.ReservaInteresseId);
            return View(reservaDetalhe);
        }

        // GET: Admin/AdminReservaDetalhes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReservaDetalhe == null)
            {
                return NotFound();
            }

            var reservaDetalhe = await _context.ReservaDetalhe.FindAsync(id);
            if (reservaDetalhe == null)
            {
                return NotFound();
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "DescricaoCurta", reservaDetalhe.ImovelId);
            ViewData["ReservaInteresseId"] = new SelectList(_context.ReservaInteresse, "ReservaInteresseId", "Email", reservaDetalhe.ReservaInteresseId);
            return View(reservaDetalhe);
        }

        // POST: Admin/AdminReservaDetalhes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaDetalheId,Preco,ImovelId,ReservaInteresseId")] ReservaDetalhe reservaDetalhe)
        {
            if (id != reservaDetalhe.ReservaDetalheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaDetalhe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaDetalheExists(reservaDetalhe.ReservaDetalheId))
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
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "DescricaoCurta", reservaDetalhe.ImovelId);
            ViewData["ReservaInteresseId"] = new SelectList(_context.ReservaInteresse, "ReservaInteresseId", "Email", reservaDetalhe.ReservaInteresseId);
            return View(reservaDetalhe);
        }

        // GET: Admin/AdminReservaDetalhes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReservaDetalhe == null)
            {
                return NotFound();
            }

            var reservaDetalhe = await _context.ReservaDetalhe
                .Include(r => r.Imovel)
                .Include(r => r.Reserva)
                .FirstOrDefaultAsync(m => m.ReservaDetalheId == id);
            if (reservaDetalhe == null)
            {
                return NotFound();
            }

            return View(reservaDetalhe);
        }

        // POST: Admin/AdminReservaDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservaDetalhe == null)
            {
                return Problem("Entity set 'AppDbContext.ReservaDetalhe'  is null.");
            }
            var reservaDetalhe = await _context.ReservaDetalhe.FindAsync(id);
            if (reservaDetalhe != null)
            {
                _context.ReservaDetalhe.Remove(reservaDetalhe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaDetalheExists(int id)
        {
          return _context.ReservaDetalhe.Any(e => e.ReservaDetalheId == id);
        }
    }
}
