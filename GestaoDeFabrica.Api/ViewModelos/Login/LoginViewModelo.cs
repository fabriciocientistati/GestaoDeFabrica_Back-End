using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.ViewModelos.Login;

public class LoginViewModelo
{
    [Required(ErrorMessage = "Preencha o campo usuário")]
    public string UsuLogin { get; set; }
    [Required(ErrorMessage = "Preencha o campo senha")]
    public string UsuSenha { get; set; }
}