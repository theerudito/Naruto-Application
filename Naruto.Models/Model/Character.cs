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
        public bool Status { get; set; }

        // Foreign Key
        public int? IdClan { get; set; }
        public virtual Clan? Clan { get; set; }

        public int? IdVillage { get; set; }
        public virtual Villages? Villages { get; set; }

        public int? IdJutsu { get; set; }
        public virtual Jutsus? Jutsus { get; set; }

        public int? IdOcupation { get; set; }
        public virtual Ocupations? Ocupations { get; set; }

        public int? IdStatus { get; set; }
        public virtual Current? Current { get; set; }
    }
}
