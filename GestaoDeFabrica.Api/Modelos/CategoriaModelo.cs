using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class CategoriaModelo
    {
        [Key] public int CatId { get; set; }
        
        public string CatNome { get; set; }
        
        public int CatIncPor {  get; set; }

        public DateTime CatIncEm { get; set; } = DateTime.Now;

        public int? CatAltPor { get; set; }

        public DateTime? CatAltEm { get; set; }

        public List<ProdutoModelo> CategoriaProdutos { get; set; } = new List<ProdutoModelo>();
    }
}
