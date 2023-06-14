using AutoGlass.Dominio.Entidades;
using AutoGlass.Dominio.Interfaces.Repositorios;
using AutoGlass.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Infra.Dados.Repositorios
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly AutoGlassContexto _contexto;

        public RepositorioProduto(AutoGlassContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Criar(Produto produto)
        {
            await _contexto.Produtos.AddAsync(produto);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> Atualizar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> Excluir(Guid id)
        {
            var produto = await BuscarPeloId(id);

            if (produto != null)
            {
                produto.Situacao = SituacaoProduto.Inativo;
                _contexto.Produtos.Update(produto);
                return await _contexto.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<Produto> BuscarPeloId(Guid id)
        {
            return await _contexto.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> BuscarTodos(string nome, int pageIndex, int pageSize)
        {
            return await _contexto.Produtos.Where(x =>
                string.IsNullOrEmpty(nome) || x.Nome.Contains(nome)
            )
            .OrderBy(x => x.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
    }
}
