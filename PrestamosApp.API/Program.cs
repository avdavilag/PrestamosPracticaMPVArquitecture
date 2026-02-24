using Microsoft.EntityFrameworkCore;
using PrestamosApp.Data.Context;
using PrestamosApp.Data.Repositories;
using PrestamosApp.Data.Interfaces;
using PrestamosApp.Presenter.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrestamosDbContext>(
options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITipoPrestamoRepository, TipoPrestamoRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<ClienteService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAoo", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
         .AllowAnyMethod();
    });
}); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactApp ");
app.UseAuthorization();
app.MapControllers();
app.Run();



