using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Mascot mascote = new Mascot
        {
            Name = "Charmander",
            Height = 6,
            Weight = 85,
            Abilities = new List<AbilitiesClass>
            {
                new AbilitiesClass
                {
                    Ability = new Ability
                    {
                        Name = "blaze",
                        Url = "https://pokeapi.co/api/v2/pokemon/4/"
                    },
                    IsHidden = false,
                    Slot = 1
                }
            }
        };

        string json = JsonConvert.SerializeObject(mascote, Formatting.Indented);
        Console.WriteLine("JSON Gerado : ");
        Console.WriteLine(json);

        Console.WriteLine("\nDados do Mascote: ");
        Console.WriteLine($"Nome Pokemon: {mascote.Name}");
        Console.WriteLine($"Altura: {mascote.Height}");
        Console.WriteLine($"Peso: {mascote.Weight}");

        Console.WriteLine("\nHabilidades");
        foreach (var ability in mascote.Abilities)
        {
            Console.WriteLine($"Habilidade: {ability.Ability.Name}");
        }
    }
}

public class Mascot
{
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<AbilitiesClass> Abilities { get; set; }
}

public class AbilitiesClass
{
    public Ability Ability { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string Url { get; set; }
}