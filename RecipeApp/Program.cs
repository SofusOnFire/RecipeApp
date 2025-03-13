using Services;
using Domain.Interfaces;
using RecipeApp.Components;
using DAL;
using Domain.Models;
using DAL.OldRepositories;

namespace RecipeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddBlazorBootstrap();
            // All our DAL interfaces
            builder.Services.AddSingleton<IRecipeRepository, RecipeEntityFramework>();
            builder.Services.AddSingleton<IProduceLineRepository, ProduceLineRepository>();
			builder.Services.AddSingleton<IProduceRepository, ProduceRepositoryEntityFramework>();

            // All out BLL interfaces
            builder.Services.AddSingleton<IProduceService, ProduceService>();
            builder.Services.AddSingleton<IRecipeService, RecipeService>();
            builder.Services.AddSingleton<IUserProduceService, UserProduceService>();
            builder.Services.AddSingleton<IProduceLineService, ProduceLineService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
