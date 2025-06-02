from datetime import datetime
from typing import List
from modelos.usuario import Usuario

class Evento:
    def __init__(self, id: str, nombre: str, fecha: datetime, costo: float, capacidad: int):
        self.id = id
        self.nombre = nombre
        self.fecha = fecha
        self.costo = costo
        self.capacidad = capacidad
        self.inscripciones: List[Usuario] = []

    def esta_lleno(self):
        return len(self.inscripciones) >= self.capacidad

    def es_evento_pasado(self):
        return self.fecha < datetime.now()

    def inscribir_usuario(self, usuario: Usuario):
        if self.es_evento_pasado():
            raise Exception("No se puede inscribir a un evento pasado")
        if self.esta_lleno():
            raise Exception("El evento ha alcanzado su capacidad máxima")
        if any(u.ci == usuario.ci for u in self.inscripciones):
            raise Exception("El usuario ya está registrado en este evento")
        self.inscripciones.append(usuario)
