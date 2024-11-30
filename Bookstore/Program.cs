using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookstore.Data;
using BookStore.Models;
using FluentAssertions.Common;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
namespace Bookstore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookstoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreContext") ?? throw new InvalidOperationException("Connection string 'BookstoreContext' not found.")));

            builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BookstoreContext>();



            // Add services to the container.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));

            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    // Initialize Roles and Users
                    //UserRoleInitializer.InitializeAsync(services).Wait();

                    // Seed book data
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while attempting to seed the database.");
                }
            }

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

            app.UseSession();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Store}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
