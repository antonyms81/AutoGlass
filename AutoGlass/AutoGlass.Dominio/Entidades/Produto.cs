using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Dominio.Entidades
{
    public class Produto
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public SituacaoProduto Situacao { get;  set; }

    }

}
