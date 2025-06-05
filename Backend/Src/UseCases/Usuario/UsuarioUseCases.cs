using AppBackend.Entities;
namespace AppBackend.UseCases;

public class UsuarioUseCases: IUsuarioUseCases{
    public List<Object> GetUsuarios(){
        return Memoria.GetAll("Usuario");
    }
    public Object? GetUsuario(int id){
        return Memoria.Find(id, "Usuario");
    }
    public bool CreateUsuario(string nombre, string ci){
        return Memoria.Add(new Usuario(nombre, ci)) != -1;
    }
    public bool UpdateUsuario(Usuario usuario){
        return true;
    }
    public List<Inscripcion> GetInscripciones(int id){
        return Memoria.InscripcionUsuario(id);
    }
}