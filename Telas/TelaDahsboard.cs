//  a pasta Telas

using System;
using System.Drawing;
using System.Windows.Forms;


using GestaoSimples.Servicos;
using GestaoSimples.BancoDados;
using GestaoSimples.Componentes;
using GestaoSimples.Utilitarios;
using GestaoSimples.Modelos;
using GestaoSimples.Telas.Publico;
using System.Globalization;
// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 


namespace GestaoSimples.Telas
{

    public class TelaDashboard : Form
    {

        private Panel painelCabecalho;
        private MenuLateral menu;

        private Ususario usuarioLogado;

        public TelaDashboard(Ususario U_Logado)
        {
            this.Text = "Gestão Simples";
            this.WindowState = FormWindowState.Maximized;


            ConfigurarInterface();
            
            Estilos.DoFormulario(this);
        }

        private void ConfigurarInterface()
        {
            this.Controls.Clear();
            this.BackColor = Color.White;


            menu = new MenuLateral();
            menu.Evento_Botaotocado += oSelecionado;
            this.Controls.Add(menu);


            CarregarTela("Dashboard");
        }

        private void oSelecionado(string destino)
        {
            CarregarTela(destino);
        }

        private void CarregarTela(string tela)
        {
            // Todos Controles antigos vao sair, exceto o menu
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != menu)
                {
                    this.Controls.Remove(ctrl);
                    break;
                }
            }

            UserControl telaCarregada = null;

            switch (tela)
            {
                case "Dashboard":
                    telaCarregada = new OpcaoDashboard();
                    break;
                case "Produtos":
                    telaCarregada = new TelaProdutos();
                    break;
                case "Usuários":
                    telaCarregada = new TelaUsuarios();
                    break;
                case "Logout":
                    Application.Exit();
                    return;
            }

            if (telaCarregada != null)
            {
                telaCarregada.Dock = DockStyle.Fill;
                telaCarregada.Left = menu.Width;
                this.Controls.Add(telaCarregada);
                telaCarregada.BringToFront();
            }
        }


        // private void CriarCabecalho()
        // {
        //     painelCabecalho = new Panel
        //     {
        //         Size = new Size(this.Width - menu.Width, 60),
        //         Left = menu.Width,
        //         BackColor = Color.WhiteSmoke

        //     };

        //     Label lblBemVindo = new Label
        //     {
        //         Text = $"Bem-vindo, {usuarioLogado.Nome}",
        //         Font = new Font("Segoe UI", 12, FontStyle.Bold),
        //         Location = new Point(20, 18),
        //         AutoSize = true
        //     };

        //     Label lblData = new Label
        //     {
        //         Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy"),
        //         Font = new Font("Segoe UI", 10, FontStyle.Italic),
        //         Location = new Point(400, 20),
        //         AutoSize = true
        //     };

        //     painelCabecalho.Controls.Add(lblBemVindo);
        //     painelCabecalho.Controls.Add(lblData);

        //     this.Controls.Add(painelCabecalho);
        // }

    }


}