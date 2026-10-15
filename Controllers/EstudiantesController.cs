using Microsoft.AspNetCore.Mvc;
using SistemaNotas.Dtos;
using SistemaNotas.Modelos;
using SistemaNotas.Servicios;

namespace SistemaNotas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController(ServicioNotas servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Estudiante>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{dni}")]
    public ActionResult<Estudiante> BuscarPorDni(string dni)
    {
        Estudiante? estudiante = servicio.BuscarPorDni(dni);
        if (estudiante == null)
        {
            return NotFound($"No existe un estudiante con DNI {dni}");
        }
        return Ok(estudiante);
    }
    
    [HttpPost]
    public ActionResult<Estudiante> Crear(CrearEstudianteRequest request)
    {
        if (servicio.NotaEsValida(request.Nota) == false)
        {
            return BadRequest("La nota debe estar entre 0 y 20");
        }

        if (servicio.ExisteDni(request.Dni))
        {
            return Conflict($"Ya existe un estudiante con DNI {request.Dni}");
        }

        Estudiante nuevo = servicio.Crear(request);
        return Created($"/api/estudiantes/{nuevo.Dni}", nuevo);
    }

    [HttpPut("{dni}")]
    public ActionResult<Estudiante> Actualizar(string dni, ActualizarEstudianteRequest request)
    {
        if (servicio.NotaEsValida(request.Nota) == false)
        {
            return BadRequest("La nota debe estar entre 0 y 20");
        }

        Estudiante? actualizado = servicio.Actualizar(dni, request);
        if (actualizado == null)
        {
            return NotFound($"No existe un estudiante con DNI {dni}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{dni}")]
    public IActionResult Eliminar(string dni)
    {
        bool eliminado = servicio.Eliminar(dni);
        if (eliminado == false)
        {
            return NotFound($"No existe un estudiante con DNI {dni}");
        }

        return NoContent();
    }
}