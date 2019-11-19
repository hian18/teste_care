using System.ComponentModel.DataAnnotations;


namespace ClienteApi.Models

{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }

}