from modelos.usuario import Usuario
from repositorios.evento_repositorio_memoria import EventoRepositorioMemoria

class RegistroEventoService:
    def __init__(self, repo: EventoRepositorioMemoria):
        self.repo = repo

    def registrar_usuario(self, evento_id: str, usuario: Usuario):
        evento = self.repo.obtener_evento_por_id(evento_id)
        if not evento:
            raise Exception("Evento no encontrado")
        evento.inscribir_usuario(usuario)
        self.repo.guardar_evento(evento)
        return evento.inscripciones
