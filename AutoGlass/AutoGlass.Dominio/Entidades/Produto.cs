using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Dominio.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoProduto { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
        public int CodigoProduto { get; set; }
        public int CodigoFornecedor { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public SituacaoProduto Situacao { get;  set; }

    }

}
