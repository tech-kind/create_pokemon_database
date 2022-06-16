using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePokemonDatabase
{
    public class PokemonContent
    {
        public Ability[] abilities { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Species species { get; set; }
        public Sprites sprites { get; set; }
        public Stat[] stats { get; set; }
        public Type[] types { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Sprites
    {
        public string front_default { get; set; }
    }

    public class Ability
    {
        public Ability1 ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Ability1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat1 stat { get; set; }
    }

    public class Stat1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string url { get; set; }
    }


    public class NameContent
    {
        public Name[] names { get; set; }
    }

    public class Name
    {
        public Language2 language { get; set; }
        public string name { get; set; }
    }

    public class Language2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
