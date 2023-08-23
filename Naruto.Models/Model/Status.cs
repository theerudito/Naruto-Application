using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public bool Alive { get; set; }
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
