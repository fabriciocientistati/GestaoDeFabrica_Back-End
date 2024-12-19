using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using FabricaGestao.Api.ViewModelos.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity3.Password;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class UsuarioController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/usuarios")]
    public async Task<IActionResult> BuscarTodosUsuarios()
    {
        try
        {
            var usuarios = await contexto.TBUsuarios
                .AsNoTracking()
                .ToListAsync();

            return usuarios.Any()
                ? Ok(new RespostaViewModelo<List<UsuarioModelo>>(usuarios))
                : NotFound(new RespostaViewModelo<UsuarioModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/usuarios")]
    public async Task<IActionResult> AdicionarUsuario(Add_Alt_UsuarioViewModelo model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<UsuarioModelo>(ModelState.ObterEstadoDeErros()));

        var usuario = new UsuarioModelo
        {
            UsuLogin = model.UsuLogin,
            UsuNome = model.UsuNome,
            UsuEmail = model.UsuEmail,
            UsuSenha = model.UsuSenha,
            UsuIncPor = 1
        };
        
        var senha = PasswordGenerator.Generate(25, includeSpecialChars: true, upperCase: false);
        usuario.UsuSenha = PasswordHasher.Hash(senha);
        
        try
        {
            await contexto.TBUsuarios.AddAsync(usuario);
            await contexto.SaveChangesAsync();

            return Created($"v1/usuarios/{usuario.UsuId}", new RespostaViewModelo<UsuarioModelo>(usuario));
        }
        catch(DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Não foi possível adicionar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }
}