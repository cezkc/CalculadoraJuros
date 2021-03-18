namespace CalculadoraJuros.Domain.Interfaces
{

    /// <summary>
    /// Classe para implementação de calculadoras conforme regra de negócio necessária
    /// </summary>
    public interface ICalculadora
    {
        decimal Calcular(decimal valorInicial, int meses, decimal taxaJuros);
    }
}
