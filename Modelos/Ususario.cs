using System;
using MySql.Data.MySqlClient;
// Arquivo de exemplo para a pasta Modelos

namespace GestaoSimples.Modelos
{
    public class Ususario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
