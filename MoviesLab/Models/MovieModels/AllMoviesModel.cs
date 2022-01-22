using Domain.Enities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab.Models.MovieModels
{
    public class AllMoviesModel
    {
        public ICollection<Movie> Movies { get; set;} = new List<Movie>();

        public IEnumerable<SelectListItem> AvailableGenres { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableDirectors { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableActors { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableProductionCompanies { get; set; } = new List<SelectListItem>();
    }
}
