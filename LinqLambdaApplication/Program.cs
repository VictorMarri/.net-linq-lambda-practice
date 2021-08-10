using LinqLambdaApplication.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLambdaApplication
{
    class Program
    {
        static void Print<T>(string mensagem, IEnumerable<T> colecao)
        {
            Console.WriteLine(mensagem);
            foreach (T obj in colecao)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Categoria categoria1 = new Categoria() { Id = 1, Nome = "Ferramentas", Rank = 2 };
            Categoria categoria2 = new Categoria() { Id = 2, Nome = "Computadores", Rank = 1 };
            Categoria categoria3 = new Categoria() { Id = 3, Nome = "Eletronicos", Rank = 1 };

            List<Produto> produtos = new List<Produto>()
            {
                new Produto(){ Id = 1, Nome = "Computador", Preco = 1100, Categoria = categoria2},
                new Produto(){ Id = 2, Nome = "Chave Inglesa", Preco = 222, Categoria = categoria1},
                new Produto(){ Id = 3, Nome = "Celular", Preco = 3222, Categoria = categoria3},
                new Produto(){ Id = 4, Nome = "Placa Mae", Preco = 1111, Categoria = categoria2},
                new Produto(){ Id = 5, Nome = "Memoria Ram", Preco = 780, Categoria = categoria2},
                new Produto(){ Id = 6, Nome = "Placa de Video", Preco = 1256, Categoria = categoria2},
                new Produto(){ Id = 7, Nome = "SoundBar", Preco = 440, Categoria = categoria3},
                new Produto(){ Id = 8, Nome = "Tablet", Preco = 7000, Categoria = categoria3},
                new Produto(){ Id = 9, Nome = "Chave Philips", Preco = 1100, Categoria = categoria1},
                new Produto(){ Id = 10, Nome = "Notebook", Preco = 470, Categoria = categoria2},
                new Produto(){ Id = 11, Nome = "TV", Preco = 2500, Categoria = categoria3},

            };

            var r1 = produtos.Where(p => p.Categoria.Rank == 1 && p.Preco < 900);
            Print("Rank 1, preço menor que 900: ", r1);

            var r2 = produtos.Where(p => p.Categoria.Nome == "Ferramentas")
                .Select(p => p.Nome);
            Print("Nome dos produtos da categoria de ferramentas: ", r2);

            var r3 = produtos.Where(p => p.Nome[0] == 'C')
                .Select(p => new { p.Nome, p.Preco, NomeCategoria = p.Categoria.Nome });
            Print("Nome dos produtos começados com a letra 'C' e objeto anonimo: ", r3);

            var r4 = produtos.Where(p => p.Categoria.Rank == 1)
                .OrderBy(p => p.Preco)
                .ThenBy(p => p.Nome);
            Print("Nome dos produtos de Rank 1, ordenados por preço e por nome: ", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("Nome dos produtos de Rank 1, ordenados por preço e por nome, mas agora pulando os dois primeiros e pegando os outros 4: ", r5);

            var r6 = produtos.First();
            Console.WriteLine("Retorna o primeiro produto cadastrado na lista\n\n " + r6);

            var r7 = produtos.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("\nSingleOrDefault teste: \n\n" + r7);

            var r8 = produtos.Max(p => p.Preco);
            Console.WriteLine("\nPreço maximo:\n\n " + r8);

            var r9 = produtos.Min(p => p.Preco);
            Console.WriteLine("\nPreço Mínimo:\n\n " + r9);

            var r10 = produtos.Where(p => p.Categoria.Id == 1).Sum(p => p.Preco);
            Console.WriteLine("\nProdutos da categoria 1 com suas somas de preço:\n\n " + r10);

            var r11 = produtos.Where(p => p.Categoria.Id == 1).Average(p => p.Preco);
            Console.WriteLine("\nProdutos da categoria 1 com a média de todos os preços:\n\n" + r11);
        }
    }
}
