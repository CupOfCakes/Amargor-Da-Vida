async function enviarEmail(){
    const email = document.getElementById('email').value;
    const nome = document.getElementById('nome').value;
    const msg = document.getElementById('msg').value;

    try {
        const resposta = await fetch("http://localhost:5170/contato",{
            method: 'POST',
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                email,
                nome,
                msg
            })
        });

        if (!resposta.ok) {
            console.log("Status da resposta:", resposta.status);
        }

        alert("Você acha mesmo q alguem vai ler oq vc mandou?");

    } catch(erro){
        alert("Erro ao enviar: " + erro)
    }

}


document.addEventListener('click', function (e){
    if(e.target.classList.contains("btn-email")){
        enviarEmail();
    }
});
