using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Ocupations
    {
        [Key]
        public int IdOcupation { get; set; }
        public string? OcupationName { get; set; } = string.Empty;
        public bool Status { get; set; }

        // navigation properties
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
