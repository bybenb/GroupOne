

using System;
using System.Collections.Generic;


using MySql.Data.MySqlClient;
using GestaoSimples.Telas.Publico;
using GestaoSimples.BancoDados;
using GestaoSimples.Modelos;
// 2-5-14-25    -... . -. -.--   .-. . .. ...

namespace GestaoSimples.Servicos
{
    public class UsuarioServico
    {
        public static List<Ususario> ListarTodos()
        {
            var lista = new List<Ususario>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM usuarios ORDER BY criado_em DESC";
                using (var cmd = new MySqlCommand(sql, conexao))
                using (var leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Ususario
                        {
                            Id = leitor.GetInt32("id"),
                            Nome = leitor.GetString("nome"),
                            Email = leitor.GetString("email"),
                            Tipo = leitor.GetString("tipo"),
                            CriadoEm = leitor.GetDateTime("criado_em")
                        });
                    }
                }
            }

            return lista;
        }

        public static void Cadastrar(Ususario u)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"INSERT INTO usuarios 
                    (nome, email, senha, tipo) 
                    VALUES (@nome, @email, SHA2(@senha, 256), @tipo)";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", u.Nome);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@senha", u.Senha);
                    cmd.Parameters.AddWithValue("@tipo", u.Tipo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(Ususario u)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"UPDATE usuarios SET 
                    nome = @nome,
                    email = @email,
                    tipo = @tipo
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", u.Nome);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@tipo", u.Tipo);
                    cmd.Parameters.AddWithValue("@id", u.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Remover(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM usuarios WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Ususario> ListarPorTipo(string tipo)
        {
            var lista = new List<Ususario>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM usuarios WHERE tipo = @tipo";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    using (var leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new Ususario
                            {
                                Id = leitor.GetInt32("id"),
                                Nome = leitor.GetString("nome"),
                                Email = leitor.GetString("email"),
                                Tipo = leitor.GetString("tipo")
                            });
                        }
                    }
                }
            }

            return lista;
        }


        public static Ususario BuscarPorId(int id) {
            using var conexao = Conexao.ObterConexao();
            string sql = "SELECT * FROM usuarios WHERE id = @id";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            using var leitor = cmd.ExecuteReader();
            if (leitor.Read()) {
                return new Ususario {
                    Id = leitor.GetInt32("id"),
                    Nome = leitor.GetString("nome"),
                    Email = leitor.GetString("email"),
                    Tipo = leitor.GetString("tipo")
                };
            }

            return null;
        }
    }
}