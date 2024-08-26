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
        
        
        [HttpPost]
    public async Task<IActionResult> AddChalet(Chalet chalet, IFormFile ImageUrl1, IFormFile ImageUrl2, IFormFile ImageUrl3, IFormFile ImageUrl4)
    {
         if (ImageUrl1 != null && ImageUrl1.Length > 0)
        {
            var filename1 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl1.FileName);
            var filepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", filename1);

            using (var stream = new FileStream(filepath1, FileMode.Create))
            {
                await ImageUrl1.CopyToAsync(stream);
            }

            chalet.ImageUrl1 = Path.Combine("images", "Chalet", filename1);
        }

        if (ImageUrl2 != null && ImageUrl2.Length > 0)
        {
            var filename2 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl2.FileName);
            var filepath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", filename2);

            using (var stream = new FileStream(filepath2, FileMode.Create))
            {
                await ImageUrl2.CopyToAsync(stream);
            }

            chalet.ImageUrl2 = Path.Combine("images", "Chalet", filename2);
        }

        if (ImageUrl3 != null && ImageUrl3.Length > 0)
        {
            var filename3 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl3.FileName);
            var filepath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", filename3);

            using (var stream = new FileStream(filepath3, FileMode.Create))
            {
                await ImageUrl3.CopyToAsync(stream);
            }

            chalet.ImageUrl3 = Path.Combine("images", "Chalet", filename3);
        }

        if (ImageUrl4 != null && ImageUrl4.Length > 0)
        {
            var filename4 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl4.FileName);
            var filepath4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", filename4);

            using (var stream = new FileStream(filepath4, FileMode.Create))
            {
                await ImageUrl4.CopyToAsync(stream);
            }

            chalet.ImageUrl4 = Path.Combine("images", "Chalet", filename4);
        }

        chalet.Id = Guid.NewGuid();
        _DataContext.Chalet.Add(chalet);
        await _DataContext.SaveChangesAsync();

        return RedirectToAction("ChaletList");
}

        [HttpGet]
        public IActionResult AddChalet()
        {
            var r = _DataContext.Category.ToList();
            var r2 = _DataContext.Capacity.ToList();
            ViewBag.Category = new SelectList(_DataContext.Category, "Id", "Description");
            ViewBag.Capacity = new SelectList(_DataContext.Capacity, "Id", "Description");
            return View();
        }

        [HttpGet]
        public IActionResult DeleteChalet(Guid id)
        {
            var Chalet = _DataContext.Chalet.Find(id);
            if (Chalet == null)
            {
                return NotFound();
            }
            return View(Chalet);
        }

        [HttpPost, ActionName("DeleteChalet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChaletConfirmed(Guid id)
        {
            var Chalet = await _DataContext.Chalet.FindAsync(id);
            if (Chalet == null)
            {
                return NotFound();
            }

            _DataContext.Chalet.Remove(Chalet);
            await _DataContext.SaveChangesAsync();

            return RedirectToAction("ChaletList");

        }

        public async Task<IActionResult> EditChalet(Guid id, Chalet chalet, IFormFile image)
        {
            if (id != chalet.Id)
            {
                return NotFound();
            }



            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            var UrlImage = Path.Combine("images", "Chalet", fileName);

            if (!string.IsNullOrEmpty(chalet.ImageUrl1))
            {
                var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Chalet", chalet.ImageUrl1);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            chalet.ImageUrl1 = UrlImage;


            _DataContext.Update(chalet);
            await _DataContext.SaveChangesAsync();
            return RedirectToAction(nameof(ChaletList));


        }

    }


}

