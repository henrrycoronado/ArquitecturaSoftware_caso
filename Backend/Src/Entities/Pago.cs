namespace AppBackend.Entities;

public class Pago{
    public int Id { get; set; }
    public double? Monto { get; set; }
    public DateTime Fecha { get; set; }
    public bool Estado { get; set; }
    public Pago(double? monto, DateTime fecha, bool estado){
        Monto = monto;
        Fecha = fecha;
        Estado = estado;
    }
}