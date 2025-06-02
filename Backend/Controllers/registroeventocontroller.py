from fastapi import APIRouter, HTTPException
from pydantic import BaseModel
from modelos.usuario import Usuario
from servicios.registro_evento_service import RegistroEventoService

class UsuarioInput(BaseModel):
    nombre: str
    ci: str

def crear_router_registro(service: RegistroEventoService):
    router = APIRouter()

    @router.post("/eventos/{evento_id}/registrar")
    def registrar_usuario(evento_id: str, usuario: UsuarioInput):
        try:
            inscritos = service.registrar_usuario(evento_id, Usuario(**usuario.dict()))
            return {"usuarios_registrados": inscritos}
        except Exception as e:
            raise HTTPException(status_code=400, detail=str(e))

    return router
