using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieCatalogue.Models;
using MovieCatalogue.Classes;

namespace MovieCatalogue.Data
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public static ConnectionSetting Setting { set; get; }

        public MovieDbContext()
            : base()
        {
        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Genre> Genres { set; get; }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<MovieType> MovieTypes { set; get; }

        public void CheckInitial()
        {
            var movieTypes = this.MovieTypes.ToList();
            if (movieTypes.Count == 0)
            {
                this.MovieTypes.AddRange(new MovieType[]
                {
                    new MovieType() { Name = "2D" },
                    new MovieType() { Name = "3D" },
                    new MovieType() { Name = "2D IMAX" },
                    new MovieType() { Name = "3D IMAX" },
                    new MovieType() { Name = "4DX" },
                    new MovieType() { Name = "N.T" },
                    new MovieType() { Name = "2D Festivals" },
                    new MovieType() { Name = "MX4D" },
                    new MovieType() { Name = "Barco Esc" },
                    new MovieType() { Name = "TV" },
                    new MovieType() { Name = "Hindi Dubbed" },
                    new MovieType() { Name = "Midnight 2D" },
                    new MovieType() { Name = "Midnight 3D" },
                    new MovieType() { Name = "Midnight 4DX" },
                    new MovieType() { Name = "Midnight MX4D" },
                    new MovieType() { Name = "Adjustment 2D" },
                    new MovieType() { Name = "Adjustment 3D" },
                    new MovieType() { Name = "Adjustment MX4D" },
                    new MovieType() { Name = "Special Shows" }
                });
                this.SaveChanges();
            }

            var genres = this.Genres.ToList();
            if (genres.Count == 0)
            {
                this.Genres.AddRange(new Genre[]
                {
                    new Genre() { Name = "Action" },
                    new Genre() { Name = "Biography" },
                    new Genre() { Name = "Crime" },
                    new Genre() { Name = "Family" },
                    new Genre() { Name = "Horror" },
                    new Genre() { Name = "Romance" },
                    new Genre() { Name = "Sports" },
                    new Genre() { Name = "War" },
                    new Genre() { Name = "Adventure" },
                    new Genre() { Name = "Comedy" },
                    new Genre() { Name = "Documentary" },
                    new Genre() { Name = "Fantasy" },
                    new Genre() { Name = "Thriller" },
                    new Genre() { Name = "Animation" },
                    new Genre() { Name = "Costume" },
                    new Genre() { Name = "Drama" },
                    new Genre() { Name = "History" },
                    new Genre() { Name = "Musical" },
                    new Genre() { Name = "Psychological" }
                });
                this.SaveChanges();
            }

            var movies = this.Movies.ToList();
            if (movies.Count == 0)
            {
                this.Movies.AddRange(new Movie[]
                {
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Comedy"), Name = "Citizen Soldier", Author = "Edward Abbey", Views = 124,IsReviewedMovie = true, Year = 2017,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/1.jpg",  ImageURL = "images/m13.jpg", Rate = 4.5,
                        IsNew = true , IsFeatured = false, IsTopRating = false, IsTopViewed = true, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Sports"), Name = "X-Men",Author = "Michele A'Court",Views = 3466, IsReviewedMovie = false, Year = 2011, 
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "3D"),
                        ShortDescription = "In 1977, paranormal investigators Ed (Patrick Wilson) and Lorraine Warren come out of a self-imposed sabbatical to travel to Enfield, a borough in north ...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/7.jpg", ImageURL = "images/m11.jpg", Rate = 2.5,
                        IsNew = true, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = true },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Family"), Name = "Greater",Author = "Edward Abbey",Views = 345,IsReviewedMovie = false, Year = 2010,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/1.jpg", ImageURL = "images/m12.jpg", Rate = 3.5,
                        IsNew = true , IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "History"), Name = "Light B/t Oceans",Author = "Michele A'Court",Views = 124,IsReviewedMovie = false, Year = 2008,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/1.jpg", ImageURL = "images/m7.jpg", Rate = 2,
                        IsNew = true , IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Sports"), Name = "The BFG",Author = "Tarek Mulla",Views = 6854,IsReviewedMovie = true, Year = 2017,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "Hindi Dubbed"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/4.jpg", ImageURL = "images/m8.jpg", Rate = 3.5,
                        IsNew = true, IsFeatured = false, IsTopRating = false, IsTopViewed = true, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Documentary"), Name = "Central Intelligence",Author = "Michele A'Court",Views = 46745,IsReviewedMovie = false, Year = 2007,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "3D IMAX"),
                        ShortDescription = "Bullied as a teen for being overweight, Bob Stone (Dwayne Johnson) shows up to his high school reunion looking fit and muscular. Claiming to be on a top-secret ....",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/4.jpg", ImageURL = "images/m9.jpg", Rate = 4.5,
                        IsNew = true, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = true },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Fantasy"), Name = "Don't Think Twice",Author = "Edward Abbey",Views = 4547,IsReviewedMovie = false, Year = 2006,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "3D IMAX"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/7.jpg", ImageURL = "images/m10.jpg", Rate = 1.5,
                        IsNew = true, IsFeatured = false , IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Fantasy"), Name = "Peter",Author = "Tarek Mulla",Views = 456,IsReviewedMovie = false, Year = 2017,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "Hindi Dubbed"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/7.jpg", ImageURL = "images/m17.jpg", Rate = 3.5,
                        IsNew = true, IsFeatured = false , IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Comedy"), Name = "God’s Compass",Author = "Michele A'Court",Views = 567576,IsReviewedMovie = false, Year = 2017,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "3D IMAX"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/7.jpg", ImageURL = "images/m15.jpg", Rate = 4,
                        IsNew = true, IsFeatured = true, IsTopRating = true, IsTopViewed = true, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Fantasy"), Name = "Bad Moms",Author = "Michele A'Court",Views = 679678,IsReviewedMovie = false, Year = 2005,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "3D IMAX"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/6.jpg", ImageURL = "images/m2.jpg", Rate = 2,
                        IsNew = false, IsFeatured = true , IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Family"), Name = "Jason Bourne",Author = "Lord Aberdeen",Views = 5969,IsReviewedMovie = false, Year = 2004,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "Hindi Dubbed"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/6.jpg", ImageURL = "images/m5.jpg", Rate = 3.5,
                        IsNew = false , IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Romance"), Name = "Rezort",Author = "Lord Aberdeen",Views = 4573,IsReviewedMovie = false, Year = 2003,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "MX4D"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/6.jpg", ImageURL = "images/m16.jpg", Rate = 4.5,
                        IsNew = false , IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Sports"), Name = "Peter",Author = "Tarek Mulla",Views = 4563,IsReviewedMovie = false, Year = 2002,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "MX4D"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/6.jpg", ImageURL = "images/m17.jpg", Rate = 3,
                        IsNew = false , IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "History"), Name = "ISRA 88",Author = "Lord Aberdeen",Views = 62222,IsReviewedMovie = false, Year = 2001,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "Hindi Dubbed"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/5.jpg", ImageURL = "images/m18.jpg", Rate = 4,
                        IsNew = false , IsFeatured = true, IsTopRating = false, IsTopViewed = true, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "War"), Name = "War Dogs",Author = "Lord Aberdeen",Views = 373,IsReviewedMovie = true, Year = 2007,
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/5.jpg", ImageURL = "images/m1.jpg", Rate = 3.5,
                        IsNew = false, IsFeatured = true, IsTopRating = true, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Drama"), Name = "The Other Side",Author = "Lord Aberdeen",Views = 76345,IsReviewedMovie = true, Year = 2018,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "MX4D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/5.jpg", ImageURL = "images/m14.jpg", Rate = 2.5,
                        IsNew = false, IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false  },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "History"), Name = "Civil War",Author = "Tarek Mulla",Views = 235,IsReviewedMovie = true, Year = 2006,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "MX4D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/5.jpg", ImageURL = "images/m19.jpg", Rate = 2.5,
                        IsNew = false, IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false  },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Sports"), Name = "The Secret Life of Pets",Author = "Edward Abbey",Views = 124,IsReviewedMovie = false, Year = 2012,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/3.jpg", ImageURL = "images/m20.jpg", Rate = 1.5,
                        IsNew = false, IsFeatured = true , IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Crime"), Name = "The Jungle Book",Author = "Edward Abbey",Views = 809,IsReviewedMovie = false, Year = 2011,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/2.jpg", ImageURL = "images/m21.jpg", Rate = 3.5,
                        IsNew = false, IsFeatured = true, IsTopRating = true, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false  },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Comedy"), Name = "Assassin's Creed 3",Author = "Edward Abbey",Views = 67,IsReviewedMovie = false, Year = 2007,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/3.jpg", ImageURL = "images/m22.jpg", Rate = 1.5,
                        IsNew = false, IsFeatured = true, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = true, IsShowInBanner = false  },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Crime"), Name = "Dead Island 2",Author = "Megan Abbott",Views = 52,IsReviewedMovie = false, Year = 2015,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        BannerImageURL = "images/2.jpg", ImageURL = "images/m23.jpg", Rate = 4.5,
                        IsNew = false, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = false },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Fantasy"), Name = "Tarzan",Author = "Tarek Mulla",Views = 252,IsReviewedMovie = false, Year = 2015,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "2D"),
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        ShortDescription = "Tarzan, having acclimated to life in London, is called back to his former home in the jungle to investigate the activities at a mining encampment.",
                        BannerImageURL = "images/5.jpg", ImageURL = "images/m4.jpg", Rate = 4.5,
                        IsNew = false, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = true },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Romance"), Name = "Maximum Ride",Author = "Megan Abbott",Views = 6234,IsReviewedMovie = false, Year = 2009,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "TV"),
                        ShortDescription = "Six children, genetically cross-bred with avian DNA, take flight around the country to discover their origins. Along the way, their mysterious past is ...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/2.jpg", ImageURL = "images/m4.jpg", Rate = 3.5,
                        IsNew = false, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = true },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Psychological"), Name = "Independence",Author = "Megan Abbott",Views = 6854,IsReviewedMovie = false, Year = 2017,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "TV"),
                        ShortDescription = "The fate of humanity hangs in the balance as the U.S. President and citizens decide if these aliens are to be trusted ...or feared...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/3.jpg", ImageURL = "images/m11.jpg", Rate = 2,
                        IsNew = false, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false, IsShowInBanner = true },
                    new Movie() { Genre = this.Genres.FirstOrDefault(x => x.Name == "Psychological"), Name = "Ice Age",Author = "Megan Abbott",Views = 262,IsReviewedMovie = true, Year = 2013,
                        ShowDate = DateTime.Now.AddDays(new Random((int)DateTime.Now.Ticks).Next(0, 1000)),CreationDate = DateTime.Now, MovieType = this.MovieTypes.FirstOrDefault(x => x.Name == "TV"),
                        ShortDescription = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet...",
                        Description = "In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet, In the film's epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet",
                        BannerImageURL = "images/6.jpg", ImageURL = "images/m11.jpg", Rate = 2,
                        IsNew = false, IsFeatured = false, IsTopRating = false, IsTopViewed = false, IsRecentlyAdded  = false , IsShowInBanner = true }
                });
                this.SaveChanges();
            }
        }
    }
}
