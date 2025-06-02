from fastapi import FastAPI
from datetime import datetime
from modelos.evento import Evento
from repositorios.evento_repositorio_memoria import EventoRepositorioMemoria
from servicios.registro_evento_service import RegistroEventoService
from controllers.registro_evento_controller import crear_router_registro

app = FastAPI()

repo = EventoRepositorioMemoria()
service = RegistroEventoService(repo)

evento_demo = Evento(id="1", nombre="Conferencia IA", fecha=datetime(2025, 6, 10), costo=0.0, capacidad=2)
repo.agregar_evento(evento_demo)


app.include_router(crear_router_registro(service))
