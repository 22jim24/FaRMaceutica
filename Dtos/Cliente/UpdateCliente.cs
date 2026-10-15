namespace Farmaco.Dtos;
public class UpdateCliente
{
    public string Apellido { get; set; } = "";
    public string Correo { get; set; } = "";
    public string Telefono { get; set; } = "";

    public int PuntosConseguidos { get; set; }
}
