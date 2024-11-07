using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.Impl;
using CottGroup.Mission.Management.System.Services.Company;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Impl;
using CottGroup.Mission.Management.System.Services.MissionComponents;
using CottGroup.Mission.Management.System.Services.MissionComponents.Impl;
using CottGroup.Mission.Management.System.Services.ProjectComponents;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Impl;
using CottGroup.Mission.Management.System.Services.TokenComponents;
using CottGroup.Mission.Management.System.Services.TokenComponents.Impl;
using CottGroup.Mission.Management.System.Services.UserComponents;
using CottGroup.Mission.Management.System.Services.UserComponents.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace CottGroup.Mission.Management.System.AuthService
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CottGroup.Mission.Management.System.AuthService", Version = "v1" });
            });
;

            services.AddTransient<IUserRepository, UserRepository>();
          
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CottGroup.Mission.Management.System.AuthService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
