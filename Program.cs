// Ponto de entrada do sistema

using System;
using System.Windows.Forms;
using GestaoSimples.Telas;

namespace GestaoSimples;

static class Program {
    [STAThread]
    static void Main() {
 
        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TelaLogin());
    }
}
