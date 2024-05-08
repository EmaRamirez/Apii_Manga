using System.Configuration;
using Api_Tienda.Data;
using Api_Tienda.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DbTienda"))
);

builder.Services.AddScoped<IEditorialService, EditorialService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<IMDetailsService, MDetailsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//MapControllers es donde asignamos controladores enrutados de atributos
app.MapControllers();

app.Run();
