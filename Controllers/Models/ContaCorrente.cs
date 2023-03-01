namespace Polimorfismo.Models;

public class ContaCorrente
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public decimal Saldo {get; set;}

    public IEnumerable<Operacao> Operacoes {get; set;} = new List<Operacao>();
}