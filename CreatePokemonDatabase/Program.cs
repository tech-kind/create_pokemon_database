// See https://aka.ms/new-console-template for more information

using RestSharp;
using Newtonsoft.Json;
using CreatePokemonDatabase;

const int pokemon_max = 898;

var pokemon_client = new RestClient("https://pokeapi.co/api/v2");


List<Pokemon> pokemons = new List<Pokemon>();
for (int i = 1; i <= pokemon_max; i++)
{
    Console.WriteLine($"実行中... : {i}");
    var pokemon_request = new RestRequest($"pokemon/{i}", Method.Get);

    var pokemon_response = pokemon_client.Execute(pokemon_request);

    if (pokemon_response.Content is null)
    {
        return;
    }

    var model = new Pokemon();

    var pokemon_content = JsonConvert.DeserializeObject<PokemonContent>(pokemon_response.Content);

    if (pokemon_content is null)
    {
        return;
    }

    model.Id = pokemon_content.id;
    model.ImageURL = pokemon_content.sprites.front_default;
    model.HP = pokemon_content.stats[0].base_stat;
    model.Attack = pokemon_content.stats[1].base_stat;
    model.Defense = pokemon_content.stats[2].base_stat;
    model.SpecialAttack = pokemon_content.stats[3].base_stat;
    model.SpecialDefense = pokemon_content.stats[4].base_stat;
    model.Speed = pokemon_content.stats[5].base_stat;

    // 一旦英語名を入れておく
    model.Name = pokemon_content.name;
    if (pokemon_content.types.Length == 1)
    {
        model.Type1 = pokemon_content.types[0].type.name;
    }
    else
    {
        model.Type1 = pokemon_content.types[0].type.name;
        model.Type1 = pokemon_content.types[1].type.name;
    }

    // ポケモンの名前の日本語を取得するためのAPIの設定
    var split = pokemon_content.species.url.Split('/');
    var species_request = new RestRequest($"pokemon-species/{split[split.Length - 2]}");
    var species_response = pokemon_client.Execute(species_request);

    if (species_response.Content is null)
    {
        return;
    }

    var species_content = JsonConvert.DeserializeObject<NameContent>(species_response.Content);

    if (species_content is null)
    {
        return;
    }

    // 日本語の名前の検索
    foreach (var name in species_content.names)
    {
        if (name.language.name.Contains("ja"))
        {
            model.Name = name.name;
            break;
        }
    }

    // ポケモンのタイプを取得するためのAPIの設定
    foreach (var (value, index) in pokemon_content.types.Select((value, index) => (value, index)))
    {
        var split_type = value.type.url.Split('/');
        var type_request = new RestRequest($"type/{split_type[split_type.Length - 2]}");
        var type_response = pokemon_client.Execute(type_request);

        if (type_response.Content is null)
        {
            return;
        }

        var type_content = JsonConvert.DeserializeObject<NameContent>(type_response.Content);

        if (type_content is null)
        {
            return;
        }

        // 日本語の名前の検索
        foreach (var name in type_content.names)
        {
            if (name.language.name.Contains("ja"))
            {
                if (index == 0)
                {
                    model.Type1 = name.name;
                }
                else
                {
                    model.Type2 = name.name;
                }
                break;
            }
        }
    }

    pokemons.Add(model);
}

using (var db = new PokemonContext())
{
    db.AddRange(pokemons);
    db.SaveChanges();
}

