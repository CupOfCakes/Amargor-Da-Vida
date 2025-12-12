using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AmargorDaVida.Models;

public class Item
{
    [Key]
    [JsonPropertyName("id")]
    public int ItemId { get; init; }
    
    [JsonPropertyName("nome")]
    public string ItemNome { get; set; } 
    
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;
    
    [JsonPropertyName("preco")]
    public decimal Preco { get; set; }
    
    [JsonPropertyName("imagem")]
    public string ImagemPath { get; set; } = string.Empty;
    
    [JsonPropertyName("qtd")]
    public int? Quantidade { get; set; }

    public Item(int itemId, string itemNome, decimal preco, int quantidade)
    {
        ItemId = itemId;
        ItemNome = itemNome;
        Preco = preco;
        Quantidade = quantidade;
    }
    
    [JsonConstructor]
    public Item(int itemId, string itemNome, string descricao, decimal preco, string imagemPath)
    {
        ItemId = itemId;
        ItemNome = itemNome;
        Preco = preco;
        ImagemPath = imagemPath;
        Descricao = descricao;
    }
    
}