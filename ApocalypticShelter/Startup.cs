﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Repositories;
using ApocalypticShelter.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using ApocalypticShelter.Services.Interfaces;
using ApocalypticShelter.Services;
using ApocalypticShelter.Data;

namespace ApocalypticShelter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "ApocalypticShelter API",
                        Version = "v1",
                        Description = "An API for a Post Apocalyptic Shelter",
                        Contact = new Contact
                        {
                            Name = "Mateus Costa",
                            Url = "https://github.com/mateuscosta"
                        }
                    });

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string XMLDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                c.IncludeXmlComments(XMLDocPath);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            #region Dependency Injection
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionService, TransactionService>();

            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IResourceService, ResourceService>();

            services.AddTransient<IShelterRepository, ShelterRepository>();
            services.AddTransient<IShelterService, ShelterService>();

            services.AddTransient<IShelterStockRepository, ShelterStockRepository>();
            services.AddTransient<IShelterStockService, ShelterStockService>();

            services.AddTransient<ISurvivorRepository, SurvivorRepository>();
            services.AddTransient<ISurvivorService, SurvivorService>();

            services.AddScoped<StoreDataContext, StoreDataContext>();

            #endregion
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseCors("AllowAll");

            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApocalypticShelter API");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
