using static v2_spotify_app.DotEnv;

// loading dotenv file in ENV
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
Load(dotenv);
// check if environment variables are present
string? clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
string? clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
if (clientId is null || clientSecret is null) throw new Exception("one or more spotify client credentials are null");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
