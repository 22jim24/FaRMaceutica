using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;

namespace Farmaco.Servicios;

public class ServiceCliente(IReCliente repositorio)
{
public List<Cliente> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Cliente? BuscarPorDni(string dni)
    {
        return repositorio.BuscarPorDni(dni);
    }

    public List<Cliente> ListarClientesFrecuentes()
    {
        return repositorio.ListarTodos().Where(c => c.PuntosConsegudos >= 100).ToList();
    }

    public double CalcularPromedioPuntos()
    {
        List<Cliente> todos = repositorio.ListarTodos();
        if (todos.Count == 0)
        {
            return 0;
        }
        return todos.Average(c => c.PuntosConsegudos);
    }

    public bool PuntosSonValidos(int puntos)
    {
        return puntos >= 0;
    }

    public bool ExisteDni(string dni)
    {
        return repositorio.BuscarPorDni(dni) != null;
    }

    public Cliente Crear(CreateCliente request)
    {
        Cliente nuevo = new(request.Dni, request.Nombre, request.Apellido, request.Correo, request.Telefono, request.PuntosConseguidos);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Cliente? Actualizar(string dni, UpdateCliente request)
    {
        Cliente? cliente = repositorio.BuscarPorDni(dni);
        if (cliente == null)
        {
            return null;
        }

        cliente.Apellido = request.Apellido;
        cliente.Correo = request.Correo;
        cliente.Telefono = request.Telefono;
        cliente.SumarPuntos(request.PuntosConseguidos);
        return cliente;
    }

    public bool Eliminar(string dni)
    {
        return repositorio.EliminarPorDni(dni);
    }
}