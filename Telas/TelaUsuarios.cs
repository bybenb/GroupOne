using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoSimples.Telas
{
    public class TelaUsuarios : UserControl
    {
        public TelaUsuarios()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            Label lbl = new Label
            {
                Text = "Gestão de Usuários",
                
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            this.Controls.Add(lbl);
        }
    }
}
