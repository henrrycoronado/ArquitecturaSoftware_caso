namespace AppBackend.Entities;
public class Inscripcion{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public int IdEvento { get; set; }
    public bool Estado { get; set; } 
    public int IdPago { get; set; }
    public Inscripcion(int idUsuario, int idEvento, bool estado, int idPago){
        IdUsuario = idUsuario;
        IdEvento = idEvento;
        Estado = estado;
        IdPago = idPago;
    }
}