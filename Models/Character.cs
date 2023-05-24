using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGameApi.Models
{
    public class Character
    {
        public required int Id { get; set; }
      
        public required string? Name { get; set; }

        public required int HitPoints { get; set; }

        public required int Strength { get; set; }

        public required int Defense { get; set; }

        public required int Intelligence { get; set; }

        public required RpgClass Class { get; set; }
  }
}