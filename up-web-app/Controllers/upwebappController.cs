using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using up_web_app.Data;
using up_web_app.Models;

namespace up_web_app.Controllers
{
    public class upwebappController : Controller
    {
        private readonly up_web_appContext _context;

        public upwebappController(up_web_appContext context)
        {
            _context = context;
        }

        // GET: upwebapp
        public async Task<IActionResult> Index()
        {
            return View(await _context.upwebapp.ToListAsync());
        }

        // GET: upwebapp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upwebapp = await _context.upwebapp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upwebapp == null)
            {
                return NotFound();
            }

            return View(upwebapp);
        }

        // GET: upwebapp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: upwebapp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,prodName,prodPrice,prodDescription,prodSupplierName")] upwebapp upwebapp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upwebapp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(upwebapp);
        }

        // GET: upwebapp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upwebapp = await _context.upwebapp.FindAsync(id);
            if (upwebapp == null)
            {
                return NotFound();
            }
            return View(upwebapp);
        }

        // POST: upwebapp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,prodName,prodPrice,prodDescription,prodSupplierName")] upwebapp upwebapp)
        {
            if (id != upwebapp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upwebapp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!upwebappExists(upwebapp.Id))
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
            return View(upwebapp);
        }

        // GET: upwebapp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upwebapp = await _context.upwebapp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upwebapp == null)
            {
                return NotFound();
            }

            return View(upwebapp);
        }

        // POST: upwebapp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upwebapp = await _context.upwebapp.FindAsync(id);
            _context.upwebapp.Remove(upwebapp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool upwebappExists(int id)
        {
            return _context.upwebapp.Any(e => e.Id == id);
        }
    }
}
