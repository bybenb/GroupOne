using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Servicos;
using GestaoSimples.Modelos;

namespace GestaoSimples.Telas
{
    public class TelaGestaoPedidos : UserControl
    {
        private DataGridView dgv;
        private Button btnReencaminhar, btnCancelar;

        public TelaGestaoPedidos()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            InicializarControles();
            CarregarPedidos();
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Pedidos Pendentes",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            dgv = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(800, 300),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Produto", DataPropertyName = "ProdutoNome", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quem Pediu", DataPropertyName = "Solicitante", Width = 180 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data", DataPropertyName = "DataPedido", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            btnReencaminhar = new Button
            {
                Text = "Reencaminhar ao Fornecedor",
                Location = new Point(20, 380),
                Size = new Size(240, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnReencaminhar.Click += BtnReencaminhar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar Pedido",
                Location = new Point(280, 380),
                Size = new Size(160, 35),
                BackColor = Color.Firebrick,
                ForeColor = Color.White
            };
            btnCancelar.Click += BtnCancelar_Click;

            this.Controls.AddRange(new Control[] { lblTitulo, dgv, btnReencaminhar, btnCancelar });
        }

        private void CarregarPedidos()
        {
            dgv.DataSource = PedidoServico.ListarPendentesComDetalhes();
        }

        private void BtnReencaminhar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            var pedido = (Pedido)dgv.CurrentRow.DataBoundItem;

            // Janela para escolher fornecedor
            var fornecedores = UsuarioServico.ListarPorTipo("fornecedor");
            if (fornecedores.Count == 0)
            {
                MessageBox.Show("Nenhum fornecedor cadastrado.");
                return;
            }

            var selecao = new Form { Text = "Selecionar Fornecedor", Size = new Size(400, 200) };
            var cmb = new ComboBox { Location = new Point(20, 20), Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var f in fornecedores)
                cmb.Items.Add(new ComboItem(f.Id, $"{f.Nome} ({f.Email})"));

            var btnOK = new Button { Text = "Confirmar", Location = new Point(140, 70), DialogResult = DialogResult.OK };
            selecao.Controls.AddRange(new Control[] { cmb, btnOK });
            selecao.AcceptButton = btnOK;

            if (selecao.ShowDialog() == DialogResult.OK && cmb.SelectedItem != null)
            {
                var item = (ComboItem)cmb.SelectedItem;
                PedidoServico.ReencaminharParaFornecedor(pedido.Id, item.Id);
                MessageBox.Show("Pedido reencaminhado com sucesso.");
                CarregarPedidos();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            var pedido = (Pedido)dgv.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Deseja cancelar o pedido?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PedidoServico.AtualizarStatus(pedido.Id, "cancelado");
                CarregarPedidos();
            }
        }

        private class ComboItem
        {
            public int Id { get; }
            public string NomeExibicao { get; }

            public ComboItem(int id, string nome)
            {
                Id = id;
                NomeExibicao = nome;
            }

            public override string ToString() => NomeExibicao;
        }
    }
}