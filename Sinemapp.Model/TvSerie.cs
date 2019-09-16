using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinemapp.Model
{
    public class TvSerie:BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public Genre Genre { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
    }
}
