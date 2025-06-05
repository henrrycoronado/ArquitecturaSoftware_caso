using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IPagoUseCases{
    public List<Object> GetPagos();
    public Object? GetPago(int id);
    public bool CreatePago(Pago pago);
    public bool UpdatePago(Pago pago);
}