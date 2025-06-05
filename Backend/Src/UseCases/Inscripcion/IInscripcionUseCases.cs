using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IInscripcionUseCases{
    public List<Object> GetInscripciones();
    public Object? GetInscripcion(int id);
    public bool CreateInscripcion(Inscripcion inscripcion);
    public bool UpdateInscripcion(Inscripcion inscripcion);
}