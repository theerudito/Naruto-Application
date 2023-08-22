using Naruto.Models.DTO;

namespace Naruto.Service.Interface
{
    public interface ICharacter
    {
        Task<List<CharacterDTO>> _GETS();
        Task<CharacterDTO> _GET(int id);
        Task<CharacterDTO> _POST(CharacterDTO character);
        Task<bool> _PUT(CharacterDTO character, int id);
        Task<bool> _DELETE(int id);
        Task<List<CharacterDTO>> _SEACHING(string field);
    }
}
