using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Servicos;
using GestaoSimples.Modelos;

namespace GestaoSimples.Telas
{
    public class TelaCadastro : Form
    {
        private TextBox txtNome, txtEmail, txtSenha;
        private ComboBox cmbTipo;
        private Button btnCadastrar, btnCancelar;

        public TelaCadastro()
        {
            this.Text = "Criar Conta - GestãoSimples";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarControles();
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Criar Conta",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            Label lblNome = new Label { Text = "Nome:", Location = new Point(20, 70) };
            txtNome = new TextBox { Location = new Point(100, 70), Width = 250 };

            Label lblEmail = new Label { Text = "Email:", Location = new Point(20, 110) };
            txtEmail = new TextBox { Location = new Point(100, 110), Width = 250 };

            Label lblSenha = new Label { Text = "Senha:", Location = new Point(20, 150) };
            txtSenha = new TextBox { Location = new Point(100, 150), Width = 250, UseSystemPasswordChar = true };

            Label lblTipo = new Label { Text = "Tipo de Conta:", Location = new Point(20, 190) };
            cmbTipo = new ComboBox
            {
                Location = new Point(130, 190),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipo.Items.AddRange(new string[] { "utilizador", "fornecedor" });

            btnCadastrar = new Button
            {
                Text = "Cadastrar",
                Location = new Point(60, 240),
                Width = 100,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White
            };
            btnCadastrar.Click += BtnCadastrar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(200, 240),
                Width = 100,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblTitulo, lblNome, txtNome,
                lblEmail, txtEmail,
                lblSenha, txtSenha,
                lblTipo, cmbTipo,
                btnCadastrar, btnCancelar
            });
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text) ||
                cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            var novoUsuario = new Ususario
            {
                Nome = txtNome.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
                Tipo = cmbTipo.SelectedItem.ToString()
            };

            UsuarioServico.Cadastrar(novoUsuario);

            MessageBox.Show("Conta criada com sucesso. Faça login para continuar.");
            this.Close();
        }
    }
}
