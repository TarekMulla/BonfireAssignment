using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogue.Data;
using MovieCatalogue.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MovieCatalogue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MovieCatalogue.Controllers
{
    public class MovieController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private MovieDbContext _context { set; get; }
        public MovieController(UserManager<ApplicationUser> userManager, MovieDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Name")]
        public IActionResult Index(string Name)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Name == Name);
            if (movie.Views == null) movie.Views = 0;
            movie.Views++;
            _context.SaveChanges();
            return View(movie);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Add(MovieViewModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var movie = new Movie();
                return View("~/Views/Movie/EditMovie.cshtml", movie);
            }
            else return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Update(Guid? ID)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var movie = _context.Movies.SingleOrDefault(x => x.ID == ID);
                if (movie != null)
                {
                    return View("~/Views/Movie/EditMovie.cshtml", movie);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfo([FromForm] Movie model, IFormFile file, IFormFile banner)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var movie = _context.Movies.SingleOrDefault(x => x.ID == model.ID);
                if (movie != null)
                {
                    movie.Name = model.Name;
                    movie.Description = model.Description;
                    movie.ShortDescription = model.ShortDescription;
                    movie.Author = model.Author;
                    movie.GenreID = model.GenreID;
                    movie.Author = model.Author;
                    movie.MovieTypeID = model.MovieTypeID;
                    movie.IsFeatured = model.IsFeatured;
                    movie.IsNew = model.IsNew;
                    movie.IsRecentlyAdded = model.IsRecentlyAdded;
                    movie.IsReviewedMovie = model.IsReviewedMovie;
                    movie.IsShowInBanner = model.IsShowInBanner;
                    movie.IsTopRating = model.IsTopRating;
                    movie.IsTopViewed = model.IsTopViewed;
                    movie.Rate = model.Rate;
                    movie.ShowDate = model.ShowDate;
                    movie.Year = model.Year;
                    movie.CreationDate = DateTime.Now;
                }
                else
                {
                    model.ApplicationUserID = user.Id;
                    model.Views = 0;
                    _context.Movies.Add(model);
                }
                if (file != null && file.Length != 0)
                {
                    var ImageURL = Path.Combine("Images/", Guid.NewGuid().ToString() + ".jpg");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImageURL);
                    var dir = Path.GetDirectoryName(path);
                    Directory.CreateDirectory(dir);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    model.ImageURL = ImageURL;
                }
                if (banner != null && banner.Length != 0)
                {
                    var BannerImageURL = Path.Combine("Images/", Guid.NewGuid().ToString() + ".jpg");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", BannerImageURL);
                    var dir = Path.GetDirectoryName(path);
                    Directory.CreateDirectory(dir);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await banner.CopyToAsync(stream);
                    }
                    model.BannerImageURL = BannerImageURL;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("OwnMovies");

            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(Guid? ID)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var movie = _context.Movies.SingleOrDefault(x => x.ID == ID);
                if (movie != null)
                {
                    _context.Movies.Remove(movie);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("OwnMovies");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> OwnMovies()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var data = _context.Movies.Include(x => x.Genre).Include(x => x.MovieType).Where(x => x.ApplicationUserID == user.Id);
                return View("~/Views/Movie/OwnMovies.cshtml", data);
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}
