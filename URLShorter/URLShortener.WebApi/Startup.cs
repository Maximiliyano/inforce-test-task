using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Extensions;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace URLShortener.WebApi;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var migrationAssembly = typeof(UrlDbContext).Assembly.GetName().Name;
        services.AddDbContext<UrlDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DbConnection"),
                opt => opt.MigrationsAssembly(migrationAssembly)));
     
        services.AddControllersWithViews();
        
        services.RegisterCustomServices();
        services.RegisterCustomSingletons();
        services.RegisterAuthentication();
        
        services.AddDistributedMemoryCache();
        services.AddSession(opt =>
        {
            opt.IdleTimeout = TimeSpan.FromMinutes(120);
        });
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseSession();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();

        app.UseEndpoints(cfg =>
        {
            cfg.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}