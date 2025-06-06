using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Modelos;
using GestaoSimples.Servicos;
using GestaoSimples.Utilitarios;
using System.Collections.Generic;

namespace GestaoSimples.Telas.Publico
{
    public class TelaPesquisa : UserControl
    {
        private TextBox txtBusca;
        private Button btnBuscar;
        private FlowLayoutPanel painelResultados;

        public TelaPesquisa()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            InicializarControles();
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Pesquise produtos locais",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtBusca = new TextBox
            {
                Location = new Point(20, 60),
                Width = 400
            };

            btnBuscar = new Button
            {
                Text = "Buscar",
                Location = new Point(430, 60),
                Width = 100,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnBuscar.Click += BtnBuscar_Click;

            painelResultados = new FlowLayoutPanel
            {
                Location = new Point(20, 110),
                Size = new Size(800, 450),
                AutoScroll = true
            };

            this.Controls.AddRange(new Control[] { lblTitulo, txtBusca, btnBuscar, painelResultados });
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termo = txtBusca.Text.Trim();
            List<Produto> resultados = ProdutoServico.BuscarPorNome(termo);
            MostrarResultados(resultados);
        }

        private void MostrarResultados(List<Produto> produtos)
        {
            painelResultados.Controls.Clear();

            foreach (var p in produtos)
            {
                Panel card = new Panel
                {
                    Size = new Size(380, 100),
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(10)
                };

                Label lblNome = new Label
                {
                    Text = p.Nome,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblPreco = new Label
                {
                    Text = $"Preço:  {p.Preco:0.00}Kz",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblCategoria = new Label
                {
                    Text = $"Categoria: {p.Categoria}",
                    Location = new Point(10, 55),
                    AutoSize = true
                };

                Button btnCarrinho = new Button
                {
                    Text = "Adicionar ao Carrinho 🛒",
                    Location = new Point(220, 30),
                    Size = new Size(140, 30),
                    BackColor = Color.DarkGreen,
                    ForeColor = Color.White,
                    Tag = p
                };
                btnCarrinho.Click += BtnCarrinho_Click;

                card.Controls.AddRange(new Control[] { lblNome, lblPreco, lblCategoria, btnCarrinho });
                painelResultados.Controls.Add(card);
            }
        }

        private void BtnCarrinho_Click(object sender, EventArgs e)
        {
            var produto = (Produto)((Button)sender).Tag;
            Carrinho.Adicionar(produto);
            MessageBox.Show($"Produto \"{produto.Nome}\" adicionado ao carrinho! Total de itens: {Carrinho.QuantidadeItens()}");
            
        }
    }
}