using Autofac;
using FluentValidation.AspNetCore;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using FrwkBootCampFidelidade.Infraestrutura.IOC.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Extract.API
{
    public class Startup
    {

        private readonly string DATABASE = Environment.GetEnvironmentVariable("Database");
        private readonly string DBUSER = Environment.GetEnvironmentVariable("DbUser");
        private readonly string DBPASSWORD = Environment.GetEnvironmentVariable("Password");
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DBContext>(options => options.UseSqlServer($"Data Source=localhost;Initial Catalog={DATABASE};Persist Security Info=True;User ID={DBUSER};Password={DBPASSWORD}"));

            services.AddDBInjector();

            services
                .AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FrwkBootCampFidelidade.Extract.API", Version = "v1" });
            });
        }
        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FrwkBootCampFidelidade.Extract.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSentryTracing();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
