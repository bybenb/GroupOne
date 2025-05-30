using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoSimples.Componentes
{
    public class MenuLateral : UserControl
    {
        public event Action<string>? NavegacaoSelecionada;

        public MenuLateral()
        {
            this.Width = 180;
            this.Dock = DockStyle.Left;
            this.BackColor = ColorTranslator.FromHtml("#2D2D30");


            Button btnDashboard = CriarBotao("Dashboard");
            Button btnProdutos = CriarBotao("Produtos");
            Button btnUsuarios = CriarBotao("Usuários");
            Button btnSair = CriarBotao("Sair");

            btnDashboard.Click += (s, e) => NavegacaoSelecionada?.Invoke("Dashboard");
            btnProdutos.Click += (s, e) => NavegacaoSelecionada?.Invoke("Produtos");
            btnUsuarios.Click += (s, e) => NavegacaoSelecionada?.Invoke("Usuarios");
            btnSair.Click += (s, e) => NavegacaoSelecionada?.Invoke("Sair");

            this.Controls.AddRange(new Control[] { btnSair, btnUsuarios, btnProdutos, btnDashboard });
        }

        private Button CriarBotao(string texto)
        {
            return new Button
            {
                Text = texto,
                Dock = DockStyle.Top,
                Height = 50,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = ColorTranslator.FromHtml("#2D2D30"),
                
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 }
            };
        }
    }
}


