using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos;

public class PerfilModelo
{
    [Key]
    public int PerId { get; set; }
    public string PerNome { get; set; }
    public int PerIncPor { get; set; }
    public DateTime PerIncEm { get; set; }
    public int PerAltPor { get; set; }
    public DateTime PerAltEm { get; set; }
    public ICollection<UsuarioModelo> Usuarios { get; set; } = new List<UsuarioModelo>();
}