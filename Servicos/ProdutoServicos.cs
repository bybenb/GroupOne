//  a pasta Modelos

using System;
using System.Drawing;
using System.Windows.Forms;


using GestaoSimples.Componentes;
using GestaoSimples.BancoDados;
using GestaoSimples.Telas.Publico;
using GestaoSimples.Utilitarios;

using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GestaoSimples.Modelos;

// 2-5-14-25    -... . -. -.--   .-. . .. ... (ABC123 & MORSE CODE) 




namespace GestaoSimples.Servicos
{
    public class ProdutoServico
    {
        public static List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM produtos ORDER BY data_cadastro DESC";
                using (var cmd = new MySqlCommand(sql, conexao))
                using (var leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Produto
                        {
                            Id = leitor.GetInt32("id"),
                            IdUsuario = leitor.GetInt32("id_usuario"),
                            Nome = leitor.GetString("nome"),
                            Descricao = leitor.GetString("descricao"),
                            Preco = leitor.GetDecimal("preco"),
                            QuantidadeEstoque = leitor.GetInt32("quantidade_estoque"),
                            Categoria = leitor.GetString("categoria"),
                            DataCadastro = leitor.GetDateTime("data_cadastro")
                        });
                    }
                }
            }

            return lista;
        }

        public static void Cadastrar(Produto p)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"INSERT INTO produtos 
                    (id_usuario, nome, descricao, preco, quantidade_estoque, categoria) 
                    VALUES (@id_usuario, @nome, @descricao, @preco, @quantidade, @categoria)";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", p.IdUsuario);
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@preco", p.Preco);
                    cmd.Parameters.AddWithValue("@quantidade", p.QuantidadeEstoque);
                    cmd.Parameters.AddWithValue("@categoria", p.Categoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(Produto p)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"UPDATE produtos SET 
                    nome = @nome,
                    descricao = @descricao,
                    preco = @preco,
                    quantidade_estoque = @quantidade,
                    categoria = @categoria
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@preco", p.Preco);
                    cmd.Parameters.AddWithValue("@quantidade", p.QuantidadeEstoque);
                    cmd.Parameters.AddWithValue("@categoria", p.Categoria);
                    cmd.Parameters.AddWithValue("@id", p.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Remover(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM produtos WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Produto> BuscarPorNome(string termo)
        {
            var lista = new List<Produto>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM produtos WHERE nome LIKE @termo ORDER BY nome";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@termo", $"%{termo}%");

                    using (var leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new Produto
                            {
                                Id = leitor.GetInt32("id"),
                                IdUsuario = leitor.GetInt32("id_usuario"),
                                Nome = leitor.GetString("nome"),
                                Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao")) ? "" : leitor.GetString("descricao"),
                                Preco = leitor.GetDecimal("preco"),
                                QuantidadeEstoque = leitor.GetInt32("quantidade_estoque"),
                                Categoria = leitor.GetString("categoria"),
                                DataCadastro = leitor.GetDateTime("data_cadastro")
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}