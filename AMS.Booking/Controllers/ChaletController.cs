using AmsBooking.Context;
using AmsBooking.Models.Entities;
using AMST4_Carousel.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AMST4_Carousel.MVC.Controllers
{
    public class ChaletController : Controller
    {
        private readonly DataContext _DataContext;
        public ChaletController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }
        public async Task<IActionResult> ChaletList(Guid? categoryId, Guid? capacityId)
        {
            var chalets = _DataContext.Chalet.Include(p => p.Category).Include(p => p.Capacity).AsQueryable();

            if (categoryId.HasValue)
            {
                chalets = chalets.Where(c => c.CategoryId == categoryId.Value);
            }

            if (capacityId.HasValue)
            {
                chalets = chalets.Where(c => c.CapacityId == capacityId.Value);
            }

            ViewBag.Categories = await _DataContext.Category.ToListAsync();
            ViewBag.Capacities = await _DataContext.Capacity.ToListAsync();

            return View(await chalets.ToListAsync());
        }


    }
}