using Farmaco.Repositorios;
using Farmaco.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios (aquí irá la inyección de dependencias)
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Inyección de dependencias
builder.Services.AddSingleton<IReCliente, ReClienteRam>();
builder.Services.AddScoped<ServicioCliente>();

builder.Services.AddSingleton<IReEmpleado, ReEmpleadoRam>();
builder.Services.AddScoped<ServicioEmpleados>();

builder.Services.AddSingleton<IReProducto, ReProductoRam>();
builder.Services.AddScoped<ServicioProductos>();

builder.Services.AddSingleton<IReProveedor, ReProveedorRam>();
builder.Services.AddScoped<ServicioProveedores>();

builder.Services.AddSingleton<IReVenta, ReVentaRam>();
builder.Services.AddScoped<ServicioVentas>();

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
