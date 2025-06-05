using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IEventoUseCases{
    public List<Object> GetEventos();
    public Object? GetEvento(int id);
    public bool CreateEvento(string Nombre, DateTime Fecha, int Capacidad, double? Costo);
    public bool UpdateEvento(Evento evento);
    public bool RegistrarEnEvento(int idEvento, string ciUsuario);
}