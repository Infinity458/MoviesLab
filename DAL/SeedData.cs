using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SeedData
    {
        public static void Initialize(MovieContext context)
        {
            if (!context.Genders.Any())
            {
                ICollection<Gender> Genders = new List<Gender>()
                {
                    new Gender()
                    {
                        Name = "Мужской",
                    },
                    new Gender()
                    {
                        Name = "Женский",
                    },
                };
                context.Genders.AddRange(Genders);
                context.SaveChanges();

                ICollection<Country> Countries = new List<Country>()
                {
                    new Country()
                    {
                        Name = "Россия",
                        Cities = new List<City>()
                        {
                            new City()
                            {
                                Name = "Воронеж",
                            },
                            new City()
                            {
                                Name = "Москва",
                            },
                        },
                    },
                    new Country()
                    {
                        Name = "США",
                        Cities = new List<City>()
                        {
                            new City()
                            {
                                Name = "Манхэттен",
                            },
                            new City()
                            {
                                Name = "Лос-Анджелес",
                            },
                        },
                    },
                };
                context.Countries.AddRange(Countries);
                context.SaveChanges();

                ICollection<Genre> Genres = new List<Genre>()
                {
                    new Genre()
                    {
                        Name = "Комедия",
                    },
                    new Genre()
                    {
                        Name = "Фантастика",
                    },
                };
                context.Genres.AddRange(Genres);
                context.SaveChanges();

                ICollection<ProductionCompany> ProductionCompanies = new List<ProductionCompany>()
                {
                    new ProductionCompany()
                    {
                        Name = "Paramount Pictures",
                    },
                    new ProductionCompany()
                    {
                        Name = "Legendary Pictures",
                    },
                };
                context.ProductionCompanies.AddRange(ProductionCompanies);
                context.SaveChanges();

                ICollection<Actor> Actors = new List<Actor>()
                {
                    new Actor()
                    {
                        Name = "Тимоти Шаламе",
                        Birth = new DateTime(1995, 12, 27, 00,00,00),
                        GenderId = Genders.ElementAt(0).Id,
                        CityId = Countries.ElementAt(1).Cities.ElementAt(0).Id,
                    }
                };
                context.Actors.AddRange(Actors);
                context.SaveChanges();

                ICollection<Director> Directors = new List<Director>()
                {
                    new Director()
                    {
                        Name = "Дени Вильнёв",
                        Birth = new DateTime(1967, 10, 03, 00,00,00),
                        GenderId = Genders.ElementAt(0).Id,
                    },

                    new Director()
                    {
                        Name = "Лана Вачовски",
                        Birth = new DateTime(1965, 06, 21, 00,00,00),
                        GenderId = Genders.ElementAt(1).Id,
                    },
                };
                context.Directors.AddRange(Directors);
                context.SaveChanges();

                ICollection<Movie> Movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Name = "Дюна",
                        Budget = 397000000,
                        DirectorId = Directors.ElementAt(0).Id,
                        GenreId = Genres.ElementAt(1).Id,
                        ProductionCompanyId = ProductionCompanies.ElementAt(1).Id,
                        Actors = new List<Actor>()
                        {
                            Actors.ElementAt(0)
                        },
                    },
                };
                context.Movies.AddRange(Movies);
                context.SaveChanges();
            }
        }
    }
}
