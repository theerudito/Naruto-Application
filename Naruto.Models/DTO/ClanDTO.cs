namespace Naruto.Models.DTO
{
    public class ClanDTO
    {
        public int IdClan { get; set; }
        public string ClanName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string RefImage { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
