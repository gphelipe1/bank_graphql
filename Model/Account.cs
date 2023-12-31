using System.ComponentModel.DataAnnotations;

namespace Bank.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Conta { get; set; }
        
        [Required]
        public decimal Saldo { get; set; } = 0;
    }
}