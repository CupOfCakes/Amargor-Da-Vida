using AmargorDaVida.Models;
using AmargorDaVida.vars;

using System.Text.Json;
using System.Reflection;
namespace AmargorDaVida.Functions;

public static class Gets
{
    private static List<Item> BuscarPorIdsNoCardapio(Cardapio cardapio, List<int> ids)
    {
        var todasListas = cardapio.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType == typeof(List<Item>))
            .Select(p => (List<Item>)p.GetValue(cardapio))
            .Where(l => l != null);

        var encontrados = todasListas.SelectMany(lista => lista)
                                     .Where(i => ids.Contains(i.ItemId))
                                     .ToList();
        
        return encontrados;
        
    }

    public static Cardapio? CarregarCardapio()
    {
        
        var json = File.ReadAllText(Paths.PathProdutos);
        
        var root = JsonSerializer.Deserialize<Root>(json);

        return root?.Cardapio;
    }

    public static List<Item> CarregarDestaques()
    {
        Cardapio? cardapio = CarregarCardapio();
        List<Item> destaques = BuscarPorIdsNoCardapio(cardapio, Destaques.Valores);

        return destaques;
    }
    
}