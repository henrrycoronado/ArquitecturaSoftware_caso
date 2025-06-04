using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IInscripcionUseCases{
    public List<Inscripcion> GetInscripciones();
    public Inscripcion GetInscripcion(int id);
    public bool CreateInscripcion(Inscripcion inscripcion);
    public bool UpdateInscripcion(Inscripcion inscripcion);
}