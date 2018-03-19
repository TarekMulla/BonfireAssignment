using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogue.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieCatalogue.Controllers
{
    public class SearchController : Controller
    {
        private MovieDbContext _context { set; get; }
        public SearchController(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Search")]
        public IActionResult Index(string Search)
        {
            string[] keywords = Search.Split(' ');
            var movie = _context.Movies.Include(x => x.Genre).Include(x => x.MovieType)
                .Where(x => x.Name.Contains(Search) || x.Description.Contains(Search) || x.ShortDescription.Contains(Search));
            return View(movie);
        }
    }
}
