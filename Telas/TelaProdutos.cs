using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoSimples.Telas
{
    public class TelaProdutos : UserControl
    {
        public TelaProdutos()
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;

            Label lbl = new Label
            {
                Text = "Gestão de Produtos",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };

            this.Controls.Add(lbl);
        }
    }
}
