using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Entities;
using EmployeeDirectoryAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeDirectoryAPI
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
            services.AddMvc();
            var connectionString = @"Server=db;Database=EmployeeDirectory;User=sa;Password=Your_password123;";//@"Server=localhost\SQLEXPRESS02;Database=EmployeeDirectoryDB01;Trusted_Connection=True";
            services.AddDbContext<EmployeeDbContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IGreetingsRepository, GreetingsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    throw new Exception("Sample exception");
            //});
        }
    }
}
