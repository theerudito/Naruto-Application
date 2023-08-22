using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Character
    {
        [Key]
        public int IdCharacter { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;
        public string RefImage { get; set; } = string.Empty;

        public int? IdClan { get; set; }
        public virtual Clan? Clan { get; set; }
    }
}
