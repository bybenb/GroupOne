using System;
using MySql.Data.MySqlClient;

// 2-5-14-25    -... . -. -.--   .-. . .. ...
namespace GestaoSimples.Modelos
{
    public class Ususario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string? Email { get; set; }
        public  string? Senha { get; set; }
        public required string Tipo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
// 2-5-14-25    -... . -. -.--   .-. . .. ...       C:\Users\LINO SOFT\Documents\bybenb\by_projetos\z\GS-csharp\

