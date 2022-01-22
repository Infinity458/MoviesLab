using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Filtres
{
    public class ActorFilter
    {
        public ICollection<int?> CitiesId { get; set; } = new List<int?>();
        public ICollection<int?> GendersId { get; set;} = new List<int?>();
        public ICollection<int> Ids { get; set; } = new List<int>();
    }
}
