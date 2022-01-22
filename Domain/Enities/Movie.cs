using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enities
{
    public class Movie : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public int? ProductionCompanyId { get; set; }
        public ProductionCompany ProductionCompany { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
    }
}
