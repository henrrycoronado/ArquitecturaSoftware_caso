using AppBackend.Entities;
namespace AppBackend.UseCases;

public class EventoUseCases: IEventoUseCases{
    public List<Evento> GetEventos(){
        return new List<Evento>();
    }
    public Evento GetEvento(int id){
        return new Evento();
    }
    public bool CreateEvento(Evento evento){
        return true;
    }
    public bool UpdateEvento(Evento evento){
        return true;
    }
}