using System.Reflection.Metadata;
using Microsoft.Extensions.Options;

namespace AmargorDaVida.vars;

public class Paths
{
    private static string dir;

    public static void Initialize(string directory)
    {
        dir = directory;
    }

    public static string PathProdutos => Path.Combine(dir, "produtos.json");
    public static string PathCompras => Path.Combine(dir, "compras.json");
    public static string PathContatos => Path.Combine(dir, "contatos.json");
}

