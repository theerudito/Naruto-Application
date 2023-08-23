using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Jutsus
    {
        [Key]
        public int IdJutsu { get; set; }
        public string? JutsuName { get; set; } = string.Empty;
        public bool Status { get; set; }

        // navigation properties
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
