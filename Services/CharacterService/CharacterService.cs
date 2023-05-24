

namespace RolePlayingGameApi.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {

    private readonly IMapper _mapper;
    private readonly ICharacterRepository _characterRepository;

    public CharacterService(IMapper mapper, ICharacterRepository characterRepository)
    {
      _characterRepository = characterRepository;
      _mapper = mapper;
    }
    public async Task<ServiceResponse<List<CharacterResponseDto>>> CreateCharacter(CharacterRequestDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
        if(newCharacter is null){
          serviceResponse.Message = "Request does not have a character :(";
          serviceResponse.Success = false;
        }
        else {
          var response = await _characterRepository.CreateCharacter(_mapper.Map<Character>(newCharacter));
          if(response){
            serviceResponse.Message = "Created New Character";
            var characters = await _characterRepository.GetCharacters();
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
          }
          else{
            serviceResponse.Message = "New Character Not Created";
          }
           serviceResponse.Success = response;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacter(int id)
    {
       var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
      try{
        var character = await _characterRepository.GetCharacterById(id);
        if(character is null){
          throw new Exception($"Character with id:{id} not found");
        }
        else {
          if(await _characterRepository.DeleteCharacter(character)){
            serviceResponse.Message = $"Deleted Character with Id: '{id}'";
            var characters = await _characterRepository.GetCharacters();
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
          }
          else{
            serviceResponse.Message = $"Character with Id: '{id}' not deleted";
            serviceResponse.Success = false;
          }
        }
      }
      catch(Exception exception){
        serviceResponse.Message = exception.Message;
        serviceResponse.Success = false;
      }
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters()
    {
      var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
      var characters = await _characterRepository.GetCharacters();
      var response = characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
      if(response.Count() == 0){
        serviceResponse.Message = "There are no characters to retrieve";
        serviceResponse.Success = false;
      }
      serviceResponse.Data = response;
      serviceResponse.Message = "Retrieved All Characters";
      return serviceResponse;
    }

    public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<CharacterResponseDto>();
        var character = await _characterRepository.GetCharacterById(id);
        if(character is null){
          serviceResponse.Message = $"The character with id:{id} does not exist :(";
          serviceResponse.Success = false;
        }
        else {
          serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);
          serviceResponse.Message = $"Retrieved Character with Id:{id}";
        }
      return serviceResponse;
    }

    public async Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdatedCharacterRequestDto updatedCharacter)
    {
      var serviceResponse = new ServiceResponse<CharacterResponseDto>();
      try{
        if(updatedCharacter is null){
          throw new Exception($"Character not found");
        }
        else
        {
          var character = await _characterRepository.GetCharacterById(updatedCharacter.Id);
          Console.WriteLine("old character: "+ character);
          if(character is null){
            serviceResponse.Message = $"The character with id:{updatedCharacter.Id} does not exist :(";
            serviceResponse.Success = false;
          }
          else{
             Console.WriteLine(updatedCharacter);
             _mapper.Map(updatedCharacter, character);
             Console.WriteLine("new character: " + character);
             serviceResponse.Success = await _characterRepository.UpdateCharacter(character);
             serviceResponse.Message = "Updated New Character";
             serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);
          }
        }
      }
      catch(Exception exception){
        serviceResponse.Message = exception.Message;
        serviceResponse.Success = false;
      }
      return serviceResponse;
  }
  }
}