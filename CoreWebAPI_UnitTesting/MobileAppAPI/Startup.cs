using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MobileAppAPI.Repository.Implementation;
using MobileAppAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI
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

            services.AddControllers();
            //services.AddSingleton<IEmployee, EmployeeRepository>();
            services.AddAutoMapper(typeof(Startup)); //
            services.AddTransient<IEmployee, EmpDbRepository>();
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLConnection"))
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MobileAppAPI", Version = "v1",
                    Description="Created for Demo",
                    Contact = new OpenApiContact()
                    {
                        Name = "Asif",
                        Email = "asif@example.com",
                        Url = new Uri("https://asifalisayyad.blogspot.com/2021/05/part-8-ef-core-in-web-api.html")
                    },
                    License =new OpenApiLicense()
                    {
                        Name="API_Demo",
                        Url=new Uri("http://www.google.com")
                    }               
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MobileAppAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
