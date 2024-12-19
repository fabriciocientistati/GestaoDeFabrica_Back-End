using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FabricaGestao.Api.Modelos
{
    public class UsuarioModelo
    {
        [Key]
        public int UsuId { get; set; }
        public int PerId { get; set; }
        public string UsuNome { get; set; }
        public string UsuLogin { get;set; }
        public string UsuSenha { get; set; }
        public string UsuEmail { get; set; }
        public int UsuIncPor {  get; set; }
        public DateTime UsuIncEm { get; set; }  = DateTime.Now;
        
        public int? UsuAltPor { get; set; }
        
        public DateTime? UsuAltEm { get; set; } 
        public PerfilModelo Perfil { get; set; }
    }
}
