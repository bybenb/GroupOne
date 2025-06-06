using System;
using System.Drawing;
using System.Windows.Forms;
using GestaoSimples.Telas.Publico;


// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
namespace GestaoSimples.Telas

{
    public class OpcaoDashboard : UserControl
    {
        public OpcaoDashboard()
        {



            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            Label lbl = new Label
            {
                Text = "Meu Dashboard",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            this.Controls.Add(lbl);


            // this.BackColor = Color.White;
            // // this.Dock = DockStyle.Fill;
            // Location = new Point(520, 520);


            // this.Controls.Add(new Label {
            //     Text = "Meu Dashboard",
            //     Font = new Font("Segoe UI", 14, FontStyle.Bold),
            //     AutoSize = true,
            //     Location = new Point(320, 320)
            // });
        }
    }
}
