using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PomiaryEsp32.Data.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;  
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        [JsonIgnore]
        public User? User { get; set; } = null!;

        [ForeignKey("User")]
        public int? UserId { get; set; }
    }
}
