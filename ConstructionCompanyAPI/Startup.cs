using System;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ConstructionCompany;
using ConstructionCompany.BR;
using ConstructionCompany.BR.Tasks;
using ConstructionCompany.BR.Users;
using ConstructionCompany.BR.Workers;
using ConstructionCompany.BR.Worksheets;
using ConstructionCompany.Specifications;
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
                .AddAuthorization()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );


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

            services.AddScoped<IService<ConstructionSite, ConstructionSiteSearch>, BaseService<ConstructionSite, ConstructionSiteSearch, ConstructionSiteAllRelatedDataSpecification>>();
            services.AddScoped<IService<Material, MaterialSearch>, BaseService<Material, MaterialSearch, MaterialSpecification>>();
            services.AddScoped<IService<Equipment, EquipmentSearch>, BaseService<Equipment, EquipmentSearch, EquipmentSpecification>>();
            services.AddScoped<IService<Task, TaskSearch>, BaseService<Task, TaskSearch, TaskSpecification>>();
            services.AddScoped<IService<Worksheet, WorksheetSearch>, WorksheetService>();
            services.AddScoped<IService<ConstructionSiteManager, UserSearch>, BaseService<ConstructionSiteManager, UserSearch, ConstructionSiteManagerSpecification>>();
            services.AddScoped<IService<User, object>, BaseService<User, object, UserAllRelatedDataSpecification>>();
            services.AddScoped<IWorkersSuggestionEngine, WorkersSuggestionEngine>();
            
            services.AddScoped<ICRUDService<ConstructionSite, ConstructionSiteSearch>, BaseCRUDService<ConstructionSite, ConstructionSiteSearch, ConstructionSiteAllRelatedDataSpecification>>();
            services.AddScoped<ICRUDService<Material, MaterialSearch>, BaseCRUDService<Material, MaterialSearch, MaterialSpecification>>();
            services.AddScoped<ICRUDService<Equipment, EquipmentSearch>, BaseCRUDService<Equipment, EquipmentSearch, EquipmentSpecification>>();
            services.AddScoped<ICRUDService<Task, TaskSearch>, TasksService>();
            services.AddScoped<ICRUDService<Worksheet, WorksheetSearch>, WorksheetService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserTypeService<Worker>, BaseUserTypeService<Worker, WorkerAllRelatedDataSpecification>>();
            services.AddScoped<IUserTypeService<ConstructionSiteManager>, BaseUserTypeService<ConstructionSiteManager, ConstructionSiteManagerSpecification>>();
            services.AddScoped<IUserTypeService<Manager>, BaseUserTypeService<Manager, ManagerSpecification>>();
            
            services.AddScoped<IUserTypeRetriever, UserTypeRetriever>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<ConstructionCompanyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("local")));
            
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<Mapper>();
                cfg.AddCollectionMappers();
                cfg.UseEntityFrameworkCoreModel<ConstructionCompanyContext>();
            }, AppDomain.CurrentDomain.GetAssemblies());
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

//            app.UseHttpsRedirection();


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
