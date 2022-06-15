﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePokemonDatabase
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ImageURL { get; set; }

        public string? Type1 { get; set; }

        public string? Type2 { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SpecialAttack { get; set; }

        public int SpecialDefense { get; set; }

        public int Speed { get; set; }
    }

}
