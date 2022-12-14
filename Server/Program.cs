using System.Text.Json.Serialization;
using DataContext.Postgresql;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load(builder.Environment.IsDevelopment() ? "development.env" : "production.env"); //  To load .env files

// Add services to the container.
builder.Services.AddMHIdleContext();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddSpaStaticFiles(config => { config.RootPath = "dist"; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "5000"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

//  Uncomment if https will be needed (leaving Heroku for ex.)
// app.UseHttpsRedirection();

app.MapControllers();

app.UseSpaStaticFiles();

app.UseSpa(config =>
{
    if (app.Environment.IsDevelopment())
    {
        config.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
    }
});

app.Run();