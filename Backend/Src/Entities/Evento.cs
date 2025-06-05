namespace AppBackend.Entities;

public class Evento{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int Capacidad { get; set; }
    public double? Costo { get; set; }
    public List<Usuario> registros { get; set; } = new List<Usuario>();
    public Evento(string Nombre, DateTime Fecha, int Capacidad, double? Costo){
        this.Nombre = Nombre;
        this.Fecha = Fecha;
        this.Capacidad = Capacidad;
        this.Costo = Costo;
    }
}