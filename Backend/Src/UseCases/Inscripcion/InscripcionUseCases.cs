using AppBackend.Entities;
namespace AppBackend.UseCases;

public class InscripcionUseCases: IInscripcionUseCases{
    public List<Object> GetInscripciones(){
        return Memoria.GetAll("Inscripcion");
    }
    public Object? GetInscripcion(int id){
        return Memoria.Find(id, "Inscripcion");
    }
    public bool CreateInscripcion(Inscripcion inscripcion){
        return true;
    }
    public bool UpdateInscripcion(Inscripcion inscripcion){
        return true;
    }
}