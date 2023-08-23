using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Ocupations
    {
        [Key]
        public int IdOcupation { get; set; }
        public string? OcupationName { get; set; } = string.Empty;
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
