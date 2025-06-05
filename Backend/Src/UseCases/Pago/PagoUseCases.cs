using AppBackend.Entities;
namespace AppBackend.UseCases;

public class PagoUseCases: IPagoUseCases{
    public List<Object> GetPagos(){
        return Memoria.GetAll("Pago");
    }
    public Object? GetPago(int id){
        return Memoria.Find(id, "Pago");
    }
    public bool CreatePago(Pago pago){
        return true;
    }
    public bool UpdatePago(Pago pago){
        return true;
    }
}