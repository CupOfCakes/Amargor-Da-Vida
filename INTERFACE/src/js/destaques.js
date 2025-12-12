async function carregarDestaques() {
    try{
        const baseURL = "http://localhost:5170";
        const res = await fetch("http://localhost:5170/destaques");
        const dados = await res.json();

        const grid = document.querySelector(".grid-cards");
        grid.innerHTML = "";

        dados.forEach(item => {
            const card = document.createElement("div");
            card.classList.add("card");

            let img_path = item.imagem;

            if(img_path.startsWith("/static/")){
                img_path = baseURL + item.imagem;
            }

            card.innerHTML = `
            <div class="card-img ${item.id}" 
            style="background-image: url('${img_path}');">
            </div> 
                <div class="card-info">
                    <h3>${item.nome}</h3>
                    <p>${item.descricao}</p>
                </div>
            `;

            grid.appendChild(card);
        });


    } catch (e){
        console.error("Erro ao carregar os destaques: ", e);
    }
}

carregarDestaques();
