using System.Text.Json.Serialization;

namespace Polimorfismo.Models;

public enum TipoOperacao
{
    Entrada = 1,
    Saida
}

[JsonDerivedTypeAttribute(typeof(Pagamento), nameof(Pagamento))]
[JsonDerivedTypeAttribute(typeof(TransferenciaEnviada), nameof(TransferenciaEnviada))]
[JsonDerivedTypeAttribute(typeof(TransferenciaRecebida), nameof(TransferenciaRecebida))]
public class Operacao
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Valor { get; set; }
    public virtual TipoOperacao Tipo { get; protected set; }
}

public class Pagamento : Operacao
{
    public string Favorecido { get; set; } = string.Empty;
    public string CodigoBarra { get; set; } = string.Empty;
    public DateOnly Vencimento { get; set; }

    public override TipoOperacao Tipo { get =>  TipoOperacao.Saida; }
}

public enum TipoTransferencia
{
    Transferencia = 1,
    DOC,
    TED,
    PIX
}

public class TransferenciaEnviada : Operacao
{
    public ContaCorrente Destinatario {get; set;}
    public string Mensagem {get; set;} = string.Empty;
    public TipoTransferencia TipoTransferencia {get; set;}

    public override TipoOperacao Tipo { get =>  TipoOperacao.Saida; }
}

public class TransferenciaRecebida : Operacao
{    
        public ContaCorrente Origem{get; set;}
    public string Mensagem {get; set;} = string.Empty;
    public TipoTransferencia TipoTransferencia {get; set;}

    public override TipoOperacao Tipo { get =>  TipoOperacao.Entrada; }
}