using AppSpace.Infrastructure;
using AppSpace.Application;
using AppSpace.Application.Cinema.Interfaces;
using AppSpace.Application.Cinema.Services;
using AppSpace.Application.Genres.Interfaces;
using AppSpace.Application.Genres.Services;
using AppSpace.Application.TvShows.Interfaces;
using AppSpace.Application.TvShows.Services;
using AppSpace.Application.Documentaries.Interfaces;
using AppSpace.Application.Documentaries.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ITvShowService, TvShowService>();
builder.Services.AddScoped<IDocumentaryService, DocumentaryService>();

builder.Services
    .AddInfrastructure(configuration)
    .AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
