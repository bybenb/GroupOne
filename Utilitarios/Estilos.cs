using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
// 2-5-14-25    -... . -. -.--   .-. . .. ...


using GestaoSimples.Servicos;
using GestaoSimples.Modelos;
using GestaoSimples.Utilitarios;
using GestaoSimples.Telas.Publico;
using System.Globalization;

namespace GestaoSimples.Utilitarios
{


    public class Estilos
    {   
        
        
        public static void DoFormulario(Form Janela)
        {

            Janela.BackColor = ColorTranslator.FromHtml("#f2f4f1");
            Janela.ForeColor = ColorTranslator.FromHtml("#15465a");
            Janela.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            Janela.Width = 800;
            Janela.Height = 500;
            Janela.StartPosition = FormStartPosition.CenterScreen;
            Janela.Icon = new Icon("imagens/img_logo-gs.ico");
            _ = new NotifyIcon
            {
                Icon = new Icon("imagens/img_logo-gs.ico"), 
                Visible = true
            };

        }

        public static void DoBotao(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = ColorTranslator.FromHtml("#15465a");
            b.ForeColor = Color.Gray;
            b.Font = new Font("Arial", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.TextAlign = ContentAlignment.MiddleCenter;
        }


        public static void DoTitulo(Label titulo, String texto)
        {
            titulo.Text = texto;
            titulo.AutoSize = true;
            titulo.Location = new Point(260, 20);
            titulo.Font = new Font("Arial", 21, FontStyle.Bold);
            titulo.BackColor = Color.Transparent;
            // titulo.ForeColor = ColorTranslator.FromHtml("#0078D7");

            titulo.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void DoTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox.BackColor = Color.Transparent;
            // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

        }

        public static void DoTempo(Label lbl, Timer jikan, Form frm)                                            // jikan eh 'tempo' em nipon
        {

            int doisponto = 1;
            lbl.Location = new Point(frm.Width * 67 / 100, 20);
                    
            jikan.Interval = 1000; // 2 segundo
            jikan.Tick += (s, e) =>
            {
                if (doisponto % 2 == 0)
                {
                    lbl.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-br")) + DateTime.Now.ToString("                     hh  mm tt", new CultureInfo("en"));
                    lbl.Location = new Point(frm.Width * 67 / 100, 20);                 
                    doisponto += 1;
                    
                }
                else
                {
                    lbl.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-br")) + DateTime.Now.ToString("                     hh : mm tt", new CultureInfo("en"));
                    lbl.Location = new Point(frm.Width * 67 / 100, 20);
                    doisponto += 1;
                }
            };
          
            jikan.Start();
            

        }


    }
}
// 2-5-14-25    -... . -. -.--   .-. . .. ...