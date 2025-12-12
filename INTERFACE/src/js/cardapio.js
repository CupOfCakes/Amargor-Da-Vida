const baseURL = "http://localhost:5170";


async function carregarCardapio(){
    try{
        const res = await fetch("http://localhost:5170/produtos");
        const dados = await res.json();


        for(const [categoria, itens] of Object.entries(dados)) {
            montarSecao(categoria, itens);
        }

    }catch (e){
        console.error("Erro ao carregar o cardapio: ", e);
    }
}

function montarSecao(secao, itens){
    const containerGeral = document.querySelector(".cardapio-container");

    const section = document.createElement("div");
    section.classList.add("container");
    section.style.marginBottom = "60px"

    const titulo = document.createElement("h2");
    titulo.classList.add("section-title");
    titulo.textContent = secao;

    const grid = document.createElement("div");
    grid.classList.add("grid-cards");


    itens.forEach(item => {
        let img_path = item.imagem;

        if(img_path.startsWith("/static/")){
            img_path = baseURL + img_path;
        }

        const card = document.createElement("div");
        card.classList.add("card");

        card.innerHTML = `
            <div class="card">
                <div class="card-img"
                    style="background-image: url('${img_path}')">
                </div>
                <div class="card-info">
                    <h3>${item.nome}</h3>
                    <p>${item.descricao}</p>
                    <div class="price-row">
                        <span class="preco">R$ ${item.preco}</span>
                        <button 
                          class="btn-card" 
                          data-id="${item.id}" 
                          data-nome="${item.nome}" 
                          data-preco="${item.preco}">
                          Comprar
                        </button>
                    </div>
                </div>
            </div>
        `;

        grid.appendChild(card);
    });

    section.appendChild(titulo);
    section.appendChild(grid);

    containerGeral.appendChild(section);

}

carregarCardapio();
