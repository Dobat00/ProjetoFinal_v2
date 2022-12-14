using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal_v2.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
    }
}
