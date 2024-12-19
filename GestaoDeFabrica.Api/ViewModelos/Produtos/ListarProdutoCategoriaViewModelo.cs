namespace FabricaGestao.Api.ViewModelos.Produtos;

public class ListarProdutoCategoriaViewModelo
{
    public int ProId { get; set; }
        
    public string ProNome { get; set; }
    
    public string Categoria { get; set; }
        
    public string ProDesc { get; set; }
    
    public decimal ProPreco { get; set; }

    public string GetFormattedBasePrice() => ProPreco.ToString("0.00");
    public int ProQuantidadeEmEstoque { get; set; }

    public string ProImagemUrl { get; set; }
    
}