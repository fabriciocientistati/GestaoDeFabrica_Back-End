using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class PessoaController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/pessoas")]
    public async Task<IActionResult> BuscarTodasPessoas()
    {
        try
        {
            var pessoas = await contexto.TBPessoas
                .AsNoTracking()
                .ToListAsync();

            return pessoas.Any() 
            ? Ok(pessoas) 
            : NotFound(new RespostaViewModelo<PessoaModelo>("Não foi possivel encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/pessoas/{pessoa}")]
    public async Task<IActionResult> BuscarPessoa(string pessoa)
    {
        try
        {
            var pessoas = await contexto.TBPessoas
                .AsNoTracking()
                .Where(x => x.PesNome.ToLower().Contains(pessoa.ToLower()))
                .ToListAsync();

            return pessoas.Any()
                ? Ok(pessoas)
                : NotFound(new RespostaViewModelo<PessoaModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/pessoas/{id:int}")]
    public async Task<IActionResult> BuscarUmaPessoa(int id)
    {
        try
        {
            var pessoa = await contexto.TBPessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PesId == id);

            if (pessoa == null)
                return NotFound(new RespostaViewModelo<PessoaModelo>("Não foi possivel encontrar"));

            return Ok(new RespostaViewModelo<PessoaModelo>(pessoa));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/pessoas")]
    public async Task<IActionResult> AdicionarPessoa(PessoaModelo modelo)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new RespostaViewModelo<PessoaModelo>(ModelState.ObterEstadoDeErros()));

            // var pessoa = new PessoaModelo
            // {
            //     PesNome = modelo.PesNome,
            //     PesCpf = modelo.PesCpf,
            //     PesCnpj = modelo.PesCnpj,
            //     PesEmail = modelo.PesEmail,
            //     PesNumCelular = modelo.PesNumCelular,
            //     PesNumTelefone = modelo.PesNumTelefone,
            // };

            await contexto.TBPessoas.AddAsync(modelo);
            await contexto.SaveChangesAsync();

            return Created($"v1/pessoas/{modelo.PesId}", new RespostaViewModelo<PessoaModelo>(modelo));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Não foi possível atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha interna no servidor"));
        }
    }

    [HttpPut]
    [Route("v1/pessoas/{id:int}")]
    public async Task<IActionResult> AtualizarPessoa(int id, PessoaModelo modelo)
    {
        if (!ModelState.IsValid)
            return NotFound(new RespostaViewModelo<PessoaModelo>(ModelState.ObterEstadoDeErros()));

        try
        {
            var pessoa = await contexto.TBPessoas.FirstOrDefaultAsync(x => x.PesId == id);
            if (pessoa == null)
                return NotFound(new RespostaViewModelo<PessoaModelo>("Não foi possível encontrar"));

            // pessoa.PesNome = modelo.PesNome;
            // pessoa.PesCpf = modelo.PesCpf;
            // pessoa.PesCnpj = modelo.PesCnpj;
            // pessoa.PesEmail = modelo.PesEmail;
            // pessoa.PesNumCelular = modelo.PesNumCelular;
            // pessoa.PesNumTelefone = modelo.PesNumTelefone;
            
            contexto.TBPessoas.Update(modelo);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<PessoaModelo>(modelo));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Não foi possivel atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/pessoas/{id:int}")]
    public async Task<IActionResult> ApagarPessoa(int id)
    {
        try
        {
            var pessoa = await contexto.TBPessoas.FirstOrDefaultAsync(x => x.PesId == id);
            if (pessoa == null)
                return NotFound(new RespostaViewModelo<PessoaModelo>("Não foi possível encontrar"));

            contexto.TBPessoas.Remove(pessoa);
            await contexto.SaveChangesAsync();
            
            return Ok(new RespostaViewModelo<PessoaModelo>(pessoa));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Não foi possível apagar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<PessoaModelo>("Falha no servidor"));
        }
    }
}