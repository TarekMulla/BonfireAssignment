using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogue.ViewModels;
using MovieCatalogue.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieCatalogue.Controllers
{
    public class TypeController : Controller
    {
        private MovieDbContext _context { set; get; }
        public TypeController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet("TypeName")]
        public async Task<IActionResult> Index(string TypeName)
        {
            if(string.IsNullOrWhiteSpace(TypeName) == true)
            {
                return RedirectToAction("Action", "Home");
            }
            var data = await _context.Movies.Where(x => x.MovieType != null && x.MovieType.Name == TypeName).ToListAsync();
            ViewBag.MovieCount = data.Count();
            ViewBag.MovieType = TypeName;
            ViewBag.Page = 0;
            return View(data.Take(12));
        }

        [HttpPost]
        public async Task<IActionResult> Index(MovieTypeViewModel viewModel)
        {
            if ((viewModel.TypeID == null  || viewModel.TypeID == Guid.Empty)
                && string.IsNullOrWhiteSpace(viewModel.Type) == true)
            {
                return RedirectToAction("Action", "Home");
            }
            var data = _context.Movies.Where(x => x.MovieTypeID == viewModel.TypeID || x.MovieType.Name.Contains(viewModel.Type));
            ViewBag.MovieCount = data.Count();
            if (string.IsNullOrWhiteSpace(viewModel.Type) == false) ViewBag.MovieType = viewModel.Type;
            else ViewBag.MovieType = _context.MovieTypes.SingleOrDefault(x => x.ID == viewModel.TypeID)?.Name;
            ViewBag.Page = viewModel.Page;
            try
            {
                var returnedData = await data.Skip((viewModel.Page ?? 0) * (viewModel.Count ?? 10))
                                .Take(viewModel.Count ?? 12).ToListAsync();

                return Json(returnedData.Select(x => new
                                {
                                    Name = x.Name,
                                    Rate = x.Rate,
                                    ImageURL = x.ImageURL,
                                    IsNew = x.IsNew,
                                    Year = x.Year
                                }));
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
    }
}
