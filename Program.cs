using SistemaNotas.Repositorios;
using SistemaNotas.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios (aquí irá la inyección de dependencias)
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Inyección de dependencias
builder.Services.AddSingleton<IRepositorioEstudiantes, RepositorioEstudiantesMemoria>();
builder.Services.AddScoped<ServicioNotas>();

var app = builder.Build();

// Configurar cómo se atienden las peticiones
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Encender la API
app.Run();
