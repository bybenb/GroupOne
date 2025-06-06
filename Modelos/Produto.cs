//  a pasta Modelos

using System;
using System.Drawing;
using System.Windows.Forms;


using GestaoSimples.Telas.Publico;
using GestaoSimples.Componentes;
using GestaoSimples.BancoDados;
using GestaoSimples.Servicos;
using GestaoSimples.Utilitarios;

// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 


namespace GestaoSimples.Modelos
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }           // quem cadastrou
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}