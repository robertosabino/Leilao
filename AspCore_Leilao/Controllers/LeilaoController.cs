using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCore_Roles.Data;
using AspCore_Roles.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspCore_Roles.Controllers
{
  public class LeilaoController : Controller
  {
    private readonly LeilaoDbContext _context;

    public LeilaoController(LeilaoDbContext context)
    {
      _context = context;
    }

    // GET: Leilao
    public async Task<IActionResult> Index()
    {
      return View(await _context.Leiloes.ToListAsync());
    }

    // GET: Leilao/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      //var leilao = await _context.Leiloes
      //    .SingleOrDefaultAsync(m => m.LeilaoID == id);

      var leilao = await _context.Leiloes
               .Include(s => s.Lances)                   
               .AsNoTracking()
               .SingleOrDefaultAsync(m => m.LeilaoID == id);

      if (leilao == null)
      {
        return NotFound();
      }

      return View(leilao);
    }

    // GET: Leilao/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
      return View();
    }

    // POST: Leilao/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]  
    public async Task<IActionResult> Create([Bind("LeilaoID,Nome,ValorInicial,Usado,DataAbertura,DataFinalizacao")] Leilao leilao)
    {
      if (ModelState.IsValid)
      {
        _context.Add(leilao);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(leilao);
    }

    // GET: Leilao/Edit/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var leilao = await _context.Leiloes.SingleOrDefaultAsync(m => m.LeilaoID == id);
      if (leilao == null)
      {
        return NotFound();
      }
      return View(leilao);
    }

    // POST: Leilao/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LeilaoID,Nome,ValorInicial,Usado,DataAbertura,DataFinalizacao")] Leilao leilao)
    {
      if (id != leilao.LeilaoID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(leilao);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!LeilaoExists(leilao.LeilaoID))
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
      return View(leilao);
    }

    // GET: Leilao/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var leilao = await _context.Leiloes
          .SingleOrDefaultAsync(m => m.LeilaoID == id);
      if (leilao == null)
      {
        return NotFound();
      }

      return View(leilao);
    }

    // POST: Leilao/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var leilao = await _context.Leiloes.SingleOrDefaultAsync(m => m.LeilaoID == id);
      _context.Leiloes.Remove(leilao);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool LeilaoExists(int id)
    {
      return _context.Leiloes.Any(e => e.LeilaoID == id);
    }
  }
}
