import config as var
import json

def buscar_por_ids(data, ids):
    encontrados = []
    for categoria in data.values():
        for item in categoria:
            if item["id"] in ids:
                encontrados.append(item)

    return encontrados

def buscar_todos_produtos():
    with open(var.path_produtos, 'r', encoding="UTF-8") as f:
        produtos = json.load(f)
    return produtos["cardapio"]