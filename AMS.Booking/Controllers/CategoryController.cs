using AmsBooking.Context;
using AmsBooking.Models.Entities;
using AMST4_Carousel.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmsBooking.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _DataContext;
        public CategoryController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }
        public IActionResult CategoryList()
        {
            var categories = _DataContext.Category.ToList();
            return View(categories);
        }
    }
}
