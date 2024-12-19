using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class OrcamentoModelo
    {
        [Key] public int OrcId { get; set; }
        
        public int PesId { get; set; }
        
        public PessoaModelo Pessoa { get; set; }
        
        public string OrcDesc { get; set; }

        public string? OrcObservacao { get; set; }
        
        public decimal OrcPreco { get; set; }
        
        public string OrcTipoPagamento { get; set; }
        
        public string OrcTipoEntrega { get; set; }

        public int OrcIncPor {  get; set; }

        public DateTime OrcIncEm { get; set; } = DateTime.Now;

        public int? OrcAltPor { get; set; }

        public DateTime? OrcAltEm { get; set; }

        public List<OrcamentoProdutoModelo>? OrcamentoProdutos { get; set; } = new List<OrcamentoProdutoModelo>();
    }
}
