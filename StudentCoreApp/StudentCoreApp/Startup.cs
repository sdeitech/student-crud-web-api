using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repository;
using Service;
using StudentCoreApp.Extensions;
using StudentCoreApp.Mappings;
using System;

namespace StudentCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public Autofac.IContainer ApplicationContainer { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddAutoMapper(typeof(MappingProfile));
            // Create a Autofac container builder
            var builder = new ContainerBuilder();
            // Read service collection to Autofac
            builder.Populate(services);
            // build the Autofac container
            ApplicationContainer = builder.Build();
            ConfigureDependencyInjection(services);
        }
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            // Add application services and repository as scoped dependency.       
            services.AddTransient<IStudentService, StudentService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //, ILogger<Startup> log
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            //UseForwardedHeaders will forward proxy headers to the current request. This will help us during the Linux deployment.
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Student}/{action=GetAllStudents}");
            });            
        }
    }
}
