using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo_w57047.Database;
using Zoo_w57047.Entity;
using Zoo_w57047.Enums;
using Zoo_w57047.Models;

namespace Zoo_w57047.Controllers
{
    public class AviariesController : Controller
    {
        private readonly ZooContext _context;

        public AviariesController(ZooContext context)
        {
            _context = context;
        }

        // GET: Aviaries
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 5;

            IQueryable<Aviary> source = _context.Aviaries.Include(x => x.Animals);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Aviaries = items
            };
            return View(viewModel);
        }

        // GET: Aviaries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviary = await _context.Aviaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviary == null)
            {
                return NotFound();
            }

            return View(aviary);
        }

        // GET: Aviaries/Create
        public IActionResult Create()
        {
            var aviaryTypes = from AviaryType d in Enum.GetValues(typeof(AviaryType))
                            select new { ID = (int)d, Name = d.ToString() };
            var aviaryConditions = from AviaryCondition d in Enum.GetValues(typeof(AviaryCondition))
                              select new { ID = (int)d, Name = d.ToString() };
            ViewData["AviaryType"] = new SelectList(aviaryTypes, "ID", "Name");
            ViewData["AviaryConditions"] = new SelectList(aviaryConditions, "ID", "Name");

            var Zoos = _context.Zoos.Where(x => x.Id == x.Id).ToList();

            NewAviary viewModel = new NewAviary
            {
                Zoos = Zoos
            };

            return View(viewModel);
        }

        // POST: Aviaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Condition,MaxAnimals,Type,ZooId")] Aviary aviary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aviary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aviary);
        }

        // GET: Aviaries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviary = await _context.Aviaries.FindAsync(id);
            if (aviary == null)
            {
                return NotFound();
            }

            var aviaryTypes = from AviaryType d in Enum.GetValues(typeof(AviaryType))
                              select new { ID = (int)d, Name = d.ToString() };
            var aviaryConditions = from AviaryCondition d in Enum.GetValues(typeof(AviaryCondition))
                                   select new { ID = (int)d, Name = d.ToString() };
            ViewData["AviaryType"] = new SelectList(aviaryTypes, "ID", "Name");
            ViewData["AviaryConditions"] = new SelectList(aviaryConditions, "ID", "Name");

            return View(aviary);
        }

        // POST: Aviaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Condition,MaxAnimals,Type")] Aviary aviary)
        {
            if (id != aviary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aviary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AviaryExists(aviary.Id))
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
            return View(aviary);
        }

        // GET: Aviaries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviary = await _context.Aviaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviary == null)
            {
                return NotFound();
            }

            return View(aviary);
        }

        // POST: Aviaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var aviary = await _context.Aviaries.FindAsync(id);
            _context.Aviaries.Remove(aviary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AviaryExists(long id)
        {
            return _context.Aviaries.Any(e => e.Id == id);
        }
    }
}
