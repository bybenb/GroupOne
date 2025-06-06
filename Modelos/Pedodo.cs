using System;



public class Pedido
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int? UsuarioId { get; set; }
    public string? ProdutoNome { get; set; }
    public string? Solicitante { get; set; }
    public string? Status { get; set; }
    public DateTime DataPedido { get; set; }
}