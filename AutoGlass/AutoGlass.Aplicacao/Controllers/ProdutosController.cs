using AutoGlass.Dominio.DTOs;
using AutoGlass.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Criar([FromBody] ProdutoCriacaoDTO produtoCriacaoDTO)
        {
            string cnpjFornecedor = Regex.Replace(produtoCriacaoDTO.CNPJFornecedor, "[^0-9]", "");
            produtoCriacaoDTO.CNPJFornecedor = cnpjFornecedor;

            try
            {
                await _servicoProduto.Criar(produtoCriacaoDTO);

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
        public async Task<IActionResult> Atualizar([FromBody] ProdutoAtualizacaoDTO produtoAtualizacaoDTO)
        {
            string cnpjFornecedor = Regex.Replace(produtoAtualizacaoDTO.CNPJFornecedor, "[^0-9]", "");
            produtoAtualizacaoDTO.CNPJFornecedor = cnpjFornecedor;
            try
            {
                await _servicoProduto.Atualizar(produtoAtualizacaoDTO);

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


        [HttpGet("CodigoProduto")]
        public async Task<IActionResult> BuscarPorCodigoProduto(int codigoProduto)
        {
            try
            {
                var produtoDTO = await _servicoProduto.BuscarPorCodigoProduto(codigoProduto);

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

    }
}
