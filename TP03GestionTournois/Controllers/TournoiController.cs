using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP03GestionTournois.Models;

namespace TP03GestionTournois.Controllers
{
    public class TournoiController : Controller
    {
        private readonly TournoiContext _context;

        public TournoiController(TournoiContext context)
        {
            _context = context;
        }

        // GET: Tournoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tournois.ToListAsync());
        }

        // GET: Search Tournoi By text
        public async Task<IActionResult> Search(string searching)
        {
          return View(await _context.Tournois.Where(t => t.Jeu.Contains(searching) ||
                                                         t.Nom.Contains(searching) ||
                                                         t.Date.Contains(searching) ||
                                                         t.Prix.ToString().Contains(searching) ||
                                                         t.Theme.Contains(searching) ||
                                                         t.Description.Contains(searching) ||
                                                         searching==null).ToListAsync());
        }

        // GET: Tournoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.IdTournoi == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // GET: Tournoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournoi,Nom,Prix,Description,Date,Jeu,Theme")] Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournoi);
        }

        // GET: Tournoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois.FindAsync(id);
            if (tournoi == null)
            {
                return NotFound();
            }
            return View(tournoi);
        }

        // POST: Tournoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournoi,Nom,Prix,Description,Date,Jeu,Theme")] Tournoi tournoi)
        {
            if (id != tournoi.IdTournoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournoiExists(tournoi.IdTournoi))
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
            return View(tournoi);
        }

        // GET: Tournoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.IdTournoi == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // POST: Tournoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournoi = await _context.Tournois.FindAsync(id);
            _context.Tournois.Remove(tournoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournoiExists(int id)
        {
            return _context.Tournois.Any(e => e.IdTournoi == id);
        }
    }
}
