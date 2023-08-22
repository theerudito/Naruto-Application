using Naruto.Models.DTO;

namespace Naruto.Service.Interface
{
    public interface IClan
    {
        Task<List<ClanDTO>> _GETS();
        Task<ClanDTO> _GET(int id);
        Task<ClanDTO> _POST(ClanDTO clan);
        Task<bool> _PUT(ClanDTO clan, int id);
        Task<bool> _DELETE(int id);
    }
}
