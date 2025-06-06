using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GestaoSimples.Modelos;
using GestaoSimples.Servicos;

// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

namespace GestaoSimples.Telas
{
    public class TelaPedidosFornecedor : UserControl
    {
        private DataGridView dgv;
        private Button btnMarcarEntregue;
        private int fornecedorId;

        public TelaPedidosFornecedor(int fornecedorLogadoId)
        {
            this.fornecedorId = fornecedorLogadoId;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            InicializarControles();
            CarregarPedidos();
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Meus Pedidos Reencaminhados",
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
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "Solicitante", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data", DataPropertyName = "DataPedido", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            btnMarcarEntregue = new Button
            {
                Text = "Marcar como Entregue",
                Location = new Point(20, 380),
                Size = new Size(200, 35),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White
            };
            btnMarcarEntregue.Click += BtnMarcarEntregue_Click;

            this.Controls.AddRange(new Control[] { lblTitulo, dgv, btnMarcarEntregue });
        }               // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

        private void CarregarPedidos()
        {
            dgv.DataSource = PedidoServico.ListarPorFornecedor(fornecedorId);
        }

        private void BtnMarcarEntregue_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            var pedido = (Pedido)dgv.CurrentRow.DataBoundItem;

            if (pedido.Status == "entregue")
            {
                MessageBox.Show("Este pedido já foi marcado como entregue.");
                return;
            }

            PedidoServico.AtualizarStatus(pedido.Id, "entregue");
            MessageBox.Show("Pedido marcado como entregue.");
            CarregarPedidos();
        }
    }
}
// 2-5-14-25    -... . -. -.--   .-. . .. ...