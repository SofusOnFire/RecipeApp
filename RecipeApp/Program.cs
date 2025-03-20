using Services;
using Domain.Interfaces;
using RecipeApp.Components;
using DAL;

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

            //Dal services
            builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
            builder.Services.AddSingleton<IProduceLineRepository, ProduceLineRepository>();
			builder.Services.AddSingleton<IProduceRepository, ProduceRepository>();
            builder.Services.AddSingleton<IUnitRepositry, UnitRepository>();

            //Bll services
            builder.Services.AddSingleton<IProduceService, ProduceService>();
            builder.Services.AddSingleton<IRecipeService, RecipeService>();
            builder.Services.AddSingleton<IUserProduceService, UserProduceService>();
            builder.Services.AddSingleton<IProduceLineService, ProduceLineService>();
			builder.Services.AddSingleton<IAdminProduceService, AdminProduceService>();

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
