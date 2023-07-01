using System.ComponentModel.DataAnnotations;

namespace BKProyecto.Models
{
    public class TarjetaCredito
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string NumeroTarjeta { get; set; }
        [Required]
        public string FechaExpedicion { get; set;}
        [Required]
        public string CCV { get; set; }
    }
}
