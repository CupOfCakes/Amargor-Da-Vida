from pydantic import BaseModel

class Contato(BaseModel):
    email:str
    nome:str
    msg:str
