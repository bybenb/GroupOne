// Ponto de entrada do sistema

using System;
using System.Windows.Forms;
using GestaoSimples.Telas;
using GestaoSimples.Telas.Publico;
// 2-5-14-25    -... . -. -.--   .-. . .. ...

namespace GestaoSimples;

static class Program
{
    [STAThread]
    static void Main()
    {
        //                  -... . -. -.--   .-. . .. ...
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaInicial());
        }
        catch (Exception problema)
        {
            // 2-5-14-25    -... . -. -.--   .-. . .. ...
            MessageBox.Show($"Mano, O programa deu erro a Iniciar: {problema.ToString()}", "Já comecou mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine($"bro, o erro é: {problema.ToString()}");
            Console.Write("© 2025 Grupo One. Todos Direitos reservados à Eng. Joana Bungo.");
        }

    }
}