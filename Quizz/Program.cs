using Microsoft.EntityFrameworkCore;
using Quizz.Models;
using System.Configuration;

namespace Quizz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // ou une autre durée
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<QuizContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuizContextConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}