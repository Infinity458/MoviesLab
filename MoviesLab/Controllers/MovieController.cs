using Domain.Enities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesLab.Models.MovieModels;
using MoviesLab.Models;
using BLL.Filtres;

namespace MoviesLab.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IDirectorService _directorService;
        private readonly IProductionCompanyService _productionCompanyService;

        public MovieController(IMovieService movieService, IActorService actorService, IGenreService genreService, IDirectorService directorService, IProductionCompanyService productionCompanyService)
        {
            _movieService = movieService;
            _actorService = actorService;
            _genreService = genreService;
            _directorService = directorService;
            _productionCompanyService = productionCompanyService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetAllMovies());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateMovieModel model = new CreateMovieModel()
            {
                AvailableActors = (await _actorService.GetAllActors()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableGenres = (await _genreService.GetAllGenres()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableDirectors = (await _directorService.GetAllDirectors()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableProductionCompanies = (await _productionCompanyService.GetAllProductionCompanies()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                ActorFilter = new ActorFilter()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Movie movie, [FromForm] ActorFilter actorFilter)
        {
            if (!await VerifyMovie(movie))
            {
                return BadRequest();
            }

            if (!await VerifyDistinctMovieName(movie.Name))
            {
                ModelState.AddModelError("Name", "Такой фильм уже есть в базе");
            }

            if (!ModelState.IsValid)
            {
                CreateMovieModel model = new CreateMovieModel()
                {
                    Name = movie.Name,
                    Budget = movie.Budget,
                    DirectorId = movie.DirectorId,
                    ProductionCompanyId = movie.ProductionCompanyId,
                    GenreId = movie.GenreId,
                    AvailableActors = (await _actorService.GetAllActors()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = actorFilter.Ids.Contains(e.Id)
                    }),
                    AvailableGenres = (await _genreService.GetAllGenres()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                    }),
                    AvailableDirectors = (await _directorService.GetAllDirectors()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    }),
                    AvailableProductionCompanies = (await _productionCompanyService.GetAllProductionCompanies()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    }),
                };

                return View("Create", model);
            }

            movie.Actors = await _actorService.GetActorsById(actorFilter);
            await _movieService.CreateMovie(movie);

            return RedirectToAction(nameof(Info), new { id = movie.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Movie movie = await _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            ActorFilter actorFilter = new ActorFilter()
            {
                Ids = movie.Actors.Select(e => e.Id).ToList(),
            };

            UpdateMovieModel model = new UpdateMovieModel()
            {
                Id = id,
                Name = movie.Name,
                Budget = movie.Budget,
                GenreId = movie.GenreId,
                DirectorId = movie.DirectorId,
                ProductionCompanyId = movie.ProductionCompanyId,
                ActorFilter = actorFilter,
                AvailableActors = (await _actorService.GetAllActors()).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name,
                    Selected = actorFilter.Ids.Contains(e.Id)
                }),
                AvailableGenres = (await _genreService.GetAllGenres()).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }),
                AvailableDirectors = (await _directorService.GetAllDirectors()).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }),
                AvailableProductionCompanies = (await _productionCompanyService.GetAllProductionCompanies()).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Movie movieFromModel, [FromForm] ActorFilter actorFilter)
        {
            Movie movie = await _movieService.GetMovieById(movieFromModel.Id);
            if (movie == null)
            {
                return NotFound();
            }

            if (!await VerifyMovie(movieFromModel))
            {
                return BadRequest();
            }

            if (!await VerifyDistinctMovieName(movieFromModel.Name, movieFromModel.Id))
            {
                ModelState.AddModelError("Name", "Такой фильм уже есть в базе");
            }

            if (!ModelState.IsValid)
            {
                UpdateMovieModel model = new UpdateMovieModel()
                {
                    Id = movieFromModel.Id,
                    Name = movieFromModel.Name,
                    Budget = movieFromModel.Budget,
                    GenreId = movieFromModel.GenreId,
                    DirectorId = movieFromModel.DirectorId,
                    ProductionCompanyId = movieFromModel.ProductionCompanyId,
                    ActorFilter = actorFilter,
                    AvailableActors = (await _actorService.GetAllActors()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = actorFilter.Ids.Contains(e.Id)
                    }),
                    AvailableGenres = (await _genreService.GetAllGenres()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    }),
                    AvailableDirectors = (await _directorService.GetAllDirectors()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    }),
                    AvailableProductionCompanies = (await _productionCompanyService.GetAllProductionCompanies()).Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    }),
                };

                return View("Update", model);
            }


            ICollection<Actor> actors = await _actorService.GetActorsById(actorFilter);
            movie.Name = movieFromModel.Name;
            movie.Budget = movieFromModel.Budget;
            movie.GenreId = movieFromModel.GenreId;
            movie.DirectorId = movieFromModel.DirectorId;
            movie.Actors = actors;
            movie.ProductionCompanyId = movieFromModel.ProductionCompanyId;
            await _movieService.UpdateMovie(movie);

            return RedirectToAction(nameof(Info), new { id = movie.Id });
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Movie movie = await _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _movieService.GetMovieById(id) == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovie(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Movie movie = await _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        private async Task<bool> VerifyMovie(Movie movie)
        {
            if (movie == null)
                return false;

            return !string.IsNullOrWhiteSpace(movie.Name) && movie.Name.Length <= 100 &&
                1 <= movie.Budget && movie.Budget <= int.MaxValue &&
                (movie.GenreId == null || (await _genreService.GetGenreById(movie.GenreId.Value)) != null) &&
                (movie.DirectorId == null || (await _directorService.GetDirectorById(movie.DirectorId.Value)) != null)&&
                (movie.ProductionCompanyId == null || (await _productionCompanyService.GetProductionCompanyById(movie.ProductionCompanyId.Value))!= null);
        }

        private async Task<bool> VerifyDistinctMovieName(string name, int id = 0)
        {
            if (name == null)
                return false;

            IEnumerable<int> moviesId = (await _movieService.GetMoviesByName(name)).Select(e => e.Id);
            return !moviesId.Any() || moviesId.Contains(id);
        }
    }
}
