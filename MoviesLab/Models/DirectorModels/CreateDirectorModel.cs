using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesLab.Models.DirectorModels
{
    public class CreateDirectorModel
    {
        [Required(ErrorMessage = "Не указано полное имя")]
        public string Name { get; set; } = "";

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birth { get; set; }

        public int? GenderId { get; set; }
        public IEnumerable<SelectListItem> AvailableGenders { get; set; } = new List<SelectListItem>();
    }
}
