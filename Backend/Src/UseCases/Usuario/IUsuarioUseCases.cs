using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IUsuarioUseCases{
    public List<Object> GetUsuarios();
    public Object? GetUsuario(int id);
    public bool CreateUsuario(string nombre, string ci);
    public bool UpdateUsuario(Usuario usuario);
    public List<Inscripcion> GetInscripciones(int id);
}