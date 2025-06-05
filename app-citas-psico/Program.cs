using app_citas_psico.Data;
using app_citas_psico.PatronRepository.IRepository;
using app_citas_psico.PatronRepository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var environmentName = builder.Configuration.GetSection("Environment:Name").Value;

/*
 * Aquí agregamos el servicio de ApplicationDbContext, que es la clase que representa el contexto de la base de datos. 
 */
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conecction_Default"), sqlOptions =>
    {
        sqlOptions.CommandTimeout(150); // 150 segundos = 2.5 minutos
    }));

/*
 * Aquí agregamos el servicios de unidad de trabajo (UnitOfWork)
 * El AddScoped permite que la instancia del servicio se cree una vez y se pueda seguir usando las veces que se requiera.
 */
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (environmentName == "P")
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

if (environmentName == "T")
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
