using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Servicos;
using GestaoSimples.Modelos;
using System.Collections.Generic;

namespace GestaoSimples.Telas
{
    public class TelaContaUtilizador : UserControl
    {
        private TabControl abas;
        private int usuarioId;

        public TelaContaUtilizador(int idUsuario)
        {
            usuarioId = idUsuario;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            abas = new TabControl { Dock = DockStyle.Fill };

            abas.TabPages.Add(CriarTabComprasPendentes());
            abas.TabPages.Add(CriarTabHistorico());
            abas.TabPages.Add(CriarTabMeusDados());

            this.Controls.Add(abas);
        }

        private TabPage CriarTabComprasPendentes()
        {
            var tab = new TabPage("Compras Pendentes");
            var dgv = CriarGridPedidos();
            dgv.DataSource = PedidoServico.ListarDoUsuario(usuarioId, "pendente");
            tab.Controls.Add(dgv);
            return tab;
        }

        private TabPage CriarTabHistorico()
        {
            var tab = new TabPage("Histórico de Compras");
            var dgv = CriarGridPedidos();
            dgv.DataSource = PedidoServico.ListarDoUsuario(usuarioId, "entregue");
            tab.Controls.Add(dgv);
            return tab;
        }

        private TabPage CriarTabMeusDados()
        {
            var tab = new TabPage("Meus Dados");
            var usuario = UsuarioServico.BuscarPorId(usuarioId);

            Label lblNome = new Label { Text = "Nome:", Location = new Point(20, 30) };
            Label lblEmail = new Label { Text = "Email:", Location = new Point(20, 70) };
            Label lblTipo = new Label { Text = "Tipo de Conta:", Location = new Point(20, 110) };

            Label lblNomeValor = new Label { Text = usuario.Nome, Location = new Point(120, 30), AutoSize = true };
            Label lblEmailValor = new Label { Text = usuario.Email, Location = new Point(120, 70), AutoSize = true };
            Label lblTipoValor = new Label { Text = usuario.Tipo, Location = new Point(120, 110), AutoSize = true };

            tab.Controls.AddRange(new Control[] { lblNome, lblNomeValor, lblEmail, lblEmailValor, lblTipo, lblTipoValor });
            return tab;
        }

        private DataGridView CriarGridPedidos()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Produto", DataPropertyName = "ProdutoNome", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data", DataPropertyName = "DataPedido", Width = 160 });

            return dgv;
        }
    }
}