using FirmaData.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Projekt.Intranet.Report;
using QuestPDF.Infrastructure;
using Serilog;

namespace Projekt.Intranet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Start aplikacji");

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                builder.Services.AddDbContext<FormaContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("FormaContext")
                        ?? throw new InvalidOperationException("Connection string 'FormaContext' not found.")));

                builder.Services.AddControllersWithViews();
                QuestPDF.Settings.License = LicenseType.Community;
                builder.Services.AddScoped<ExcelExportService>();

                var app = builder.Build();

                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Logowanie}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Aplikacja zakończyła działanie z błędem");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
