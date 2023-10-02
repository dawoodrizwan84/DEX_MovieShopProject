using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Service.Implementation;
using DEX_MovieShopProject.Services.Abstract;
using DEX_MovieShopProject.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace DEX_MovieShopProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDbContext>(
            o => o
            .UseSqlServer(connectionString)
            );

            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
        

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}