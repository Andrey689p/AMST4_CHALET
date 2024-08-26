using AmsBooking.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using AmsBooking.Context;
using Microsoft.EntityFrameworkCore;

namespace AmsBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly DataContext _context;

        public BookingController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> BookingList()
        {
            var Booking = await _context.Booking.Include(b => b.Chalet).ToListAsync();
            return View(Booking);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(Guid chaletId)
        {
            var chalet = await _context.Chalet.Include(p => p.Category).Include(p => p.Capacity).FirstOrDefaultAsync(x => x.Id == chaletId);

            if (chalet == null)
            {
                return NotFound();
            }

            var model = new Booking
            {
                ChaletId = chaletId,
                Chalet = chalet,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
                var chalet = _context.Chalet.Find(booking.ChaletId);
                if (chalet == null)
                {
                    return NotFound();
                }

                booking.TotalPrice = (booking.NumberOfDays * 100) + chalet.Price;
                _context.Booking.Add(booking);
                _context.SaveChanges();

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "Agendado Com sucesso!";
            return RedirectToAction("ChaletList", "Chalet");

        }
    }
}