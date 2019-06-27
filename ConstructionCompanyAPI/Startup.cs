using System;
using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompany.BR.Specifications;
using ConstructionCompany.BR.Users;
using ConstructionCompany.BR.Worksheets;
using ConstructionCompanyAPI.Security;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddAuthorization();


            ConfigureServicesCommon(services);
        }
        
        // this one takes precedence over 'ConfigureServices' if env=test
        public void ConfigureTestServices(IServiceCollection services)
        {
            // we omit authorization here
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();
            
            ConfigureServicesCommon(services);
        }

        private void ConfigureServicesCommon(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<Mapper>(), AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Construction company API", Version = "v1" });
//                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IService<ConstructionSite, object>, BaseService<ConstructionSite, object, ConstructionSiteAllRelatedDataSpecification>>();
            services.AddScoped<IService<Material, object>, BaseService<Material, object, MaterialAllRelatedDataSpecification>>();
            services.AddScoped<IService<Task, object>, BaseService<Task, object, TasksAllRelatedDataSpecification>>();
            services.AddScoped<IService<Worker, object>, BaseService<Worker, object, WorkerAllRelatedDataSpecification>>();
            services.AddScoped<IService<Worksheet, object>, WorksheetService>();
            services.AddScoped<IService<ConstructionSiteManager, object>, BaseService<ConstructionSiteManager, object, ConstructionSiteManagerSpecification>>();
            services.AddScoped<IService<User, object>, BaseService<User, object, UserAllRelatedDataSpecification>>();
            
            services.AddScoped<ICRUDService<ConstructionSite, object>, BaseCRUDService<ConstructionSite, object, ConstructionSiteAllRelatedDataSpecification>>();
            services.AddScoped<ICRUDService<Material, object>, BaseCRUDService<Material, object, MaterialAllRelatedDataSpecification>>();
            services.AddScoped<ICRUDService<Task, object>, BaseCRUDService<Task, object, TasksAllRelatedDataSpecification>>();
            services.AddScoped<ICRUDService<Worker, object>, BaseCRUDService<Worker, object, WorkerAllRelatedDataSpecification>>();
            services.AddScoped<ICRUDService<Worksheet, object>, WorksheetService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserTypeService<Worker>, BaseUserTypeService<Worker, WorkerAllRelatedDataSpecification>>();
            services.AddScoped<IUserTypeService<ConstructionSiteManager>, BaseUserTypeService<ConstructionSiteManager, ConstructionSiteManagerSpecification>>();
            services.AddScoped<IUserTypeService<Manager>, BaseUserTypeService<Manager, ManagerSpecification>>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<ConstructionCompanyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("local")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            //app.UseRouting();

            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            
            app.UseMvc();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
