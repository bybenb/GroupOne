using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Modelos;
using GestaoSimples.Utilitarios;
using GestaoSimples.Servicos;

namespace GestaoSimples.Telas.Publico
{
    public class TelaFinalizarPedido : UserControl
    {
        private Label lblResumo;
        private ListBox lstItens;
        private Label lblTotal;
        private Button btnConfirmar;

        // Somente para visitante
        private TextBox txtNome, txtEmail, txtLocal;
        private bool isVisitante;
        private Ususario usuarioLogado;

        public TelaFinalizarPedido(Ususario usuario = null)
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            isVisitante = usuario == null;
            usuarioLogado = usuario;

            InicializarControles();
            MostrarCarrinho();
        }

        private void InicializarControles()
        {
            lblResumo = new Label
            {
                Text = "Resumo do Pedido",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            lstItens = new ListBox
            {
                Location = new Point(20, 60),
                Size = new Size(400, 150)
            };

            lblTotal = new Label
            {
                Text = "Total: 0,00Kz",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 220),
                AutoSize = true
            };

            btnConfirmar = new Button
            {
                Text = "Confirmar Pedido",
                Location = new Point(20, 270),
                Size = new Size(160, 35),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White
            };
            btnConfirmar.Click += BtnConfirmar_Click;

            this.Controls.AddRange(new Control[] { lblResumo, lstItens, lblTotal });

            if (isVisitante)
            {
                Label lblNome = new Label { Text = "Seu nome:", Location = new Point(450, 60) };
                txtNome = new TextBox { Location = new Point(450, 80), Width = 250 };

                Label lblEmail = new Label { Text = "Seu email:", Location = new Point(450, 120) };
                txtEmail = new TextBox { Location = new Point(450, 140), Width = 250 };

                Label lblLocal = new Label { Text = "Lugar de Entrega:", Location = new Point(450, 180) };
                txtLocal = new TextBox { Location = new Point(450, 200), Width = 250 };

                this.Controls.AddRange(new Control[]
                {
                    lblNome, txtNome,
                    lblEmail, txtEmail,
                    lblLocal, txtLocal
                });
            }

            this.Controls.Add(btnConfirmar);
        }

        private void MostrarCarrinho()
        {
            var produtos = Carrinho.Listar();
            lstItens.Items.Clear();

            decimal total = 0;
            foreach (var p in produtos)
            {
                lstItens.Items.Add($"{p.Nome} -  {p.Preco:0.00}Kz");
                total += p.Preco;
            }

            lblTotal.Text = $"Total: {total:0.00}Kz";
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            var produtos = Carrinho.Listar();

            if (produtos.Count == 0)
            {
                MessageBox.Show("Seu carrinho está vazio.");
                return;
            }

            if (isVisitante)
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtLocal.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os dados.");
                    return;
                }

                PedidoServico.RegistrarComoVisitante(produtos, txtNome.Text, txtEmail.Text, txtLocal.Text);
            }
            else
            {
                PedidoServico.RegistrarComoUtilizador(produtos, usuarioLogado.Id);
            }

            Carrinho.Limpar();
            MessageBox.Show("Pedido realizado com sucesso!");
            lstItens.Items.Clear();
            lblTotal.Text = "Total: 0,00Kz";
        }
    }
}