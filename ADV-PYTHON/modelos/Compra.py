from pydantic import BaseModel

class Item(BaseModel):
    id:int
    nome:str
    preco:float
    qtd:int

class Compra(BaseModel):
    data:str
    itens:list[Item]
    total:float