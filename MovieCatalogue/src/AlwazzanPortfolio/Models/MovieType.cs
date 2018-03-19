using SmartLifeLtd.Data.Tables;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogue.Data
{
    public class MovieType : TableBase
    {
        public MovieType()
        {
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        [InverseProperty("MovieType")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
