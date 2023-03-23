using Microsoft.EntityFrameworkCore;
using Reto.API;
using Reto.Data.Models;
using Reto.Services.Interfaces;
using Reto.Services.Services;
using Reto.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RetoContext>(
options =>
		options.UseSqlServer(builder.Configuration["ConnectionStrings:Database"]).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
		ServiceLifetime.Transient);

builder.Services.AddAutoMapper(x => {
	x.AddProfile<AutoMap_VM_To_Model>();
	x.AddProfile<AutoMap_Model_To_VM>();
	x.AddMaps(typeof(Program));
});

builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IObjRespuesta, ObjRespuesta>();
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
