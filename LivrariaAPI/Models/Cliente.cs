using System.ComponentModel.DataAnnotations;

namespace LivrariaAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)] // Limite de 255 caracteres para o nome
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)] // Limite de 255 caracteres para o email
        public string Email { get; set; }
    }
}
