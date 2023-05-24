using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RolePlayingGameApi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters();
        Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<CharacterResponseDto>>> CreateCharacter(CharacterRequestDto newCharacter);
        Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdatedCharacterRequestDto updatedCharacter);
        Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacter(int id);
    }
}