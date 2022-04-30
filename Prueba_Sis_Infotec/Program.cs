using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prueba_Sis_Infotec;
using Prueba_Sis_Infotec.Models;
using Prueba_Sis_Infotec.Repositorio;
using Prueba_Sis_Infotec.Servicios;

var builder = WebApplication.CreateBuilder(args);

//AutoMapper - Mapeo de clases

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductoDomainServices, ProductoDomainServices>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddDbContext<Sistemas_InfotecContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});
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

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.MapControllers();

app.Run();
