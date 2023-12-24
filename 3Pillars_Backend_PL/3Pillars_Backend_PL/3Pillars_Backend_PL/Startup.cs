using _3Pillars_Backend_BLL.Services.Classes;
using _3Pillars_Backend_BLL.Services.Interface;
using _3Pillars_Backend_DAL.Data;
using _3Pillars_Backend_DAL.Entities.Identity;
using _3Pillars_Backend_PL.Helpers;
using _3Pillars_Backend_Repository.Repository.Class;
using _3Pillars_Backend_Repository.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL
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
            // Inject Controllers in .NET Core 
            services.AddControllers();

            // Inject DbContext from type AddressBookContext with ConnectionString 'DefaultConnection'
            services.AddDbContext<AddressBookContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // Inject SwaggerGen With OpenApiInfo 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "3Pillars_Backend_PL", Version = "v1" });
            });
            // Register (RequestLifeTime) or Types of Services 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddAutoMapper(typeof(MapperProfile));

            // Inject IdentityRole With EntityFramework 
            services.AddIdentity<User, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AddressBookContext>();

            // Inject Authentication With JWTBearer
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                   .AddJwtBearer(options =>
                   {
                       options.SaveToken = true;
                     
                       options.TokenValidationParameters = new TokenValidationParameters()
                       {
                           ValidateAudience = true,
                           ValidAudience = Configuration["JWT:ValidAudience"],
                           ValidateIssuer = true,
                           ValidIssuer = Configuration["JWT:ValidIssuer"],
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                           ValidateLifetime = true,

                       };
                   });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "3Pillars_Backend_PL v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
