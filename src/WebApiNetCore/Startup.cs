using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApiNetCore
{
    public class Startup
    {
        //The main task of the contructor is setting up configuration getting the name value pair  out of
        // a different configuration sources like JSON files, XML files, enviromental variables, etc..
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setting up all of the services that I want to be made available to my app via 
            // dependency injection, in this example MVC is adding its services to the sevice collection
            // and making them available to every one
            services.AddMvc();
        }

        // This method sets up the HTTP request pipeline for our app.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            // We're using MVC middleware (MVC is built on top of generic routing middleware) and we just set up
            // MVC as route handler for the route middleware
            app.UseMvc();
        }
    }
}
