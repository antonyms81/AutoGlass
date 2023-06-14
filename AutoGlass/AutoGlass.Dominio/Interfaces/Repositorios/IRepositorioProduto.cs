using AutoGlass.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProduto
    {
        Task<int> Criar(Produto produto);
        Task<int> Atualizar(Produto produto);
        Task<int> Excluir(Guid id);
        Task<Produto> BuscarPeloId(Guid id);
        Task<List<Produto>> BuscarTodos(string nome, int pageIndex, int pageSize);
    }
}
