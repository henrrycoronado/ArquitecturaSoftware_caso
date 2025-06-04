using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IEventoUseCases{
    public List<Evento> GetEventos();
    public Evento GetEvento(int id);
    public bool CreateEvento(Evento evento);
    public bool UpdateEvento(Evento evento);
}