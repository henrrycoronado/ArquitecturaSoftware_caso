using AppBackend.Entities;
namespace AppBackend.UseCases;

public class EventoUseCases: IEventoUseCases{
    public List<Object> GetEventos(){
        return Memoria.GetAll("Evento");
    }
    public Object? GetEvento(int id){
        return Memoria.Find(id, "Evento");
    }
    public bool CreateEvento(string Nombre, DateTime Fecha, int Capacidad, double? Costo){
        return Memoria.Add(new Evento(Nombre, Fecha, Capacidad, Costo))!=-1;
    }
    public bool UpdateEvento(Evento evento){
        return true;
    }
    public bool RegistrarEnEvento(int idEvento, string ciUsuario){
        var EventoResp = Memoria.Find(idEvento, "Evento");
        if(EventoResp != null){
            var Evento = (Evento)EventoResp;
            var UsuarioResp = Memoria.Find(Memoria.GetIdUser(ciUsuario), "Usuario");
            if(UsuarioResp != null){
                var Usuario = (Usuario)UsuarioResp;
                if(Memoria.AddInscripcionEvento(Evento.Id, Usuario)){
                    var IdPago = Memoria.Add(new Pago(Evento.Costo, new DateTime(), true)); //aqui asumire un pago automatico
                    var IdInscripcion = Memoria.Add(new Inscripcion(Usuario.Id, idEvento, true, IdPago));
                    if(IdInscripcion!=-1){
                        return true;
                    }
                }
            }
        }
        return false;
    }
}