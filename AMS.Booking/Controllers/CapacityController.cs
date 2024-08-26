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
    }
}