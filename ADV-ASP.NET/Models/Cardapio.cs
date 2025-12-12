using System.Text.Json.Serialization;

namespace AmargorDaVida.Models;

public class Cardapio
{
    [JsonPropertyName("cafes")]
    public List<Item>? Cafes { get; set; } 
    [JsonPropertyName("comidas")]
    public List<Item>? Comidas { get; set; }
    [JsonPropertyName("sobremesas")]
    public List<Item>? Sobremesas { get; set; }
    
    public Cardapio(){}
}