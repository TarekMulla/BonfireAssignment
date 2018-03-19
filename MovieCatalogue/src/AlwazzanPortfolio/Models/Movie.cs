using MovieCatalogue.Models;
using SmartLifeLtd.Data.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogue.Data
{
    public class Movie : TableBase
    {
        public Movie()
        {
        }
        public string Name { get; set; }
        public int? Year { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTopViewed { get; set; }
        public bool IsTopRating { get; set; }
        public bool IsRecentlyAdded { get; set; }
        public bool IsShowInBanner { get; set; }
        public bool IsReviewedMovie { get; set; }
        public double? Rate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public DateTime? ShowDate { get; set; }
        public string Author { get; set; }
        public int? Views { get; set; }

        #region Application User
        public string ApplicationUserID { set; get; }
        /*[ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { set; get; }*/
        #endregion

        #region Genre
        public Guid? GenreID { set; get; }
        [ForeignKey("GenreID")]
        public virtual Genre Genre { set; get; }
        #endregion

        #region Movie Type
        public Guid? MovieTypeID { set; get; }
        [ForeignKey("MovieTypeID")]
        public virtual MovieType MovieType { set; get; }
        #endregion

        public string ImageURL { get; set; }
        public string BannerImageURL { get; set; }
    }
}
