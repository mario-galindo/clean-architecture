using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.API.Filters;
using FluentValidation.AspNetCore;
using SocialMedia.API.Validators;

namespace SocialMedia.API
{
    public class Startup
    {
        private string _SocialMediaKey = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _SocialMediaKey = Configuration["ConnectionStrings:SocialMedia"]; 
            
            services.AddControllers();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddDbContext<SocialMediaContext>(options =>
                options.UseSqlServer(_SocialMediaKey));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMedia.API", Version = "v1" });
            });
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<PostValidator>());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMedia.API v1"));
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
