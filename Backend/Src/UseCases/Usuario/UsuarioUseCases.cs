using AppBackend.Entities;
namespace AppBackend.UseCases;

public class UsuarioUseCases: IUsuarioUseCases{
    public List<Usuario> GetUsuarios(){
        return new List<Usuario>();
    }
    public Usuario GetUsuario(int id){
        return new Usuario();
    }
    public bool CreateUsuario(Usuario usuario){
        return true;
    }
    public bool UpdateUsuario(Usuario usuario){
        return true;
    }
}