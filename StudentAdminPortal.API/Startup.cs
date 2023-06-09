﻿using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<StudentAdminContext>(option => 
            option.UseSqlServer(configRoot.GetConnectionString("StudentAdminPortalDb")));
            services.AddScoped<IStudentRepository, SqlStudentRepository>();
            services.AddAutoMapper(typeof(Startup).Assembly);
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
