using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enities
{
    public class Director : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
