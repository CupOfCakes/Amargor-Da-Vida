from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from fastapi.staticfiles import StaticFiles
from fastapi import HTTPException
from funcoes import funcoes_get as get
from modelos.Compra import Compra
from modelos.Contato import Contato
from funcoes import funcoes_post as post
import config as var

app = FastAPI()

app.mount("/static", StaticFiles(directory="static"), name="static")

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

@app.get("/destaques")
def get_destaques():
    produtos = get.buscar_todos_produtos()
    destaques = get.buscar_por_ids(produtos, var.ids_destaque)
    return destaques

@app.get("/produtos")
def get_produtos(tipo:str | None = None):
    produtos = get.buscar_todos_produtos()

    if tipo:
        if tipo not in produtos:
            raise HTTPException(
                status_code=404,
                detail=f"Categoria '{tipo}' não encontrada"
            )
        return produtos.get(tipo,[])
    return produtos

@app.post("/compra", status_code=201)
def post_compra(compra: Compra):
    post.salvar_compra(compra)
    return{"status":201, "mensagem": "compra registrada"}

@app.post("/contato", status_code=201)
def post_contato(contato: Contato):
    post.salvar_contato(contato)