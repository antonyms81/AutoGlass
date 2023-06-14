using AutoGlass.Dominio.DTOs;
using AutoGlass.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AutoGlass.Aplicacao.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IServicoProduto _servicoProduto;

        public ProdutosController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                await _servicoProduto.Criar(produtoDTO);

                return Ok();
            }
            catch (ArgumentException excecaoDeArgumento)
            {
                return BadRequest(excecaoDeArgumento.Message);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                await _servicoProduto.Atualizar(produtoDTO);

                return Ok();
            }
            catch (ArgumentException excecaoDeArgumento)
            {
                return BadRequest(excecaoDeArgumento.Message);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir([FromBody] Guid produtoId)
        {
            try
            {
                await _servicoProduto.Excluir(produtoId);

                return Ok();
            }
            catch (ArgumentException excecaoDeArgumento)
            {
                return BadRequest(excecaoDeArgumento.Message);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPeloId(Guid id)
        {
            try
            {
                var produtoDTO = await _servicoProduto.BuscarPeloId(id);

                return Ok(produtoDTO);
            }
            catch (ArgumentException excecaoDeArgumento)
            {
                return NotFound(excecaoDeArgumento.Message);
            }
            catch (Exception excecao)
            {
                return NotFound(excecao);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(string? nome, int pageIndex = 1, int pageSize = 20)
        {
            try
            {
                var produtosDTO = await _servicoProduto.BuscarTodos(nome, pageIndex, pageSize);

                return Ok(produtosDTO);
            }
            catch (ArgumentException excecaoDeArgumento)
            {
                return NotFound(excecaoDeArgumento.Message);
            }
            catch (Exception excecao)
            {
                return NotFound(excecao);
            }
        }
    }
}
