using System.Reflection;
using AmargorDaVida.Functions;
using AmargorDaVida.Models;

namespace AmargorDaVida.Routes;

public static class ADV_Route
{
    
    
    public static void ADV_Routes(this WebApplication app)
    {
        //gets
        app.MapGet("/produtos", (string? tipo) =>
        {
            var cardapio = Gets.CarregarCardapio();

            if (cardapio == null)
            {
                return Results.NotFound(new { detail = "Produtos não encontrado" });
            }

            if (tipo != null)
            {
                var prop = typeof(Cardapio).GetProperty(tipo, BindingFlags.IgnoreCase | 
                                                                BindingFlags.Public | 
                                                                BindingFlags.Instance);

                if (prop == null) return Results.NotFound(new { detail = $"Desculpe, não vendemos '{tipo}' AINDA." });
                
                var produtos = prop.GetValue(cardapio);
                return Results.Ok(produtos);
            }

            return Results.Ok(cardapio);

        });

        app.MapGet("/destaques", () =>
        {
            var destaques = Gets.CarregarDestaques();

            if (!destaques.Any()) 
                return Results.Ok(new { message = "Ninguem aqui se destaca" });
            
            return Results.Ok(destaques);
        });


        app.MapPost("/compra", (Compra compra) => 
            RoutesHelper.SalvarGenerico(compra, Posts.SalvarCompra, "compra"));

        app.MapPost("/contato", (Contato contato) => 
            RoutesHelper.SalvarGenerico(contato, Posts.SalvarContato, "contato"));
    }
}