using Polimorfismo.Models;

namespace Polimorfismo.Data;

public class ExtratoService
{
    private readonly Dictionary<int, ContaCorrente> _contasCorrente = new Dictionary<int, ContaCorrente>()
    {
        { 1, new ContaCorrente()
        {
            Id = 1,
            Nome = "Alexandre Santos Costa",
            Saldo = 0.00M,
            Operacoes = new List<Operacao>()
            {
                new Pagamento()
                {
                    Id = 1,
                    Timestamp = new DateTime(2023,2,22),
                    Favorecido = "SABESP",
                    Valor = 65.00M,
                    Vencimento = new DateOnly(2023, 2, 22)
                },
                new TransferenciaRecebida()
                {
                    TipoTransferencia = TipoTransferencia.PIX,
                    Id = 2,
Timestamp = new DateTime(2023,2,21),
Valor = 65.00M,
Origem = new ContaCorrente()
{
    Id = 2,
    Nome = "Anderson Santos Costa"
}
                }
            }
        } },
        { 2, new ContaCorrente()
        {
            Id = 2,
            Nome = "Anderson Santos Costa",
            Saldo = 0.00M,
            Operacoes = new List<Operacao>()
            {
                new TransferenciaEnviada()
                {
                    TipoTransferencia = TipoTransferencia.PIX,
                    Id = 2,
                    Timestamp = new DateTime(2023, 2, 21),
                    Valor = 65.00M,
                    Destinatario = new ContaCorrente()
                    {
                        Id = 1,
                        Nome = "Alexandre Santos Costa"
                    }
                }
            }
                } }
    };

    public ContaCorrente SelecionarExtratoContaCorrente(int id) => _contasCorrente[id];
}