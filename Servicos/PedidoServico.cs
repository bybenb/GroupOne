using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GestaoSimples.BancoDados;
using GestaoSimples.Modelos;

// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'


namespace GestaoSimples.Servicos
{
    public static class PedidoServico
    {
        public static void RegistrarComoVisitante(List<Produto> produtos, string nome, string email, string localEntrega)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                foreach (var p in produtos)
                {
                    string sql = @"INSERT INTO pedidos 
                        (produto_id, nome_visitante, email_visitante, local_entrega, status, data_pedido)
                        VALUES (@produto_id, @nome, @email, @local, 'pendente', NOW())";

                    using (var cmd = new MySqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@produto_id", p.Id);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@local", localEntrega);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void RegistrarComoUtilizador(List<Produto> produtos, int idUsuario)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                foreach (var p in produtos)
                {
                    string sql = @"INSERT INTO pedidos 
                        (produto_id, usuario_id, status, data_pedido)
                        VALUES (@produto_id, @usuario_id, 'pendente', NOW())";

                    using (var cmd = new MySqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@produto_id", p.Id);
                        cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }





        public static List<Pedido> ListarPendentesComDetalhes()
        {
            var lista = new List<Pedido>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT p.id, p.produto_id, p.usuario_id, p.nome_visitante, p.email_visitante,
                        p.status, p.data_pedido,
                        pr.nome AS produto_nome,
                        u.nome AS usuario_nome
                    FROM pedidos p
                    JOIN produtos pr ON p.produto_id = pr.id
                    LEFT JOIN usuarios u ON p.usuario_id = u.id
                    WHERE p.status = 'pendente'
                    ORDER BY p.data_pedido DESC";

                using (var cmd = new MySqlCommand(sql, conexao))
                using (var leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        string solicitante;

                        if (!leitor.IsDBNull(leitor.GetOrdinal("usuario_nome")))
                            solicitante = leitor.GetString("usuario_nome");
                        else
                            solicitante = leitor.GetString("nome_visitante") + " (visitante)";

                        lista.Add(new Pedido
                        {
                            Id = leitor.GetInt32("id"),
                            ProdutoId = leitor.GetInt32("produto_id"),
                            UsuarioId = leitor.IsDBNull(leitor.GetOrdinal("usuario_id")) ? null : leitor.GetInt32("usuario_id"),
                            ProdutoNome = leitor.GetString("produto_nome"),
                            Solicitante = solicitante,
                            Status = leitor.GetString("status"),
                            DataPedido = leitor.GetDateTime("data_pedido")
                        });
                    }
                }
            }

            return lista;
        }

        public static void ReencaminharParaFornecedor(int pedidoId, int fornecedorId)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"UPDATE pedidos 
                            SET status = 'reencaminhado', fornecedor_id = @fornecedor 
                            WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", pedidoId);
                    cmd.Parameters.AddWithValue("@fornecedor", fornecedorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AtualizarStatus(int pedidoId, string novoStatus)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string sql = "UPDATE pedidos SET status = @status WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", pedidoId);
                    cmd.Parameters.AddWithValue("@status", novoStatus);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Pedido> ListarPorFornecedor(int fornecedorId)
        {
            var lista = new List<Pedido>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT p.id, p.produto_id, p.usuario_id, p.nome_visitante, p.email_visitante,
                        p.status, p.data_pedido,
                        pr.nome AS produto_nome,
                        u.nome AS usuario_nome
                    FROM pedidos p
                    JOIN produtos pr ON p.produto_id = pr.id
                    LEFT JOIN usuarios u ON p.usuario_id = u.id
                    WHERE p.fornecedor_id = @fornecedor
                    ORDER BY p.data_pedido DESC";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@fornecedor", fornecedorId);

                    using (var leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            string solicitante;                                     // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

                            if (!leitor.IsDBNull(leitor.GetOrdinal("usuario_nome")))
                                solicitante = leitor.GetString("usuario_nome");
                            else
                                solicitante = leitor.GetString("nome_visitante") + " (visitante)";

                            lista.Add(new Pedido
                            {
                                Id = leitor.GetInt32("id"),
                                ProdutoId = leitor.GetInt32("produto_id"),
                                UsuarioId = leitor.IsDBNull(leitor.GetOrdinal("usuario_id")) ? null : leitor.GetInt32("usuario_id"),
                                ProdutoNome = leitor.GetString("produto_nome"),
                                Solicitante = solicitante,
                                Status = leitor.GetString("status"),
                                DataPedido = leitor.GetDateTime("data_pedido")
                            });
                        }
                    }
                }
            }                                               // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

            return lista;
        }








        //traz os pedidos de um utilizador filtrando por status (ex: "pendente" ou "entregue").
        public static List<Pedido> ListarDoUsuario(int idUsuario, string status)
        {
            var lista = new List<Pedido>();

            using (var conexao = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT p.id, p.produto_id, p.status, p.data_pedido,
                        pr.nome AS produto_nome
                    FROM pedidos p
                    JOIN produtos pr ON p.produto_id = pr.id
                    WHERE p.usuario_id = @usuario AND p.status = @status
                    ORDER BY p.data_pedido DESC";

                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@status", status);

                    using (var leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new Pedido
                            {
                                Id = leitor.GetInt32("id"),
                                ProdutoId = leitor.GetInt32("produto_id"),
                                ProdutoNome = leitor.GetString("produto_nome"),
                                Status = leitor.GetString("status"),
                                DataPedido = leitor.GetDateTime("data_pedido")
                            });
                        }
                    }
                }
            }

            return lista;
        }



    }
}


// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'