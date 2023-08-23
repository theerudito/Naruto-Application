using System.ComponentModel.DataAnnotations;

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

        public int IdClan { get; set; }
        public string NameClan { get; set; } = string.Empty;

        public int IdVillage { get; set; }
        public string NameVillage { get; set; } = string.Empty;

        public int IdJutsu { get; set; }
        public string NameJutsu { get; set; } = string.Empty;

        public int IdOcupation { get; set; }
        public string NameOcupation { get; set; } = string.Empty;

        public int IdStatus { get; set; }
        public bool Alive { get; set; }
    }
}
