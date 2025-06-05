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

    public static int Add(object item){
        try
        {
            switch (item)
            {
                case Evento e:
                    _idEvento++;
                    e.Id = _idEvento;
                    Eventos.Add(e);
                    return _idEvento;
                case Usuario u:
                    _idUsuario++;
                    u.Id = _idUsuario;
                    Usuarios.Add(u);
                    return _idUsuario;
                case Inscripcion i:
                    _idInscripcion++;
                    i.Id = _idInscripcion;
                    Inscripciones.Add(i);
                    return _idInscripcion;
                case Pago p:
                    _idPago++;
                    p.Id = _idPago;
                    Pagos.Add(p);
                    return _idPago;
                default:
                    return -1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return -1;
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

    public static Object? Find(int id, string type){
        switch (type){
            case "Evento":
                return Eventos.Find(e => e.Id == id);
            case "Usuario":
                return Usuarios.Find(u => u.Id == id);
            case "Inscripcion":
                return Inscripciones.Find(i => i.Id == id);
            case "Pago":
                return Pagos.Find(p => p.Id == id);
            default:
                return null;
        }
    }
    public static List<Object> GetAll(string type){
        switch (type){
            case "Evento":
                return new List<Object>(Eventos);
            case "Usuario":
                return new List<Object>(Usuarios);
            case "Inscripcion":
                return new List<Object>(Inscripciones);
            case "Pago":
                return new List<Object>(Pagos);
            default:
                return new List<Object>();
        }
    }

    public static List<Inscripcion> InscripcionUsuario(int id){
        return Inscripciones.FindAll(i => i.IdUsuario == id);
    }

    public static int GetIdUser(string ci){
        var user = Usuarios.Find(u => u.Ci == ci);
        if(user != null){
            return user.Id;
        }return -1;
    }

    public static bool AddInscripcionEvento(int idEvento, Usuario user){
        for(int i = 0; i < Eventos.Count; i++){
            if(Eventos[i].Id == idEvento){
                if(Eventos[i].registros.Count < Eventos[i].Capacidad){
                    Eventos[i].registros.Add(user);
                    return true;
                }
            }
        }
        return false;
    }
}
