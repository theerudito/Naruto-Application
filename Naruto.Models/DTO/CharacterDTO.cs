using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naruto.Models.DTO
{
    public class CharacterDTO
    {
        public int IdCharacter { get; set; }
        [Required(ErrorMessage = "The Field {0} Is Required")]
        public string FirstName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;
        public string RefImage { get; set; } = string.Empty;

        public int? IdClan { get; set; }
        [NotMapped]
        public string NameClan { get; set; } = string.Empty;

        public int? IdVillage { get; set; }
        [NotMapped]
        public string NameVillage { get; set; } = string.Empty;

        public int? IdJutsu { get; set; }
        [NotMapped]
        public string NameJutsu { get; set; } = string.Empty;

        public int? IdOcupation { get; set; }
        [NotMapped]
        public string NameOcupation { get; set; } = string.Empty;

        public int? IdStatus { get; set; }
        [NotMapped]
        public bool Alive { get; set; }
        [NotMapped]
        public bool Status { get; set; }
    }

}
