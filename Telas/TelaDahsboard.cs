//  a pasta Telas

using System;
using System.Drawing;
using System.Windows.Forms;


using GestaoSimples.Servicos;
using GestaoSimples.BancoDados;
using GestaoSimples.Componentes;
using GestaoSimples.Utilitarios;
using GestaoSimples.Modelos;
using System.Globalization;
// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 


namespace GestaoSimples.Telas
{
    public class TelaDashboard : Form
    {

        private Panel painel_Cabecalho = new Panel();
        private Panel painel_conteudo = new Panel();
        private Ususario usuarioLogado;

        public TelaDashboard(Ususario usuario)
        {
            this.usuarioLogado = usuario;

            this.Text = "Gestão Simples";
            
            Estilos.DoFormulario(this);




            CriarMenuLateral();
            CriarCabecalho();
            Criarpainel_conteudo();
        }

        private void CriarMenuLateral()
        {
            var menu = new MenuLateral();

            menu.NavegacaoSelecionada += NavegarPara;
            this.Controls.Add(menu);
        }

        private void NavegarPara(string destino)
        {
            switch (destino)
            {
                case "Dashboard":
                    painel_conteudo.Controls.Clear();
                    break;
                case "Produtos":
                    CarregarTela(new TelaProdutos());
                    break;
                case "Usuarios":
                    CarregarTela(new TelaUsuarios());
                    break;
                case "Sair":
                    Application.Exit();
                    break;
            }
        }


        private void CriarCabecalho()
        {
            painel_Cabecalho = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.WhiteSmoke
            };

            Label lblBemVindo = new Label
            {
                Text = $"Bem-vindo, {usuarioLogado.Nome}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 18),
                AutoSize = true
            };

            CultureInfo idioma = new CultureInfo("pt-BR");  //  en-US
            Label lblData = new Label
            {
                
                Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", idioma),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),  // FONSAIZESTE (FONTE+SIZE+STYLE)
                Location = new Point(400, 20),
                AutoSize = true
            };

            painel_Cabecalho.Controls.Add(lblBemVindo);
            painel_Cabecalho.Controls.Add(lblData);

            this.Controls.Add(painel_Cabecalho);
        }


        private void Criarpainel_conteudo()
        {
            painel_conteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(100),
                AutoScroll = true
            };

            flow.Controls.Add(CriarCard("Vendas do Mês", "25.000 Kz"));
            flow.Controls.Add(CriarCard("Receita vs Despesa", "[gráfico]"));
            flow.Controls.Add(CriarCard("Pedidos Recentes", "4 pendentes"));
            flow.Controls.Add(CriarCard("Clientes", "10 cadastrados"));

            painel_conteudo.Controls.Add(flow);
            this.Controls.Add(painel_conteudo);
        }

        private Panel CriarCard(string titulo, string valor, string imagem = "")
        {
            var card = new Panel
            {
                Width = 260,
                Height = 120,
                BackColor = Color.Gainsboro,
                Location = new Point(250, 100),
                Margin = new Padding(30),
                BorderStyle = BorderStyle.FixedSingle
            };

            if (!string.IsNullOrEmpty(imagem))
            {
                PictureBox icon = new PictureBox
                {
                    Image = Image.FromFile(imagem),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(180, 10),
                    Size = new Size(60, 60)
                };
                card.Controls.Add(icon);
            }

            Label lblTitulo = new Label
            {
                Text = titulo,
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true
            };

            Label lblValor = new Label
            {
                Text = valor,
                Location = new Point(10, 45),
                Font = new Font("Segoe UI", 18, FontStyle.Regular),
                AutoSize = true
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);

            return card;
        }
        private void CarregarTela(Control novaTela)
        {
            painel_conteudo.Controls.Clear();
            novaTela.Dock = DockStyle.Fill;
            painel_conteudo.Controls.Add(novaTela);
        }

    }

}
// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 