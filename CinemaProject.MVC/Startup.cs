using CinemaProject.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using D = CinemaProject.DAL;
using B = CinemaProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Common.Repositories;

namespace CinemaProject.MVC
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
            services.AddDbContext<CinemaContext>(ob => ob.UseSqlServer(
                Configuration.GetConnectionString("default")
                ));

            services.AddScoped<ICinemaPlaceRepository<D.Entities.CinemaPlace>, D.Repositories.CinemaPlaceService>();
            services.AddScoped<ICinemaPlaceRepository<B.Entities.CinemaPlace>, B.Repositories.CinemaPlaceService>();
            services.AddScoped<ICinemaRoomRepository<D.Entities.CinemaRoom>, D.Repositories.CinemaRoomService>();
            //services.AddScoped<ICinemaRoomRepository<B.Entities.CinemaRoom>, B.Repositories.CinemaRoomService>();
            services.AddScoped<IDiffusionRepository<D.Entities.Diffusion>, D.Repositories.DiffusionService>();
            services.AddScoped<B.Repositories.IDiffusionRepository, B.Repositories.DiffusionService>();
            services.AddScoped<IMovieRepository<D.Entities.Movie>, D.Repositories.MovieService>();
            services.AddScoped<IMovieRepository<B.Entities.Movie>, B.Repositories.MovieService>();

            // Enable CORS
            services.AddCors(options => options.AddPolicy("default", b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyMethod();
                b.AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("default");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cinema}/{action=Index}/{id?}");
            });
        }
    }
}
