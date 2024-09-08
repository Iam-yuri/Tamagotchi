using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.View;

namespace TamagotchiPokemon
{
    internal class MascotDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Nickname { get; set; }
        [Range(1, 1000)]
        public int MascotHeight { get; set; }
        [Range(1, 1000)]
        public int MascotWeight { get; set; }
    }
}
