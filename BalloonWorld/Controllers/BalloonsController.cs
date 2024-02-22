using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BalloonWorld.Data;
using BalloonWorld.Models;

namespace BalloonWorld.Controllers
{
    public class BalloonsController : Controller
    {
        private readonly BalloonWorldContext _context;

        public BalloonsController(BalloonWorldContext context)
        {
            _context = context;
        }

        // GET: Balloons
        // GET: Movies

        public async Task<IActionResult> Index(string balloonoccasion, string searchString)
        {
            if (_context.Balloon == null)
            {
                return Problem("Entity set 'BalloonWorldContext.Balloons  is null.");
            }
            // Use LINQ to get list of genres. 

            IQueryable<string> balloonQuery = from m in _context.Balloon

                                              orderby m.Occasion

                                              select m.Occasion;

            var balloons = from m in _context.Balloon

                           select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                balloons = balloons.Where(s => s.Material!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(balloonoccasion))

            {

                balloons = balloons.Where(x => x.Occasion == balloonoccasion);

            }



            var balloonoccasionviewmodel = new balloonoccasionviewmodel

            {

                occasion = new SelectList(await balloonQuery.Distinct().ToListAsync()),

                Balloons = await balloons.ToListAsync()

            };

            return View(balloonoccasionviewmodel);
        }

            [HttpPost]

            public string Index(string searchString, bool notUsed)

            {

                return "From [HttpPost]Index: filter on " + searchString;

            }

        

        // GET: Balloons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balloon = await _context.Balloon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balloon == null)
            {
                return NotFound();
            }

            return View(balloon);
        }

        // GET: Balloons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Balloons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Material,Occasion,Size,Shape,Price")] Balloon balloon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balloon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balloon);
        }

        // GET: Balloons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balloon = await _context.Balloon.FindAsync(id);
            if (balloon == null)
            {
                return NotFound();
            }
            return View(balloon);
        }

        // POST: Balloons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Material,Occasion,Size,Shape,Price")] Balloon balloon)
        {
            if (id != balloon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balloon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalloonExists(balloon.Id))
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
            return View(balloon);
        }

        // GET: Balloons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balloon = await _context.Balloon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balloon == null)
            {
                return NotFound();
            }

            return View(balloon);
        }

        // POST: Balloons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var balloon = await _context.Balloon.FindAsync(id);
            if (balloon != null)
            {
                _context.Balloon.Remove(balloon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalloonExists(int id)
        {
            return _context.Balloon.Any(e => e.Id == id);
        }
    }
}
