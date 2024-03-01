using CascadeExploration.Data;
using CascadeExploration.Services.AlbumServices;
using CascadeExploration.Services.ArtistServices;
using CascadeExploration.Services.Contracts;
using CascadeExploration.Services.TrackServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
       .AddDbContext<ApplicationDbContext>(
                    opt=>
                        opt
                        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlbumService,AlbumService>();
builder.Services.AddScoped<IArtistService,ArtistService>();
builder.Services.AddScoped<ITrackService, TrackService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
