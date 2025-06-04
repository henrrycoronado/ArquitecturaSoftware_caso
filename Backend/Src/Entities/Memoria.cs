namespace AppBackend.Entities;

public static class Memoria
{
    private static int _idEvento = 0;
    private static int _idUsuario = 0;
    private static int _idInscripcion = 0;
    private static int _idPago = 0;

    public static List<Evento> Eventos = new List<Evento>();
    public static List<Usuario> Usuarios = new List<Usuario>();
    public static List<Inscripcion> Inscripciones = new List<Inscripcion>();
    public static List<Pago> Pagos = new List<Pago>();

    public static bool Add(object item){
        try
        {
            switch (item)
            {
                case Evento e:
                    _idEvento++;
                    e.Id = _idEvento;
                    Eventos.Add(e);
                    break;
                case Usuario u:
                    _idUsuario++;
                    u.Id = _idUsuario;
                    Usuarios.Add(u);
                    break;
                case Inscripcion i:
                    _idInscripcion++;
                    i.Id = _idInscripcion;
                    Inscripciones.Add(i);
                    break;
                case Pago p:
                    _idPago++;
                    p.Id = _idPago;
                    Pagos.Add(p);
                    break;
                default:
                    return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static bool Edit(object item){
        try
        {
            switch (item)
            {
                case Evento e:
                    var indexE = Eventos.FindIndex(ev => ev.Id == e.Id);
                    if (indexE >= 0){
                        Eventos[indexE] = e;
                    }
                    break;
                case Usuario u:
                    var indexU = Usuarios.FindIndex(us => us.Id == u.Id);
                    if (indexU >= 0){
                        Usuarios[indexU] = u;
                    }
                    break;
                case Inscripcion i:
                    var indexI = Inscripciones.FindIndex(ins => ins.Id == i.Id);
                    if (indexI >= 0){
                        Inscripciones[indexI] = i;
                    }
                    break;
                case Pago p:
                    var indexP = Pagos.FindIndex(pg => pg.Id == p.Id);
                    if (indexP >= 0){
                        Pagos[indexP] = p;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

}
