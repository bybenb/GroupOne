using System;
using System.Drawing;
using System.Windows.Forms;

// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'   


namespace GestaoSimples.Componentes
{
    public class MenuLateral : UserControl
    {
        private Button botaoSelecionado;
        private Panel indicador;

        public event Action<string> Evento_Botaotocado;

        public MenuLateral()
        {
            this.Width = 180;
            this.Dock = DockStyle.Left;
            this.BackColor = Color.FromArgb(45, 45, 48);

            
            indicador = new Panel
            {
                Size = new Size(5, 50),
                BackColor = ColorTranslator.FromHtml("#5cd4d4"),
                Visible = false
            };
            this.Controls.Add(indicador);

            
            var btnDashboard = CriarBotao("Dashboard");
            var btnProdutos = CriarBotao("Produtos");
            var btnUsuarios = CriarBotao("Usuários");
            var btnSair = CriarBotao("Sair");

            // Adiciona por ordem (bottom-up)
            this.Controls.AddRange(new Control[] { btnSair, btnUsuarios, btnProdutos, btnDashboard });
        }

        private Button CriarBotao(string texto)
        {
            var btn = new Button
            {
                Text = texto,
                Dock = DockStyle.Top,
                Height = 50,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(45, 45, 48),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 },
                Tag = texto
            };

            btn.Click += (s, e) =>
            {
                Destaque_NoJutsu(btn);
                // Mapear “Sair” para “Logout”
                var destino = texto == "Sair" ? "Logout" : texto;
                Evento_Botaotocado?.Invoke(destino);
            };

            return btn;
        }

        private void Destaque_NoJutsu(Button btn)
        {
            
            if (botaoSelecionado != null)
                botaoSelecionado.BackColor = Color.FromArgb(45, 45, 48);

            
            botaoSelecionado = btn;
            botaoSelecionado.BackColor = Color.FromArgb(70, 70, 90);

            
            indicador.Height = btn.Height;
            indicador.Top = btn.Top;
            indicador.Left = 0;
            indicador.Visible = true;
            indicador.BringToFront();
        }
    }  //  -... . -. -.--   .-. . .. ... (MORSE CODE) 
}
// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'