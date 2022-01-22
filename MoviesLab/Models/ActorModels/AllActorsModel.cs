using BLL.Filtres;
using Domain.Enities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab.Models.ActorModels
{
    public class AllActorsModel
    {
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public IEnumerable<SelectListItem> AvailableCities { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableGenders { get; set; } = new List<SelectListItem>();
        public ActorFilter ActorFilter { get; set; } = new ActorFilter();
    }
}