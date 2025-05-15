//  a pasta Tela

using System;
using System.Drawing;
using System.Windows.Forms;



using GestaoSimples.Servicos;
using GestaoSimples.Modelos;
// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 

namespace GestaoSimples.Telas {
    public class TelaLogin : Form {
        
        private Label Titulo;

        private Label lblEmail;
        private TextBox txtEmail;
        
        private Label lblSenha;
        private TextBox txtSenha;

        private Button btnEntrar;



        public TelaLogin() {

            this.Text = "GestãoSimples - Login";
            this.Width = 800;
            this.Height = 500;
            this.Resize += Evento_aumentarJanela;
            this.StartPosition = FormStartPosition.CenterScreen;
            


            lblEmail = new Label() {
                Text = "Digite o Email:",
                Left = 300,
                Top = 40,
                Width = 120
            };            
            txtEmail = new TextBox() { 
                Left =  300,
                Top = 100,
                Width = 200
            };


            lblSenha = new Label() {
                Text = "Digite a Senha:",
                Location = new Point(300, 120),
                Width = 120
            };
            txtSenha = new TextBox() {
                Left = 300,
                Top = 150,
                Width = 200,
                UseSystemPasswordChar = true
            };


            btnEntrar = new Button() {
                Text = "Entrar",
                Left = 100,
                Top = 300,
                Width = 100
            };
            btnEntrar.Click += Evento_tocarBotao;

            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblSenha);
            this.Controls.Add(txtSenha);
            this.Controls.Add(btnEntrar);
        }


        // Todos Meus Eventos
        private void Evento_tocarBotao(object sender, EventArgs e) {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            Ususario usuario = AutenticacaoServico.Autenticar(email, senha);

            if (usuario != null) {
                MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Login OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var dashboard = new TelaDashboard(usuario);
                dashboard.Show();
                this.Hide();

            }
            
            else { MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }}    // m -> t -> b -> i

        private void Evento_aumentarJanela(object sender, EventArgs e) {    // Centralizo alguns componentes
            
            lblEmail.Left = (this.ClientSize.Width - lblEmail.Width) / 2;
            txtEmail.Left = (this.ClientSize.Width - txtEmail.Width) / 2;

            lblSenha.Left = (this.ClientSize.Width - txtSenha.Width) / 2;
            txtSenha.Left = (this.ClientSize.Width - txtSenha.Width) / 2;


            btnEntrar.Left = (this.ClientSize.Width - btnEntrar.Width) / 2;
        }
    }
}
