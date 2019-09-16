using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinemapp.Model
{
    public class Cast:BaseEntity
    {
        public string FullName { get { return FirstName + " " + LastName; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string FilmName { get; set; }
        public Guid? FilmId { get; set; }
        public virtual Film Film { get; set; }
        public string TvSerieName { get; set; }
        public Guid? TvSerieId { get; set; }
        public virtual TvSerie TvSerie { get; set; }
    }
}
