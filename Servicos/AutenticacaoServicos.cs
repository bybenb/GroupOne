// Arquivo de exemplo para a pasta Modelos

// using System;
using GestaoSimples.BancoDados;
using GestaoSimples.Modelos;
using GestaoSimples.Telas.Publico;
using MySql.Data.MySqlClient;
// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 

namespace GestaoSimples.Servicos
{
    public class AutenticacaoServico
    {
        public static Ususario? Autenticar(string email, string senha)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM usuarios WHERE email = @email AND senha = SHA2(@senha, 256)";

                using var comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senha);

                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new Ususario
                        {
                            Id = leitor.GetInt32("id"),
                            Nome = leitor.GetString("nome"),
                            Email = leitor.GetString("email"),
                            Senha = "", // 
                            Tipo = leitor.GetString("tipo"),
                            CriadoEm = leitor.GetDateTime("criado_em")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
// 2-5-14-25    -... . -. -.--   .-. . .. ...