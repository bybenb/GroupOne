using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoSimples.Telas
{
    public class TelaUsuarios : UserControl
    {
        public TelaUsuarios()
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;

            Label lbl = new Label
            {
                Text = "Gestão de Usuários",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };

            this.Controls.Add(lbl);
        }
    }
}
