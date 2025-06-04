using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IUsuarioUseCases{
    public List<Usuario> GetUsuarios();
    public Usuario GetUsuario(int id);
    public bool CreateUsuario(Usuario usuario);
    public bool UpdateUsuario(Usuario usuario);
}