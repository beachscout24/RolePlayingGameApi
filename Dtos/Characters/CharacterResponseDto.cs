using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGameApi.Dtos.Characters
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int HitPoints { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }
    }
}