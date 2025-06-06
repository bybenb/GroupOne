using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Modelos;
using GestaoSimples.Telas.Publico;
using GestaoSimples.Servicos;
using System.Collections.Generic;

namespace GestaoSimples.Telas
{
    public class TelaUsuarios : UserControl
    {
        private DataGridView dgvUsuarios;
        private TextBox txtNome, txtEmail, txtSenha;
        private ComboBox cmbTipo;
        private Button btnNovo, btnSalvar, btnEditar, btnExcluir;

        private Ususario usuarioSelecionado;

        public TelaUsuarios()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            InicializarControles();
            CarregarUsuarios();
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Gestão de Usuários",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true
            };
            this.Controls.Add(lblTitulo);

            dgvUsuarios = new DataGridView
            {
                Location = new Point(20, 50),
                Size = new Size(740, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false
            };
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nome", DataPropertyName = "Nome", Width = 150 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Width = 200 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo", DataPropertyName = "Tipo", Width = 100 });
            dgvUsuarios.CellClick += DgvUsuarios_CellClick;
            this.Controls.Add(dgvUsuarios);

            Label lblNome = new Label { Text = "Nome:", Location = new Point(20, 270) };
            txtNome = new TextBox { Location = new Point(80, 270), Width = 200 };

            Label lblEmail = new Label { Text = "Email:", Location = new Point(300, 270) };
            txtEmail = new TextBox { Location = new Point(360, 270), Width = 240 };

            Label lblSenha = new Label { Text = "Senha:", Location = new Point(20, 310) };
            txtSenha = new TextBox { Location = new Point(80, 310), Width = 200, UseSystemPasswordChar = true };

            Label lblTipo = new Label { Text = "Tipo:", Location = new Point(300, 310) };
            cmbTipo = new ComboBox
            {
                Location = new Point(360, 310),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipo.Items.AddRange(new string[] { "estoquista", "Fornecedor", "utilizador" });

            btnNovo = CriarBotao("Novo", new Point(20, 360), BtnNovo_Click);
            btnSalvar = CriarBotao("Salvar", new Point(120, 360), BtnSalvar_Click);
            btnEditar = CriarBotao("Editar", new Point(220, 360), BtnEditar_Click);
            btnExcluir = CriarBotao("Excluir", new Point(320, 360), BtnExcluir_Click);

            this.Controls.AddRange(new Control[]
            {
                lblNome, txtNome, lblEmail, txtEmail, lblSenha, txtSenha,
                lblTipo, cmbTipo,
                btnNovo, btnSalvar, btnEditar, btnExcluir
            });
        }

        private Button CriarBotao(string texto, Point posicao, EventHandler evento)
        {
            Button b = new Button
            {
                Text = texto,
                Location = posicao,
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            b.parausuario(btn => btn.Click += evento);
            return b;
        }

        private void CarregarUsuarios()
        {
            dgvUsuarios.DataSource = UsuarioServico.ListarTodos();
            LimparCampos();
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                usuarioSelecionado = (Ususario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
                txtNome.Text = usuarioSelecionado.Nome;
                txtEmail.Text = usuarioSelecionado.Email;
                cmbTipo.SelectedItem = usuarioSelecionado.Tipo;
                txtSenha.Clear(); 
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e) => LimparCampos();

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var novo = new Ususario
            {
                Nome = txtNome.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
                Tipo = cmbTipo.SelectedItem?.ToString() ?? "visualizador"
            };

            UsuarioServico.Cadastrar(novo);
            CarregarUsuarios();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionado == null) return;

            usuarioSelecionado.Nome = txtNome.Text.Trim();
            usuarioSelecionado.Email = txtEmail.Text.Trim();
            usuarioSelecionado.Tipo = cmbTipo.SelectedItem?.ToString() ?? "visualizador";

            UsuarioServico.Atualizar(usuarioSelecionado);
            CarregarUsuarios();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionado == null) return;

            if (MessageBox.Show("Deseja excluir este usuário?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UsuarioServico.Remover(usuarioSelecionado.Id);
                CarregarUsuarios();
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            cmbTipo.SelectedIndex = -1;
            usuarioSelecionado = null;
        }
    }

    // para eventos encadeados
    public static class Extensao_U
    {
        public static T parausuario<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
    }
}

















































// using System;
// using System.Drawing;
// using System.Windows.Forms;

// namespace GestaoSimples.Telas
// {
//     public class TelaUsuarios : UserControl
//     {
//         public TelaUsuarios()
//         {
//             this.BackColor = Color.White;
//             this.Dock = DockStyle.Fill;

//             Label lbl = new Label
//             {
//                 Text = "Meu Ususario",
//                 Font = new Font("Segoe UI", 14, FontStyle.Bold),
//                 AutoSize = true,
//                 Location = new Point(20, 20)
//             };

//             this.Controls.Add(lbl);
//         }
//     }
// }
