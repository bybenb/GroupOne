//  a pasta Modelos

using System;
using System.Windows.Forms;
using GestaoSimples.Servicos;
using GestaoSimples.Modelos;

namespace GestaoSimples.Telas
{
    public class TelaLogin : Form
    {
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnEntrar;

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            Ususario usuario = AutenticacaoServico.Autenticar(email, senha);

            if (usuario != null) {
                MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Login OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // futuramente abrir a tela principal
            }
            else {
                MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public TelaLogin()
        {
            this.Text = "GestãoSimples - Login";
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblEmail = new Label() { Text = "Email:", Left = 20, Top = 20, Width = 80 };
            txtEmail = new TextBox() { Left = 100, Top = 20, Width = 150 };

            Label lblSenha = new Label() { Text = "Senha:", Left = 20, Top = 60, Width = 80 };
            txtSenha = new TextBox() { Left = 100, Top = 60, Width = 150, UseSystemPasswordChar = true };

            btnEntrar = new Button() { Text = "Entrar", Left = 100, Top = 100, Width = 100 };
            btnEntrar.Click += BtnEntrar_Click;

            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblSenha);
            this.Controls.Add(txtSenha);
            this.Controls.Add(btnEntrar);
        }

    }
}
