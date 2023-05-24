namespace RolePlayingGameApi.Repositories
{
  public class CharacterRepository : ICharacterRepository
  {
    private readonly DataContext _dataContext;

    public CharacterRepository(DataContext dataContext)
    {
      _dataContext = dataContext;
    }
    public async Task<bool> CreateCharacter(Character character)
    {
      _dataContext.Characters.Add(character);
      return await Save();
    }

    public async Task<bool> DeleteCharacter(Character character)
    {
      _dataContext.Characters.Remove(character);
      return await Save();
    }

    public async Task<Character?> GetCharacterById(int id)
    {
      return await _dataContext.Characters.FindAsync(id);
    }

    public async Task<List<Character>> GetCharacters()
    {
      return await _dataContext.Characters.ToListAsync();
    }

    public async Task<bool> UpdateCharacter(Character character)
    {
        _dataContext.Characters.Update(character);
        return await Save();
    }

    private async Task<bool> Save() {
      return await _dataContext.SaveChangesAsync() > 0 ? true : false; 
    }
  }
}