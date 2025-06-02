from fastapi import FastAPI, HTTPException
from datetime import datetime
from typing import List
from pydantic import BaseModel
import uuid

# --- ENTITIES ---
# carpeta: domain/entities
class Usuario(BaseModel):
    nombre: str
    ci: str

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

# --- REPOSITORY INTERFACES ---
# carpeta: domain/repositories
class EventoRepository:
    def obtener_evento_por_id(self, evento_id: str) -> Evento:
        raise NotImplementedError

    def guardar_evento(self, evento: Evento):
        raise NotImplementedError

# --- USE CASE ---
# carpeta: domain/use_cases
class RegistrarUsuarioEnEvento:
    def __init__(self, repo: EventoRepository):
        self.repo = repo

    def ejecutar(self, evento_id: str, usuario: Usuario) -> List[Usuario]:
        evento = self.repo.obtener_evento_por_id(evento_id)
        if not evento:
            raise Exception("Evento no encontrado")

        evento.inscribir_usuario(usuario)
        self.repo.guardar_evento(evento)
        return evento.inscripciones

# --- REPO IMPLEMENTATION ---
# carpeta: infrastructure/repositories_in_memory
class InMemoryEventoRepository(EventoRepository):
    def __init__(self):
        self.eventos = {}

    def agregar_evento(self, evento: Evento):
        self.eventos[evento.id] = evento

    def obtener_evento_por_id(self, evento_id: str) -> Evento:
        return self.eventos.get(evento_id)

    def guardar_evento(self, evento: Evento):
        self.eventos[evento.id] = evento

# --- CONTROLLER ---
# carpeta: interface/controllers
class UsuarioInput(BaseModel):
    nombre: str
    ci: str

app = FastAPI()
repo = InMemoryEventoRepository()
us_case = RegistrarUsuarioEnEvento(repo)

# Creamos evento de prueba
evento_demo = Evento(id="1", nombre="Conferencia IA", fecha=datetime(2025, 6, 10), costo=0.0, capacidad=2)
repo.agregar_evento(evento_demo)

@app.post("/eventos/{evento_id}/registrar")
def registrar_usuario(evento_id: str, usuario: UsuarioInput):
    try:
        inscritos = us_case.ejecutar(evento_id, Usuario(**usuario.dict()))
        return {"usuarios_registrados": inscritos}
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))
