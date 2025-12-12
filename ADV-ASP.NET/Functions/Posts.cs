using System.Text.Json;
using AmargorDaVida.Models;
using AmargorDaVida.vars;

namespace AmargorDaVida.Functions;

public class Posts
{
    private static void Salvar<G>(G item, string path)
    {
        try
        {
            var json = File.Exists(path) ? File.ReadAllText(path, System.Text.Encoding.UTF8) : "[]";
            List<G> lista = JsonSerializer.Deserialize<List<G>>(json) ?? new List<G>();

            lista.Add(item);

            var novoJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, novoJson, System.Text.Encoding.UTF8);
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao salvar {typeof(G).Name}: {e.Message}", e);
        }
    }
    
    
    public static void SalvarCompra(Compra compra)
    {
        Salvar(compra, Paths.PathCompras);
        
    }

    public static void SalvarContato(Contato contato)
    {
        Salvar(contato, Paths.PathContatos);
    }
    
    
}