using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Current
    {
        [Key]
        public int IdStatus { get; set; }
        public bool Alive { get; set; }
        public bool Status { get; set; }

        // navigation properties
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
