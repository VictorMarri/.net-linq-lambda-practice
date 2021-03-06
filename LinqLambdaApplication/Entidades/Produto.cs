using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaApplication.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }

        public override string ToString()
        {
            return Id + ", " + Nome + ", " + Preco.ToString() + ", " + Categoria.Nome + ", " + Categoria.Rank;
        }
    }
}
