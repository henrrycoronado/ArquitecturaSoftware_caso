using AppBackend.Entities;
namespace AppBackend.UseCases;

public class InscripcionUseCases: IInscripcionUseCases{
    public List<Inscripcion> GetInscripciones(){
        return new List<Inscripcion>();
    }
    public Inscripcion GetInscripcion(int id){
        return new Inscripcion();
    }
    public bool CreateInscripcion(Inscripcion inscripcion){
        return true;
    }
    public bool UpdateInscripcion(Inscripcion inscripcion){
        return true;
    }
}