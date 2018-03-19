using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalogue.ViewModels
{
    public class GenerViewModel
    {
        public Guid? GenerID { get; set; }
        public string Gener { get; set; }
        public int? Page { get; set; }
        public int? Count { get; set; }
    }

    public class MovieTypeViewModel
    {
        public Guid? TypeID { get; set; }
        public string Type { get; set; }
        public int? Page { get; set; }
        public int? Count { get; set; }
    }
}
