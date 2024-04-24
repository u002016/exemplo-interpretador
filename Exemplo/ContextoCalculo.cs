namespace Exemplo;

public class ContextoCalculo
{
    public decimal ValorFatura { get; set; }
    public decimal ValorPagoFatura { get; set; }
    public decimal ValorInvestido { get; set; }
    public decimal ValorCompras { get; set; }
    public ContextoCalculo(decimal valorFatura, decimal valorPagoFatura, decimal valorInvestido, decimal valorCompras)
    {
        ValorFatura = valorFatura;
        ValorPagoFatura = valorPagoFatura;
        ValorInvestido = valorInvestido;
        ValorCompras = valorCompras;
    }
}
