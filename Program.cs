using AnimalPlaceProject.Data;
using AnimalPlaceProject.Services;
using AnimalPlaceProject.Services.AnimalRepository;
using AnimalPlaceProject.Services.BlogRepository;
using AnimalPlaceProject.Services.CategoryRepository;
using AnimalPlaceProject.Services.CommentRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
 
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;



builder.Services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));


builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer("Data Source=(localdb)\\AspNetCoreProject;Initial Catalog=MyDb;Integrated Security=True")); 
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AuthenticationContext>();




builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();


using (var scope = app.Services.CreateScope())
{
	var ctx = scope.ServiceProvider.GetRequiredService<MyContext>();
	var ctx2 = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
	ctx.Database.EnsureDeleted();
	ctx.Database.EnsureCreated();
	ctx2.Database.EnsureDeleted();
	ctx2.Database.EnsureCreated();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    
    var adminUser = await userManager.FindByNameAsync("admin");
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "admin"
        };
        await userManager.CreateAsync(adminUser, "Admin123!");
    }
}


if(app.Environment.IsStaging() || app.Environment.IsProduction())
{
	app.UseExceptionHandler("/Error/Index");
}


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute("Default", "{controller=Home}/{action=Index}");





app.Run();
