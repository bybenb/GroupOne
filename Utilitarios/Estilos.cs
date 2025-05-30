using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
// 2-5-14-25    -... . -. -.--   .-. . .. ...


using GestaoSimples.Servicos;
using GestaoSimples.Modelos;
using GestaoSimples.Utilitarios;

namespace GestaoSimples.Utilitarios
{


    public class Estilos
    {


        public static void DoFormulario(Form Janela)
        {


            Janela.BackColor = Color.AntiqueWhite;
            Janela.Font = new Font("Arial", 10);
            Janela.Width = 800;
            Janela.Height = 500;
            Janela.StartPosition = FormStartPosition.CenterScreen;

            // notifyIcon = new NotifyIcon();
            // notifyIcon.Icon = new Icon("caminho_para_o_icone_da_barra_de_tarefas.ico");  // Ícone da barra de tarefas
            // notifyIcon.Visible = true;
            
        }



        public static void DoBotao(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = ColorTranslator.FromHtml("#0078D7");
            button.ForeColor = Color.White;
            button.Font = new Font("Arial", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.TextAlign = ContentAlignment.MiddleCenter;
        }
        public static void DoBotaoCancelar(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = ColorTranslator.FromHtml("#DC3545");
            button.ForeColor = Color.White;
            button.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        // 2-5-14-25    -... . -. -.--   .-. . .. ...
        public static void DoTitulo(Label titulo, String texto)
        {
            titulo.Text = texto;
            titulo.AutoSize = true;
            titulo.Location = new Point(260, 20);
            titulo.Font = new Font("Arial", 21, FontStyle.Bold);
            titulo.BackColor = Color.Transparent;
            titulo.ForeColor = ColorTranslator.FromHtml("#0078D7");

            titulo.TextAlign = ContentAlignment.MiddleCenter;
        }


        public static void DoTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox.BackColor = Color.Transparent;

        }
        



    }
}
// 2-5-14-25    -... . -. -.--   .-. . .. ...