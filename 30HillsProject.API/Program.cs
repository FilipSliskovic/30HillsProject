using _30HillsProject.API.Core;
using _30HillsProject.API.Extensions;
using _30HillsProject.Application.Loging;
using _30HillsProject.Application;
using _30HillsProject.Implementation.Logging;
using _30HillsProject.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Added
var settings = new AppSettings();

builder.Services.AddJwt(settings);
builder.Services.AddApplicationUser();
builder.Services.AddHttpContextAccessor();
builder.Services.AddUseCases();
builder.Configuration.Bind(settings);

builder.Services.AddSingleton<AppSettings>(settings);
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddHillsProjectDBContext(settings.ConnString);
builder.Services.AddTransient<IUseCaseLogger, EFUseCaseLogger>();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
//app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
