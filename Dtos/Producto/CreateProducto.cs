namespace Farmaco.Dtos;
public class CreateProducto
{
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}