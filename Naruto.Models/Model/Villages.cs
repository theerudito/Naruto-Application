using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Villages
    {
        [Key]
        public int IdVillage { get; set; }
        public string? VillageName { get; set; } = string.Empty;
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
