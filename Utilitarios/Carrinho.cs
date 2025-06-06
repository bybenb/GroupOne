using System.Collections.Generic;
using GestaoSimples.Modelos;

namespace GestaoSimples.Utilitarios
{
    public static class Carrinho
    {
        private static List<Produto> produtos = new List<Produto>();

        public static void Adicionar(Produto p)
        {
            produtos.Add(p);
        }

        public static void Remover(Produto p)
        {
            produtos.Remove(p);
        }

        public static List<Produto> Listar()
        {
            return new List<Produto>(produtos);
        }

        public static void Limpar()
        {
            produtos.Clear();
        }

        public static int QuantidadeItens()
        {
            return produtos.Count;
        }
    }
}