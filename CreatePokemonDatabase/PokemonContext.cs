using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CreatePokemonDatabase
{
    public class PokemonContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public string DbPath { get; set; }

        public PokemonContext()
        {
            // DBファイルの保存先とDBファイル名
            DbPath = @"C:\projects\example\create_pokemon_database\CreatePokemonDatabase\bin\Debug\net6.0\pokemon.db";
        }

        // デスクトップ上にSQLiteのDBファイルが作成される
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
