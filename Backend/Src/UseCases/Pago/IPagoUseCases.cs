using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IPagoUseCases{
    public List<Pago> GetPagos();
    public Pago GetPago(int id);
    public bool CreatePago(Pago pago);
    public bool UpdatePago(Pago pago);
}