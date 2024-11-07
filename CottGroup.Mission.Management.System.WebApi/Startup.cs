using AutoMapper;
using CottGroup.Mission.Management.System.Core.Filters;
using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.Impl;
using CottGroup.Mission.Management.System.Services.Company;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Impl;
using CottGroup.Mission.Management.System.Services.Mapping;
using CottGroup.Mission.Management.System.Services.MissionComponents;
using CottGroup.Mission.Management.System.Services.MissionComponents.Impl;
using CottGroup.Mission.Management.System.Services.ProjectComponents;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Impl;
using CottGroup.Mission.Management.System.Services.TokenComponents;
using CottGroup.Mission.Management.System.Services.TokenComponents.Impl;
using CottGroup.Mission.Management.System.Services.UserComponents;
using CottGroup.Mission.Management.System.Services.UserComponents.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace CottGroup.Mission.Management.System.WebApi
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
            services.AddMvcCore(opt => opt.Filters.Add(typeof(GlobalExceptionFilter)));
            
            AddDbContext(services); 
            AddJwtConfiguration(services);
            AddRepositories(services);
            AddServices(services);  
            AddSwaggerConfiguration(services);
            AddMapper(services);

            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

        }
        public void AddSwaggerConfiguration(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CottGroup.Mission.Management.System.WebApi", Version = "v1" });
            });
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
        }
        public void AddDbContext(IServiceCollection services)
        {
            string infrastructereAsseembly = Assembly.GetAssembly(typeof(Program)).GetName().Name;
            services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(
                "Server=127.0.0.1;Port=5432;Database=CottGroup;User Id=postgres;Password=123456;",
                opt => opt.SetPostgresVersion(new Version("9.6")).MigrationsAssembly(infrastructereAsseembly))); 
        }
        public void AddMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(s => s.AddProfile<RegisterMapping>());
            services.AddScoped(s => config.CreateMapper());
        }
        public void AddServices(IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IMissionService, MissionService>();
        } 
        public void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
        public void AddJwtConfiguration(IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = Configuration["JwtSettings:Issuer"],
               ValidAudience = Configuration["JwtSettings:Audience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"]))
           };
       });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("CompanyManagerPolicy", policy => policy.RequireRole("Supervisor"));
            }); 
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CottGroup.Mission.Management.System.WebApi v1"));
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
