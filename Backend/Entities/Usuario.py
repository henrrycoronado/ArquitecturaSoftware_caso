from pydantic import BaseModel

class Usuario(BaseModel):
    nombre: str
    ci: str
