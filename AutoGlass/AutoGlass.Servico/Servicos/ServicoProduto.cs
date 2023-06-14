using AutoGlass.Dominio.DTOs;
using AutoGlass.Dominio.Entidades;
using AutoGlass.Dominio.Interfaces.Repositorios;
using AutoGlass.Dominio.Interfaces.Servicos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoGlass.Servico.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioProduto _repositorioProduto;

        public ServicoProduto(IMapper mapper, IRepositorioProduto repositorioProduto)
        {
            _mapper = mapper;
            _repositorioProduto = repositorioProduto;
        }

        public async Task Criar(ProdutoDTO produtoDTO)
        {
            int resultado = DateTime.Compare(produtoDTO.DataFabricacao, produtoDTO.DataValidade);

            if (resultado > 0)
                throw new ArgumentException("A data de Fabricação não pode ser Maior ou Igual a Data de Validade");

            var produto = _mapper.Map<Produto>(produtoDTO);

            var linhasAfetadas = await _repositorioProduto.Criar(produto);
            if (linhasAfetadas == 0)
                throw new ArgumentException("Erro ao tentar cadastrar o produto!");
        }

        public async Task Atualizar(ProdutoDTO produtoDTO)
        {
            int resultado = DateTime.Compare(produtoDTO.DataFabricacao, produtoDTO.DataValidade);

            if (resultado > 0)
                throw new ArgumentException("A data de Fabricação não pode ser Maior ou Igual a Data de Validade");

            var produto = _mapper.Map<Produto>(produtoDTO);
            var linhasAfetadas = await _repositorioProduto.Atualizar(produto);
            if (linhasAfetadas == 0)
                throw new ArgumentException("Erro ao tentar atualizar o produto!");
        }

        public async Task Excluir(Guid id)
        {
            var linhasAfetadas = await _repositorioProduto.Excluir(id);
            if (linhasAfetadas == 0)
                throw new ArgumentException("Erro ao tentar excluir o produto!");
        }

        public async Task<ProdutoDTO> BuscarPeloId(Guid id)
        {
            var produto = await _repositorioProduto.BuscarPeloId(id);
            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }

        public async Task<List<ProdutoDTO>> BuscarTodos(string nome, int pageIndex, int pageSize)
        {
            var produtos = await _repositorioProduto.BuscarTodos(nome, pageIndex, pageSize);
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);

            return produtosDTO;
        }

    }
}
