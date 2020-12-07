using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhoneNrLists.Data;
using PhoneNrLists.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace PhoneNrLists
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_config["DefaultConnection"]));
            services.AddSwaggerGen((options)=>
            {
                options.SwaggerDoc("v1", new Info { Title = "PhoneBook API", Version = "v1" });
            });
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

            var swaggerOption = new swaggerOptions();
            _config.GetSection(nameof(swaggerOptions)).Bind(swaggerOption);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
