using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Controller;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController tamagotchiController = new TamagotchiController();
            tamagotchiController.Jogar();
        }
    }
}
