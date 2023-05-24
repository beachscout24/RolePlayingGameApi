namespace RolePlayingGameApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          CreateMap<Character, CharacterRequestDto>();
          CreateMap<CharacterRequestDto, Character>();
          CreateMap<Character, CharacterResponseDto>();
          CreateMap<UpdatedCharacterRequestDto, Character>()
          .ForMember(dest => dest.Id, options => options.Ignore())
          .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name != default(string)))  
          .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
          .ForMember(dest => dest.HitPoints, opt => opt.Condition(src => src.HitPoints != default(int)))  
          .ForMember(dest => dest.HitPoints, options => options.MapFrom(src => src.HitPoints))
          .ForMember(dest => dest.Strength, opt => opt.Condition(src => src.Strength != default(int)))  
          .ForMember(dest => dest.Strength, options => options.MapFrom(src => src.Strength))
          .ForMember(dest => dest.Defense, opt => opt.Condition(src => src.Defense != default(int)))  
          .ForMember(dest => dest.Defense, options => options.MapFrom(src => src.Defense))
          .ForMember(dest => dest.Intelligence, opt => opt.Condition(src => src.Intelligence != default(int)))  
          .ForMember(dest => dest.Intelligence, options => options.MapFrom(src => src.Intelligence))
          .ForMember(dest => dest.Class, opt => opt.Condition(src => src.Class != default(int)))  
          .ForMember(dest => dest.Class, options => options.MapFrom(src => src.Class));
        }
    }
}