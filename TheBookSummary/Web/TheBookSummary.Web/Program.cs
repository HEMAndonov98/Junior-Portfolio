namespace TheBookSummary.Web;

using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheBookSummary.Data;
using TheBookSummary.Data.Common;
using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.Identity;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Data.Repositories;
using TheBookSummary.Data.Seeding;
using TheBookSummary.Services;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Services.Data;
using TheBookSummary.Services.Mapping;
using TheBookSummary.Services.Messaging;
using TheBookSummary.Web.ViewModels;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        Configure(app);
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

        services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
            .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        services.Configure<CookiePolicyOptions>(
            options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        services.AddSingleton(AutoMapperConfig.MapperInstance);

        services.AddControllersWithViews(
                options => { options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); })
            .AddRazorRuntimeCompilation();
        services.AddRazorPages();
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton(configuration);
        services.AddHttpContextAccessor();

        // Data repositories
        services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IDeletableEntityRepository<Book>), typeof(EfDeletableEntityRepository<Book>));
        services.AddScoped(typeof(IDeletableEntityRepository<Rating>), typeof(EfDeletableEntityRepository<Rating>));
        services.AddScoped(typeof(IDeletableEntityRepository<Comment>), typeof(EfDeletableEntityRepository<Comment>));
        services.AddScoped<IDbQueryRunner, DbQueryRunner>();

        // Application services
        services.AddTransient<ICommentService, CommentService>();
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IRatingService, RatingService>();
        services.AddTransient<IEmailSender, NullMessageSender>();
        services.AddTransient<ISettingsService, SettingsService>();
    }

    private static void Configure(WebApplication app)
    {
        // Seed data on application startup
        using (var serviceScope = app.Services.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
            new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter()
                .GetResult();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
    }
}
