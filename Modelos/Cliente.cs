namespace Farmaco.Modelos;

public class Cliente : Persona
{
    public int PuntosConsegudos { get; private set; }
    public Cliente(string dni, string nombre, string apellido, string correo,
    string telefono,int puntosConsegudos) : base(dni, nombre, apellido, correo, telefono)
    {
        SumarPuntos(puntosConsegudos);
    }

    public void SumarPuntos(int puntosAdicionales)
        {
            if (puntosAdicionales < 0)
            {
                throw new ArgumentException("Los puntos a sumar no pueden ser negativos.");
            }
            PuntosConsegudos += puntosAdicionales;
        }

 
    public override string ObtenerRol() => "cliente";
}