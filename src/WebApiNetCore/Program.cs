using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace WebApiNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder() //Wire up ASP.NET Core hosting
                .UseKestrel() //What server do I want to use - kestrel is a cross-platform server
                .UseContentRoot(Directory.GetCurrentDirectory()) // Where the app is going to find MVC views
                .UseIISIntegration() //This app is going to run behind IIS. The web.config define a native 
                                     //module called aspNetCore that runs an IIS
                .UseStartup<Startup>() //The Startup define the actual application logic
                .Build();

            host.Run();
        }
    }
}
