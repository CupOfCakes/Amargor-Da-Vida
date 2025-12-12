import json
from unittest.mock import mock_open, patch
from fastapi.testclient import TestClient
from main import app  # seu arquivo principal FastAPI
from funcoes import funcoes_get as gt

client = TestClient(app)

def test_get_destaques():
    # JSON fictício simulando o arquivo
    fake_json = {
        "cardapio": [
            {"id": 1, "nome": "Produto 1"},
            {"id": 4, "nome": "Produto 4"},
            {"id": 8, "nome": "Produto 8"},
            {"id": 99, "nome": "Outro produto"}
        ]
    }

    # O que a função buscar_por_ids deveria retornar
    fake_resultado = [
        {"id": 1, "nome": "Produto 1"},
        {"id": 8, "nome": "Produto 8"},
        {"id": 4, "nome": "Produto 4"},
    ]

    # Simula a leitura do arquivo e a função buscar_por_ids
    with patch("builtins.open", mock_open(read_data=json.dumps(fake_json))):
        with patch("gt.buscar_por_ids", return_value=fake_resultado):
            response = client.get("/destaques")

    # Verificações reais
    assert response.status_code == 200
    assert response.json() == fake_resultado

if __name__ == '__main__':
    print("oi")