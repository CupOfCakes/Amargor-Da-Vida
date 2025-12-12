using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AmargorDaVida.Models;

public class Contato
{ 
    [EmailAddress]
    [JsonPropertyName("email")]
    public string Email { get; init; }
    
    [JsonPropertyName("nome")]
    public string Nome { get; set; } 
    
    [JsonPropertyName("msg")]
    public string Mensagem  { get; set; }

}