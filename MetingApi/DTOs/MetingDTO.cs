using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MetingApi.DTOs
{
    public class MetingDTO
    {
        [Required]

        public IList<ResultaatDTO> Resultaten { get; set; }
    }
}
