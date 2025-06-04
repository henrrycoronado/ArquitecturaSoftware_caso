using AppBackend.Entities;
namespace AppBackend.UseCases;

public class PagoUseCases: IPagoUseCases{
    public List<Pago> GetPagos(){
        return new List<Pago>();
    }
    public Pago GetPago(int id){
        return new Pago();
    }
    public bool CreatePago(Pago pago){
        return true;
    }
    public bool UpdatePago(Pago pago){
        return true;
    }
}