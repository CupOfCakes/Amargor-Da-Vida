// Carrinho
const carrinho = [];
let carrinhoVisivel = false;
let total = 0;

// Cria o container visual do carrinho
const carrinhoBox = document.createElement("div");
carrinhoBox.className = "carrinho-flutuante";
carrinhoBox.style.position = "fixed";
carrinhoBox.style.bottom = "20px";
carrinhoBox.style.right = "20px";
carrinhoBox.style.background = "#fff";
carrinhoBox.style.border = "1px solid #ccc";
carrinhoBox.style.padding = "15px";
carrinhoBox.style.width = "280px";
carrinhoBox.style.display = "none";
carrinhoBox.style.zIndex = "9999";
carrinhoBox.innerHTML = `
    <h3>Carrinho</h3>
    <table id="tabela-carrinho" style="width:100%; font-size:14px;">
        <thead>
            <tr>
                <th>Produto</th>
                <th>Qtd</th>
                <th>Preço</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    <p id="total"></p>
    <button id="finalizar">Finalizar Compra</button>
`;
document.body.appendChild(carrinhoBox);

// Atualiza a tabela
function atualizarCarrinho() {
    const tbody = carrinhoBox.querySelector("tbody");
    const totalEl = carrinhoBox.querySelector("#total");

    tbody.innerHTML = "";

    total = 0;

    carrinho.forEach(item => {
        total += item.preco * item.qtd;

        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td class="col-nome">${item.nome}</td>
            <td class="col-qtd">${item.qtd}x</td>
            <td class="col-preco">R$ ${(item.preco * item.qtd).toFixed(2)}</td>
            <td class="col-acao">
                <button class="remover-item" data-id="${item.id}">-</button> </td>
        `;
        tbody.appendChild(tr);
    });

    totalEl.textContent = "Total: R$ " + total.toFixed(2);

}

// Adiciona item ao carrinho
function adicionarAoCarrinho(id, nome, preco) {
    let item = carrinho.find(p => p.id === id);

    if (item) {
        item.qtd++;
    } else {
        carrinho.push({ id, nome, preco, qtd: 1 });
    }

    if (!carrinhoVisivel) {
        carrinhoBox.style.display = "block";
        carrinhoVisivel = true;
    }

    atualizarCarrinho();
}

//função manda pra api a compra
async function mandarCompra(){
    const url = "http://localhost:5170/compra";

    const compra = {
        data: new Date().toISOString(),
        itens: carrinho,
        total: total
    }

    try {
        const resposta = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(compra)
        });

        if (!resposta.ok) {
            console.log("Status da resposta:", resposta.status);
        }

        const retorno = await resposta.json();
        alert(retorno["mensagem"]);

    } catch (erro) {
        alert("Erro na compra: " + erro);
    }
}



// Detecta cliques nos botões dos produtos
document.addEventListener("click", function(e) {
    if (e.target.classList.contains("btn-card")) {
        const id = parseInt(e.target.dataset.id);
        const nome = e.target.dataset.nome;
        const preco = parseFloat(e.target.dataset.preco);

        adicionarAoCarrinho(id, nome, preco);
    }
});

document.addEventListener("click", function(e) {
    if(e.target.classList.contains("remover-item")) {
        const id = Number(e.target.dataset.id);

        let item = carrinho.find(p => p.id === id);

        if(item) {
            item.qtd--;

            if(item.qtd <= 0) {
                const index = carrinho.findIndex(p => p.id === id);
                carrinho.splice(index, 1);
            }

        }

        if(carrinhoVisivel && carrinho.length === 0) {
            carrinhoVisivel = false;
            carrinhoBox.style.display = "none";
        }

        atualizarCarrinho();
    }
})


// Finalizar compra
carrinhoBox.querySelector("#finalizar").addEventListener("click", async () => {
    const resposta = confirm("Tem certeza que quer finalizar a compra?");

    if (resposta) {
        await mandarCompra();
    }
});
