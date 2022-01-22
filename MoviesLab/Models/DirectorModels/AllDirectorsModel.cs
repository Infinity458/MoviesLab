using Domain.Enities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MoviesLab.Models.DirectorModels
{
    public class AllDirectorsModel
    {
        public ICollection<Director> Directors { get; set; } = new List<Director>();
        public IEnumerable<SelectListItem> AvailableGenders { get; set; } = new List<SelectListItem>();
    }
}
