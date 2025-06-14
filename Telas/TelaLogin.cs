//  a pasta Tela

using System;
using System.Drawing;
using System.Windows.Forms;


using GestaoSimples.Componentes;
using GestaoSimples.BancoDados;
using GestaoSimples.Servicos;
using GestaoSimples.Modelos;
using GestaoSimples.Telas.Publico;
using GestaoSimples.Utilitarios;

// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 

namespace GestaoSimples.Telas {
    public class TelaLogin : Form {

        private Label Titulo;
        private Label copyrightt;

        private Label lblEmail;
        private TextBox txtEmail;
        
        private Label lblSenha;
        private TextBox txtSenha;

        private Button btnEntrar;




        public TelaLogin()
        {

            this.Text = "GestãoSimples - Login";
            this.MaximizeBox = false;


            Titulo = new Label();


            lblEmail = new Label()
            {
                Text = "Digite o Email:",
                Location = new Point(300, 127),
                AutoSize = true
            };
            txtEmail = new TextBox()
            {
                Left = 270,
                Top = 150,
                Width = 230
            };


            lblSenha = new Label()
            {
                Text = "Digite a Senha:",
                Location = new Point(300, 190),
                AutoSize = true,
            };
            txtSenha = new TextBox()
            {
                Left = 270,
                Top = 210,
                Width = 230,
                UseSystemPasswordChar = true
            };



            btnEntrar = new Button()
            {
                Text = "Entrar",
                Left = 325,
                Top = 282,
                Width = 150
            };
            btnEntrar.Click += Evento_tocarBotao;


            copyrightt = new Label()
            {
                Text = "© 2025 Grupo One. Todos Direitos reservados à Eng. Joana Bungo.",
                AutoSize = true,
                Location = new Point(235, 420),
                // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
                Font = new Font("Segoe UI", 8, FontStyle.Underline)
            };


            Estilos.DoBotao(btnEntrar);
            Estilos.DoTitulo(Titulo, "MarketPlace - GS");
            Controls.Add(Titulo);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblSenha);
            this.AcceptButton = btnEntrar;          // assim, o ENTER dentro do txtSenha, vai dar DATTEBAYO
            this.Controls.Add(txtSenha);
            this.Controls.Add(btnEntrar);
            this.Controls.Add(copyrightt);
            this.Resize += Evento_aumentarJanela;
            Estilos.DoFormulario(this);
            this.FormClosing += (a, b) => {
                MessageBox.Show("Se queres sair, não volta+", "Tás Saindo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (!b.Cancel)
                {
                    Application.Exit();
                    return;
                 }
                };
            // NotifyIcon Logo = new NotifyIcon
            // {
            //     Icon = new Icon("imagens/img_logo-gs.ico"),  // Ícone da barra de tarefas (second plane)
            //     Visible = true
            // };


        }


        // Todos Meus Eventos
        private void Evento_tocarBotao(object? sender, EventArgs e) {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            Ususario? usuario = AutenticacaoServico.Autenticar(email, senha);

            if (usuario != null)
            {
                MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Login OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new TelaDashboard(usuario).Show();
                this.Hide();


                switch (usuario.Tipo.ToLower())
                {
                    case "admin":
                    case "funcionario":
                        new TelaDashboard(usuario).Show(); // se desejar, pode passar dados
                        break;
                    case "fornecedor":
                        new TelaPedidosFornecedor(usuario.Id).Show();
                        break;
                    case "utilizador":
                        new TelaContaUtilizador(usuario.Id).Show();
                        break;
                    default:
                        MessageBox.Show("Tipo de usuário não reconhecido.");
                        this.Close();
                        break;
                }


                // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
            }

            else { MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }    // m -> t -> b -> i

        private void Evento_aumentarJanela(object? sender, EventArgs e)
        {    // Centralizo alguns componentes

            lblEmail.Left = (this.ClientSize.Width - txtEmail.Width) / 2;
            txtEmail.Left = (this.ClientSize.Width - txtEmail.Width) / 2;

            lblSenha.Left = (this.ClientSize.Width - txtSenha.Width) / 2;
            txtSenha.Left = (this.ClientSize.Width - txtSenha.Width) / 2;
            // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'


            btnEntrar.Left = (this.ClientSize.Width - btnEntrar.Width) / 2;
            copyrightt.Left = (this.ClientSize.Width - copyrightt.Width) / 2;
            Titulo.Left = (ClientSize.Width - Titulo.Width) / 2;
        }
    }
}


// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 