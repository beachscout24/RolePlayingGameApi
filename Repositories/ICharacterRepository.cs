using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGameApi.Repositories
{
    public interface ICharacterRepository
    {
        public Task<List<Character>> GetCharacters();
        
        public Task<Character?> GetCharacterById(int id);

        public Task<bool> CreateCharacter(Character character);

        public Task<bool> UpdateCharacter(Character character);

        public Task<bool> DeleteCharacter(Character character);
    }
}