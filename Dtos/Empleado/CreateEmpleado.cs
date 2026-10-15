namespace Farmaco.Dtos;

public class CreateEmpleado
{
    public string Dni { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Correo { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Cargo { get; set; } = "";
}
