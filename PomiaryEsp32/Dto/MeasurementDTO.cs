using System.ComponentModel.DataAnnotations;

namespace PomiaryEsp32.Dto
{
    public class MeasurementDTO
    {
        [Required]
        public double Temperature { get; set; }

        [Required]
        [Range(0, 100)]
        public double Humidity { get; set; }
    }
}
