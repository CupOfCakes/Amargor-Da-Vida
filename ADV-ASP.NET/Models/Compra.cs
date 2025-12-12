using System.Text.Json.Serialization;

namespace AmargorDaVida.Models;

public class Compra
{
    public string Data { get; init; }
    public List<Item> Itens { get; set; }
    public decimal Total { get; set; }
}