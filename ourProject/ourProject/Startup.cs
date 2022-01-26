using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ourProject.Models;

namespace ourProject//Hi Efrat! hope we'll have good luck in this project
    //Hi Nechame i hope to!
    //Last test!!!!!
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
            object p = services.AddDbContext<SeatOrganizerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SeatOrgenizer")));
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IEventDL, EventDL>();
            services.AddScoped<IEventBL, EventBL>();
            services.AddScoped<IGuestDL, GuestDL>();
            services.AddScoped<IGuestBL, GuestBL>();
            services.AddScoped<IPlacementDL, PlacementDL>();
            services.AddScoped<IPlacementBL, PlacementBL>();
            services.AddScoped<ICategoryDL, CategoryDL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ITableDL, TableDL>();
            services.AddScoped<IRatingDL, RatingDL>();
            services.AddScoped<IRatingBL, RatingBL>();
            services.AddScoped<IEventPerUserDL, EventPerUserDL>();

            services.AddResponseCaching();
           
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ourProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("the server is up");
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ourProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            //
            app.Map("/api", app1 =>
            {
                app1.UseRouting();
                app1.UseExceptionMiddleware();
                app1.UseRatingMiddleware();
                app1.UseAuthorization();

                app1.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
