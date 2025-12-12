using System.Text.Json.Serialization;

namespace AmargorDaVida.Models;

public class Root
{
    [JsonPropertyName("cardapio")]
    public Cardapio? Cardapio { get; set; }
}