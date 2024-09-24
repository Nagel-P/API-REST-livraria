namespace LivrariaAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
