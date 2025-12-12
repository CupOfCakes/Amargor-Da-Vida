# 🧩 Projeto de Estudos — APIs com FastAPI e ASP.NET

Este repositório reúne um projeto criado para estudar, comparar e entender na prática diferentes formas de desenvolver APIs.

Ele contém duas implementações independentes, cada uma utilizando tecnologias distintas:

- FastAPI (Python)

- ASP.NET (C#)

Ambas as APIs trabalham com manipulação de dados em JSON e seguem uma estrutura simples para fins de aprendizado e testes.

## 🚀 Tecnologias Utilizadas
### Backend

- 🐍 FastAPI

- 🔷 ASP.NET / C#

- 📦 System.Text.Json

- 📦 pydantic

### Ferramentas & Outros

- JSON para persistência de dados

- Fetch API no front-end

## 🧠 Objetivos do Projeto

- Aprender criação de rotas em duas stacks diferentes

- Comparar serialização, validação e respostas entre FastAPI e ASP.NET

- Testar integração com front-end simples

- Manipular arquivos JSON externos ao projeto

- Praticar organização de projeto multi-repositório (sem submódulos acidentais, né…)

## 📁 Estrutura do Repositório
<pre>
/
├── ADV-ASP.NET/     # API usando ASP.NET
├── ADV-PYTHON/      # API usando FastAPI
├── INTERFACE/       # Interface web/front-end
├── DATA/            # Arquivos JSON usados pelas APIs
└── README.md
</pre>

### ⚡ Como Rodar
🟦 ASP.NET
<pre>
cd ADV-ASP.NET
dotnet run
</pre>

🟩 FastAPI
<pre>
cd ADV-PYTHON
uvicorn main:app --reload
</pre>

## 🖥️ Interface

Abra o arquivo home.html ou rode via servidor local.

## 🔧 Configuração de Caminhos

As APIs utilizam arquivos JSON armazenados na pasta DATA, compartilhada entre os projetos.
Para evitar duplicação e permitir que cada aplicação encontre os arquivos corretamente, os caminhos são configurados de forma dinâmica.

### 🟦 ASP.NET — Configuração no appsettings.json

A API em ASP.NET lê automaticamente o diretório onde os JSONs estão armazenados.
Você só precisa indicar o caminho da pasta DATA no appsettings.json.

Um exemplo do trecho configurável:

<pre>"DataDirectory": "C:/caminho/para/sua/pasta/DATA"</pre>

No próprio arquivo há um comentário indicando exatamente onde preencher o caminho, então não tem erro.

Com isso, a API consegue montar todos os paths necessários internamente, sem precisar ajustar nada no código.

### 📄 Licença

Este projeto é apenas para estudo.
Use, modifique, brinque à vontade.
