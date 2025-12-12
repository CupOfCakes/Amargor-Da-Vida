from modelos.Compra import Compra
from modelos.Contato import Contato
import config as var
import os
import json

def salvar_objeto(obj, path):
    """Salva um objeto Pydantic em um arquivo JSON, criando a lista se não existir."""
    if not os.path.exists(path):
        with open(path, 'w') as f:
            json.dump([], f)

    with open(path, 'r') as f:
        dados = json.load(f)

    dados.append(obj.dict())

    with open(path, 'w') as f:
        json.dump(dados, f, indent=4)

def salvar_compra(compra: Compra):
    salvar_objeto(compra, var.path_compras)

def salvar_contato(contato: Contato):
    salvar_objeto(contato, var.path_contato)

