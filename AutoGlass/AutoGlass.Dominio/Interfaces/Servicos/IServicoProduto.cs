using AutoGlass.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Dominio.Interfaces.Servicos
{
    public interface IServicoProduto
    {
        Task Criar(ProdutoCriacaoDTO produtoCriacaoDTO);
        Task Atualizar(ProdutoAtualizacaoDTO produtoAtualizacaoDTO);
        Task Excluir(Guid id);
        Task<ProdutoDTO> BuscarPeloId(Guid id);
        Task<List<ProdutoDTO>> BuscarTodos(string nome, int pageIndex, int pageSize);
        Task<List<ProdutoDTO>> BuscarPorCodigoProduto(int codigoProduto);
    }
}
