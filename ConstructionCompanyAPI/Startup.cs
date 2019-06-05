using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompany.BR.Workers.Implementation;
using ConstructionCompany.BR.Workers.Interfaces;
using ConstructionCompany.BR.Worksheets.Implementation;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mapper = ConstructionCompanyAPI.Mappers.Mapper;

namespace ConstructionCompanyAPI
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
            services.AddAutoMapper(cfg => cfg.AddProfile<Mapper>());
            
            services.AddDbContext<ConstructionCompanyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("local")));

            services.AddScoped<IWorksheetService, WorksheetService>();
            services.AddScoped<IWorkersService, WorkersService>();
            services.AddScoped<ITasksService, TasksService>();
            
            services.AddScoped<IService<ConstructionSite, object>, BaseService<ConstructionSite, object>>();
            
            services.AddScoped<ICRUDService<ConstructionSite, object>, BaseCRUDService<ConstructionSite, object>>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers()
                .AddNewtonsoftJson();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Construction company API", Version = "v1" });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
