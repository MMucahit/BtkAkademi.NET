using ProductApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Configuration for AddDbConext =>> IoC
builder.Services.ConfigureDbContext(builder.Configuration);
//

// IoC
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
//

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
//

// Custom Extension
builder.Services.ConfigureIdentity();
//

// Custom Extension
builder.Services.ConfigureApplicationCookie();
//

// IoC => builder.Services.Configuration olarak method haline getirdik.
//builder.Services.AddDbContext<RepositoryContext>
//    (options => options.UseSqlServer
//    (builder.Configuration.GetConnectionString
//    ("sqlconnection")));
//
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute
    (
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
