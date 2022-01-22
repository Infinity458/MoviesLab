using BLL.Filtres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab.Models.MovieModels
{
    public class UpdateMovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Не указан бюджет фильма")]
        public int Budget { get; set; } = 0;

        public int? DirectorId { get; set; }
        public int? ProductionCompanyId { get; set; }
        public int? GenreId { get; set; }
        public ActorFilter ActorFilter { get; set; } = new ActorFilter();
        public IEnumerable<SelectListItem> AvailableActors { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableDirectors { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableGenres { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableProductionCompanies { get; set; } = new List<SelectListItem>();
    }
}
