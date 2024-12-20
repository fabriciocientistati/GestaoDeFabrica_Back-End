using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace FabricaGestao.Api.ViewModelos.Usuarios;

public class EditorUsuarioViewModelo
{
    [Required(ErrorMessage = "Campo nome obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string UsuNome { get; set; }
    [Required(ErrorMessage = "Campo nome obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string UsuLogin { get;set; }
    public string UsuSenha { get; set; }
    [Required(ErrorMessage = "Campo nome obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail invalido")]
    public string UsuEmail { get; set; }
    public DateTime UsuIncEm { get; set; }  = DateTime.Now;
    public int UsuIncPor { get; set; }
}