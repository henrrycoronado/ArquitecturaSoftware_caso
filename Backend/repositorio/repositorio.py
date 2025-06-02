from modelos.evento import Evento

class EventoRepositorioMemoria:
    def __init__(self):
        self.eventos = {}

    def agregar_evento(self, evento: Evento):
        self.eventos[evento.id] = evento

    def obtener_evento_por_id(self, evento_id: str) -> Evento:
        return self.eventos.get(evento_id)

    def guardar_evento(self, evento: Evento):
        self.eventos[evento.id] = evento
