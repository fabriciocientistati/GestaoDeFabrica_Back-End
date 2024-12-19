using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Dados.Contexto;

public class ContextoDados : DbContext
{
    public ContextoDados(DbContextOptions<ContextoDados> options) : base(options) { }
    public DbSet<UsuarioModelo> TBUsuarios { get; set; }
    public DbSet<PessoaModelo> TBPessoas { get; set; }
    public DbSet<OrcamentoModelo> TBOrcamentos { get; set; }
    public DbSet<ProdutoModelo> TBProdutos { get; set; }
    public DbSet<CategoriaModelo> TBCategorias { get; set; }
    public DbSet<OrcamentoProdutoModelo> TBOrcamentoProdutos { get; set; }
    public DbSet<PerfilModelo> TBPerfis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioModelo>()
            .HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.PerId);
        
        modelBuilder.Entity<ProdutoModelo>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.CategoriaProdutos)
            .HasForeignKey(p => p.CatId);
        
        modelBuilder.Entity<OrcamentoModelo>()
            .HasOne(o => o.Pessoa)
            .WithMany(p => p.Orcamentos)
            .HasForeignKey(o => o.PesId);
        
        modelBuilder.Entity<OrcamentoProdutoModelo>()
            .HasKey(op => new { op.OrcId, op.ProId });

        modelBuilder.Entity<OrcamentoProdutoModelo>()
            .HasOne(o => o.Orcamento)
            .WithMany(op => op.OrcamentoProdutos)
            .HasForeignKey(o => o.OrcId);

        modelBuilder.Entity<OrcamentoProdutoModelo>()
            .HasOne(p => p.Produto)
            .WithMany(po => po.ProdutoOrcamentos)
            .HasForeignKey(p => p.ProId);
    }
}

