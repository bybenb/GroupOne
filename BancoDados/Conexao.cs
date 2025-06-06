
// Arquivo de exemplo para a pasta Telas
using MySql.Data.MySqlClient;


namespace GestaoSimples.BancoDados
{
    public class Conexao
    {
        private static string servidor = "localhost";
        private static string banco = "bancode_gestaosimples";
        private static string usuario = "root";
        private static string senha = ""; 

        private static string stringConexao = $"Server={servidor};Database={banco};Uid={usuario};Pwd={senha};";

        public static MySqlConnection ObterConexao() {
            var conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }
    }
}
