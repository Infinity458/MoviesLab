using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using BLL.Interfaces;
using BLL.Services;
using DAL.Repositories;
using Domain.RepositoryInterfaces;
using Domain.Enities;

namespace MoviesLab
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("MovieContext");

            services.AddDbContext<MovieContext>(ops => ops.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Actor>, ActorRepository>();
            services.AddScoped<IActorService, ActorService>();

            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IRepository<Director>, DirectorRepository>();
            services.AddScoped<IDirectorService, DirectorService>();

            services.AddScoped<IRepository<Gender>, GenderRepository>();
            services.AddScoped<IGenderService, GenderService>();

            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IRepository<Movie>, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IRepository<ProductionCompany>, ProductionCompanyRepository>();
            services.AddScoped<IProductionCompanyService, ProductionCompanyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
