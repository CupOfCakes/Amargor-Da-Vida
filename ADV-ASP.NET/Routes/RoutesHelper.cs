namespace AmargorDaVida.Routes;

public static class RoutesHelper
{
    public static IResult SalvarGenerico<G>(G objeto, Action<G> salvarFunc, string tipo)
    {
        try
        {
            salvarFunc(objeto);
            return Results.Created( "", new {mensagem = "compra registrada"});
        }
        catch (Exception ex)
        {
            return Results.Problem($"Não foi possível salvar {tipo}: {ex.Message}");
        }
    }
}