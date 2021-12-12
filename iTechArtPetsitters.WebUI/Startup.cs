using AutoMapper;
using Domain.Commands.ApplicationCommand;
using Domain.Commands.PetCommand;
using Domain.Commands.PetsitterCommand;
using Domain.Commands.PetsittingJobCommand;
using Domain.Commands.ReviewCommand;
using Domain.Commands.UserInfoCommand;
using Domain.Extensions;
using Domain.LoggerManager;
using DomainNew.Commands;
using DomainNew.Interfaces;
using DomainNew.Service;
using DomainNew.Service.Interfaces;
using Infrastructure.Repositories;
using InfrastructureNew.EFDbContext;
using InfrastructureNew.Repositories;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.ApplicationView;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsitterView;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsittingJobView;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.UserView;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;

namespace iTechArtPetsitters.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserUpdateProfile());
                mc.AddProfile(new ApplicationMapProfile());
                mc.AddProfile(new PetMapProfile()); 
                mc.AddProfile(new PetsitterMapProfile()); 
                mc.AddProfile(new PetsittingJobMapProfile());
                mc.AddProfile(new ReviewMapProfile());
                mc.AddProfile(new UserInfoMapProfile());
                mc.AddProfile(new ApplicationViewMapProfile());

                //Views for controllers
                mc.AddProfile(new ApplicationViewMapProfile());
                mc.AddProfile(new PetsitterViewMapProfile());
                mc.AddProfile(new PetsittingJobViewMapProfile());
                mc.AddProfile(new PetViewMapProfile());
                mc.AddProfile(new ReviewViewMapProfile());
                mc.AddProfile(new UserViewMapProfile());



            });
          
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);          
            //logger
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddControllers();
            services.AddLogging();
            //services.ConfigureLoggerService();
            //contexts
            services.AddDbContext<EFMainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //repositories
            services.AddTransient<IApplicationRepository, EFApplicationRepository>();
            services.AddTransient<IPetRepository, EFPetRepository>();
            services.AddTransient<IPetsitterRepository, EFPetsitterRepository>();
            services.AddTransient<IPetsittingJobRepository, EFPetsittingServiceRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            //services
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IPetsitterService, PetsitterService>();
            services.AddTransient<IPetsittingJobService, PetsittingJobService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IUserService, UserService>();




            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArtPetsitters.WebUI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
           
            //Error handling middleware
            
            
            if (env.IsDevelopment())
            {
                //error handling
               
                app.UseExceptionHandler("/error-development");
                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iTechArtPetsitters.WebUI v1"));
            }
            else
            {
               app.UseExceptionHandler("/error");
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            // app.ConfigureExceptionHandler(logger);
            //for custom viewing exeptions JSON
            app.ConfigureCustomExceptionMiddleware();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

            });
        }
    }
}
