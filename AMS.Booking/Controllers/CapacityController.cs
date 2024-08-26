using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmsBooking.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMST4_Carousel.MVC.Models;

namespace AMST4_Carousel.MVC.Controllers
{
    public class CapacityController : Controller
    {
        private readonly DataContext _context;

        public CapacityController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CapacityList()
        {
            var category = await _context.Capacity.ToListAsync();
            return View(category);
        }

        // GET: Capacity/Create
        public IActionResult CreateCapacity()
        {
            return View();
        }

        // POST: Capacity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCapacity(Capacity capacity)
        {
           
            {
                capacity.Id = Guid.NewGuid();
                _context.Add(capacity);
                await _context.SaveChangesAsync();
                return RedirectToAction("CapacityList");
            }
          
        }

        // GET: Capacity/Edit/5
        public async Task<IActionResult> EditCapacity(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Capacity = await _context.Capacity.FindAsync(id);
            if (Capacity == null)
            {
                return NotFound();
            }
            return View(Capacity);
        }

        // POST: Capacity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,Description,IsActive,CreateData")] Capacity capacity)
        {
            if (id != capacity.Id)
            {
                return NotFound();
            }

           
            {
                try
                {
                    _context.Update(capacity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacityExists(capacity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CapacityList");
            }
        
        }

        // GET: Capacity/Delete/5
        public async Task<IActionResult> DeleteCapacity(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Capacity = await _context.Capacity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Capacity == null)
            {
                return NotFound();
            }

            return View(Capacity);
        }

        // POST: Capacity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Capacity = await _context.Capacity.FindAsync(id);
            if (Capacity != null)
            {
                _context.Capacity.Remove(Capacity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("CapacityList");
        }

        private bool CapacityExists(Guid id)
        {
            return _context.Capacity.Any(e => e.Id == id);
        }
    }
}
