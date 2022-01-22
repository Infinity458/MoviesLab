﻿using Domain.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab.Models.ActorModels
{
    public class CreateActorModel
    {
        [Required(ErrorMessage = "Не указано полное имя")]
        public string Name { get; set; } = "";

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birth { get; set; }

        public int? GenderId { get; set; }
        public IEnumerable<SelectListItem> AvailableGenders { get; set; } = new List<SelectListItem>();
        public int? CityId { get; set; }
        public IEnumerable<SelectListItem> AvailableCities { get; set; } = new List<SelectListItem>();
    }
}
