using Domain.Enities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesLab.Models.ActorModels;
using MoviesLab.Models;
using BLL.Filtres;

namespace MoviesLab.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IGenderService _genderService;
        private readonly ICityService _cityService;

        public ActorController(IActorService actorService, IGenderService genderService, ICityService cityService)
        {
            _actorService = actorService;
            _genderService = genderService;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _actorService.GetAllActors());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateActorModel model = new CreateActorModel()
            {
                AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableCities = (await _cityService.GetAllCities()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Actor actor)
        {
            if (!await VerifyActor(actor))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                CreateActorModel model = new CreateActorModel()
                {
                    Name = actor.Name,
                    Birth = actor.Birth,
                    GenderId = actor.Gender?.Id,
                    CityId = actor.City?.Id,
                    AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                    AvailableCities = (await _cityService.GetAllCities()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Create", model);
            }

            await _actorService.CreateActor(actor);

            return RedirectToAction(nameof(Info), new { id = actor.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Actor actor = await _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }

            UpdateActorModel model = new UpdateActorModel()
            {
                Id = id,
                Name = actor.Name,
                Birth = actor.Birth,
                GenderId = actor.GenderId,
                CityId = actor.CityId,
                AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableCities = (await _cityService.GetAllCities()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Actor actorFromModel)
        {
            Actor actor = await _actorService.GetActorById(actorFromModel.Id);
            if (actor == null)
            {
                return NotFound();
            }

            if (!await VerifyActor(actorFromModel))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                UpdateActorModel model = new UpdateActorModel()
                {
                    Name = actorFromModel.Name,
                    Birth = actorFromModel.Birth,
                    GenderId = actorFromModel.GenderId,
                    CityId = actorFromModel.CityId,
                    AvailableGenders = (await _genderService.GetAllGenders()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                    AvailableCities = (await _cityService.GetAllCities()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Update", model);
            }

            actor.Name = actorFromModel.Name;
            actor.Birth = actorFromModel.Birth;
            actor.GenderId = actorFromModel.GenderId;
            actor.CityId = actorFromModel.CityId;
            await _actorService.UpdateActor(actor);

            return RedirectToAction(nameof(Info), new { id = actor.Id });
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Actor actor = await _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _actorService.GetActorById(id) == null)
            {
                return NotFound();
            }
            await _actorService.DeleteActor(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Actor actor = await _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        private async Task<bool> VerifyActor(Actor actor)
        {
            return actor != null &&
                !string.IsNullOrWhiteSpace(actor.Name) && actor.Name.Count() <= 100 &&
                !string.IsNullOrWhiteSpace(actor.Birth.ToString()) && actor.Birth.ToString().Count() <= 30 &&
                (actor.GenderId == null || await _genderService.GetGenderById(actor.GenderId.Value) != null)&&
                (actor.CityId == null || await _cityService.GetCityById(actor.CityId.Value) != null);
        }
    }
}
