using Domain.Enities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesLab.Models.DirectorModels;
using MoviesLab.Models;

namespace MoviesLab.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;
        private readonly IGenderService _genderService;

        public DirectorController(IDirectorService directorService, IGenderService genderService)
        {
            _directorService = directorService;
            _genderService = genderService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _directorService.GetAllDirectors());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateDirectorModel model = new CreateDirectorModel()
            {
                AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Director director)
        {
            if (!await VerifyDirector(director))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                CreateDirectorModel model = new CreateDirectorModel()
                {
                    Name = director.Name,
                    Birth = director.Birth,
                    GenderId = director.GenderId,
                    AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Create", model);
            }

            await _directorService.CreateDirector(director);

            return RedirectToAction(nameof(Info), new { id = director.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Director director = await _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }

            UpdateDirectorModel model = new UpdateDirectorModel()
            {
                Id = id,
                Name = director.Name,
                GenderId = director.GenderId,
                AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Director directorFromModel)
        {
            Director director = await _directorService.GetDirectorById(directorFromModel.Id);
            if (director == null)
            {
                return NotFound();
            }

            if (!await VerifyDirector(directorFromModel))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                UpdateDirectorModel model = new UpdateDirectorModel()
                {
                    Name = directorFromModel.Name,
                    GenderId = directorFromModel.GenderId,
                    AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Update", model);
            }

            director.Name = directorFromModel.Name;
            director.GenderId = directorFromModel.GenderId;
            await _directorService.UpdateDirector(director);

            return RedirectToAction(nameof(Info), new { id = director.Id });
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Director director = await _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _directorService.GetDirectorById(id) == null)
            {
                return NotFound();
            }

            await _directorService.DeleteDirector(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Director director = await _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        private async Task<bool> VerifyDirector(Director director)
        {
            return director != null &&
                !string.IsNullOrWhiteSpace(director.Name) && director.Name.Length <= 100 &&
                (director.GenderId == null || (await _genderService.GetGenderById(director.GenderId.Value)) != null);
        }
    }
}
