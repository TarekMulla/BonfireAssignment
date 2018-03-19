using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalogue.ViewModels
{
    public class MovieViewModel
    {
        public Guid? GenerID { get; set; }
        public Guid? MovieTypeID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
