using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Clan
    {
        [Key]
        public int IdClan { get; set; }
        public string? ClanName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string RefImage { get; set; } = string.Empty;
        public bool Status { get; set; }

        // navigation properties
        public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
