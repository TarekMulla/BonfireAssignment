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
    public class GenerController : Controller
    {
        private MovieDbContext _context { set; get; }
        public GenerController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GenerName")]
        public async Task<IActionResult> Index(string GenerName)
        {
            if(string.IsNullOrWhiteSpace(GenerName) == true)
            {
                return RedirectToAction("Action", "Home");
            }
            var data = await _context.Movies.Where(x => x.Genre != null && x.Genre.Name == GenerName).ToListAsync();
            ViewBag.MovieCount = data.Count();
            ViewBag.Gener = GenerName;
            ViewBag.Page = 0;
            return View(data.Take(12));
        }

        [HttpPost]
        public async Task<IActionResult> Index(GenerViewModel viewModel)
        {
            if ((viewModel.GenerID == null  || viewModel.GenerID == Guid.Empty)
                && string.IsNullOrWhiteSpace(viewModel.Gener) == true)
            {
                return RedirectToAction("Action", "Home");
            }
            var data = _context.Movies.Where(x => x.GenreID == viewModel.GenerID || x.Genre.Name.Contains(viewModel.Gener));
            ViewBag.MovieCount = data.Count();
            if (string.IsNullOrWhiteSpace(viewModel.Gener) == false) ViewBag.Gener = viewModel.Gener;
            else ViewBag.Gener = _context.Genres.SingleOrDefault(x => x.ID == viewModel.GenerID)?.Name;
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
