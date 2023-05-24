using Microsoft.AspNetCore.Mvc;

namespace RolePlayingGameApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService)
    {
      _characterService = characterService;
    }
      [HttpGet]
      public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> GetCharacters(){
        var response = await _characterService.GetAllCharacters();
        if(!response.Success){
          return NotFound(response);
        }
        else{
          return Ok(response);
        }
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> GetCharacterById(int id){
        var response = await _characterService.GetCharacterById(id);
        if(response.Data is null){
          return NotFound(response);
        }
        else {
          return Ok(response);
        }
      }

      [HttpPost]
      public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> CreateCharacter(CharacterRequestDto newCharacter){
        var response = await _characterService.CreateCharacter(newCharacter);
        if(response.Data is null){
          return NotFound(response);
        }
        else {
          return Ok(response);
        }
      }

      [HttpPut]
      public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> UpdateCharacter(UpdatedCharacterRequestDto updatedCharacter){
        var response = await _characterService.UpdateCharacter(updatedCharacter);
        if(response.Data is null){
          return NotFound(response);
        }
        else{
          return Ok(response);
        }
           
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> DeleteCharacter(int id){
        var response = await _characterService.DeleteCharacter(id);
        if(response is null){
          return NotFound(response);
        }
        else{
          return Ok(response);
        }  
      }
  }
}