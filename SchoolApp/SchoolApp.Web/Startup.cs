using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SchoolApp.Web.DataProvider;
using SchoolApp.Models;
using Microsoft.OpenApi.Models;


namespace SchoolApp.Web
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MySchoolAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllers();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddMvc();
            services.AddTransient<ITeachersDataProvider, TeachersDataProvider>();
            services.AddTransient<IStudentsDataProvider, StudentsDataProvider>();
            services.AddTransient<ISubjectsDataProvider, SubjectsDataProvider>();
            services.AddTransient<IClassesDataProvider, ClassesDataProvider>();
            
            services.AddAuthentication()
             .AddGoogle(options =>
             {
                IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["Authentication:Google:ClientId"];
                options.ClientSecret = googleAuthNSection["Authentication:Google:ClientSecret"];
             })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "School API");

                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}