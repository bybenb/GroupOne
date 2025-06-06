using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Telas.Publico;

namespace GestaoSimples.Telas
{
    public class TelaInicial : Form
    {
        private Button btnEntrar;
        private Button btnCadastrar;
        private TelaPesquisa pesquisa;

        public TelaInicial()
        {
            this.Text = "GestãoSimples - Pesquisa";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            InicializarControles();

            this.Load += (s, e) => ReposicionarBotoes();
            this.Resize += (s, e) => ReposicionarBotoes();
        }

        private void InicializarControles()
        {

            pesquisa = new TelaPesquisa();
            pesquisa.Dock = DockStyle.Fill;
            this.Controls.Add(pesquisa);


            btnEntrar = new Button
            {
                Text = "Entrar",
                Width = 90,
                Height = 30,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnEntrar.Click += (s, e) =>
            {
                this.Hide();
                new TelaLogin().Show();
            };
            this.Controls.Add(btnEntrar);


            btnCadastrar = new Button
            {
                Text = "Cadastrar",
                Width = 100,
                Height = 30,
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCadastrar.Click += (s, e) =>
            {
                new TelaCadastro().ShowDialog();
            };
            this.Controls.Add(btnCadastrar);
        }

        private void ReposicionarBotoes()
        {
            int padding = 20;

            btnCadastrar.Top = padding;
            btnEntrar.Top = padding;

            btnCadastrar.Left = this.ClientSize.Width - btnCadastrar.Width - padding;
            btnEntrar.Left = btnCadastrar.Left - btnEntrar.Width - 10;
        }
    }
}



// namespace GestaoSimples.Telas
// {
//     public class TelaInicial : Form
//     {
//         public TelaInicial()
//         {
//             this.Text = "GestãoSimples - Busca Local";
//             this.WindowState = FormWindowState.Maximized;
//             this.BackColor = Color.White;

            
//             var pesquisa = new TelaPesquisa();
//             this.Controls.Add(pesquisa);


//             var btnLogin = new Button
//             {
//                 Text = "Entrar",
//                 Width = 80,
//                 Height = 430,
//                 Top = 20,
//                 Left = this.Width - 200,
//                 Anchor = AnchorStyles.Top | AnchorStyles.Right
//             };
//             btnLogin.Click += (s, e) =>
//             {
//                 this.Hide();
//                 new TelaLogin().Show();
//             };


//             this.Controls.Add(btnLogin);

//             // Botão "Cadastrar"
//             var btnCadastrar = new Button
//             {
//                 Text = "Cadastrar",
//                 Width = 680,
//                 Height = 430,
//                 Top = 20,
//                 Left = this.Width - 110,
//                 Anchor = AnchorStyles.Top | AnchorStyles.Right
//             };


//             btnCadastrar.Click += (s, e) =>
//             {
//                 new TelaCadastro().ShowDialog();
//             };


            
//             this.Controls.Add(btnCadastrar);
//         }
//     }
// }