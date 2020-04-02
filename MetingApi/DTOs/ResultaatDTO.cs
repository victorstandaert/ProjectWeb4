using System.ComponentModel.DataAnnotations;

namespace MetingApi.DTOs
{
    public class ResultaatDTO
    {
        [Required]
        public string Type { get; set; }

        public double? Amount { get; set; }
    }
}
