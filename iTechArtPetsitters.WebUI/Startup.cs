using DomainNew.Interfaces;
using DomainNew.Service;
using DomainNew.Service.Interfaces;
using Infrastructure.Repositories;
using InfrastructureNew.EFDbContext;
using InfrastructureNew.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace iTechArtPetsitters.WebUI
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


            services.AddControllers();
            //contexts
            services.AddDbContext<EFMainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //repositories
            services.AddTransient<IApplicationRepository, EFApplicationRepository>();
            services.AddTransient<IPetRepository, EFPetRepository>();
            services.AddTransient<IPetsitterRepository, EFPetsitterRepository>();
            services.AddTransient<IPetsittingServiceRepository, EFPetsittingServiceRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            //services
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IPetsitterService, PetsitterService>();
            services.AddTransient<IPetsittingServiceService, PetsittingServiceService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IUserService, UserService>();







            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArtPetsitters.WebUI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iTechArtPetsitters.WebUI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

            });
        }
    }
}
