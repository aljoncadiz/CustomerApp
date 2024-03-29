﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CustomerApp.BusinessLogic;
using CustomerApp.BusinessLogic.Interface;
using CustomerApp.Infra;
using CustomerApp.Infra.Interface;
using CustomerApp.Service.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CustomerApp.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                    c.SwaggerDoc("v1", new OpenApiInfo
                        {
                                Title = "My API", Version = "v1",
                                Description = "A simple CustomerApp using ASP.NET Core Web API",
                                Contact = new OpenApiContact
                                {
                                    Name = "Aljon Rey Cadiz",
                                    Email = string.Empty,
                                    Url = new Uri("https://www.facebook.com/profile.php?id=100011406835142"),
                                },
                        }
                    );

                c.AddSecurityDefinition("auth",
                            new OpenApiSecurityScheme
                            {
                                In = ParameterLocation.Header,
                                Description = "Basic authentication header",
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey
                            });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "auth" }
                                    },
                                    new[] { "readAccess", "writeAccess" }
                                }
                            });

            });

            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // logging
            loggerFactory.AddSerilog();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Data>().As<IData>();
            builder.RegisterType<CustomerBusinessLogic>().As<ICustomerBusinessLogic>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
        }
    }
}
