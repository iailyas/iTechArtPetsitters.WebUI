using DomainNew.Interfaces;
using Infrastructure.Repositories;
using InfrastructureNew.EFDbContext;
using InfrastructureNew.Repositories;
using iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData;
using iTechArtPetsitters.WebUI.PetsittersData;
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
            //services.AddDbContext<EFMainDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));//set this on appsettings.json
            //services.AddDbContext<EFMainDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));//set this on appsettings.json
            //services.AddDbContext<EFMainDBContext>(options=>options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<EFMainDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<EFMainDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //repositories
            services.AddSingleton<IPetsitersData, MockPetsitterData>();
            services.AddTransient<IUserService, EFUserRepository>();
            services.AddTransient<IApplicationService, EFApplicationRepository>();
            services.AddTransient<IPetService, EFPetRepository>();
            services.AddTransient<IReviewService, EFReviewRepository>();
            services.AddTransient<IPetsittingService, EFPetsittingServiceRepository>();
            //services.AddTransient<IPetsitterRepository, EFPetsittingServiceRepository>();





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
