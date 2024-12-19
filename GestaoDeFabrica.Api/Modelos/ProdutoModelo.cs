using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class ProdutoModelo
    {
        [Key] public int ProId { get; set; }
        public int CatId { get; set; }
        
        public string ProNome { get; set; }
        
        public string ProDesc { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]

        public decimal ProPreco { get; set; }

        public string GetFormattedBasePrice() => ProPreco.ToString("0.00");

        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que zero.")]
        public int ProQuantidadeEmEstoque { get; set; }

        public string ProImagemUrl { get; set; }

        public int ProIncPor { get; set; }

        public DateTime ProIncEm { get; set; } = DateTime.Now;

        public int? ProAltPor { get; set; }

        public DateTime? ProAltEm { get; set; }

        public CategoriaModelo Categoria { get; set; }

        public List<OrcamentoProdutoModelo> ProdutoOrcamentos { get; set; } = new List<OrcamentoProdutoModelo>();
    }
}
