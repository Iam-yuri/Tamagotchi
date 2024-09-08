using System;
using System.Collections.Generic;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private TamagotchiView tamagotchiView;
        private PokemonApiService pokemonApiService;
        private List<MvcResult> especiesDisponiveis;
        private List<Dto> mascotesAdotados;

        public TamagotchiController()
        {
            tamagotchiView = new TamagotchiView();
            pokemonApiService = new PokemonApiService();
            especiesDisponiveis = pokemonApiService.ObterEspeciesDisponiveis();
            mascotesAdotados = new List<Dto>();
        }

        public void Jogar()
        {
            tamagotchiView.MostrarMensagemDeBoasVindas();

            while (true)
            {
                tamagotchiView.MostrarMenuPrincipal();
                int escolha = tamagotchiView.ObterEscolhaDoJogador(4);

                switch (escolha)
                {
                    case 1:
                        Adoção();
                        break;
                    case 2:
                        InteragirComMascote();
                        break;
                    case 3:
                        tamagotchiView.MostrarMascotesAdotados(mascotesAdotados);
                        break;
                    case 4:
                        Console.WriteLine("Te vejo na próxima!");
                        return;
                }
            }
        }

        private void Adoção()
        {
            while (true)
            {
                tamagotchiView.MostrarMenuDeAdocao();
                int escolha = tamagotchiView.ObterEscolhaDoJogador(4);
                switch (escolha)
                {
                    case 1:
                        tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                        break;
                    case 2:
                        MostrarDetalhesDaEspecie();
                        break;
                    case 3:
                        AdotarMascote();
                        break;
                    case 4:
                        return;
                }
            }
        }

        private void MostrarDetalhesDaEspecie()
        {
            tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
            int indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
            PokemonDetailsResult detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
            tamagotchiView.MostrarDetalhesDaEspecie(detalhes);
        }

        private void AdotarMascote()
        {
            tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
            int indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
            PokemonDetailsResult detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
            tamagotchiView.MostrarDetalhesDaEspecie(detalhes);

            if (tamagotchiView.ConfirmarAdocao())
            {
                var tamagotchi = new Dto();
                tamagotchi.AtualizarPropriedades(detalhes);
                mascotesAdotados.Add(tamagotchi);

                Console.WriteLine("Parabéns! Você adotou um " + detalhes.Name + "!");
                ExibirImagemDeParabens();
            }
        }

        private void ExibirImagemDeParabens()
        {
            Console.WriteLine("+@%=.                        ...   ");
            Console.WriteLine(".*@=:-=.                .---#@#.   ");
            Console.WriteLine("  :*:::-=.            :--::-%*.    ");
            Console.WriteLine("   .--:::-:.::----:..-::::-=. .:--=");
            Console.WriteLine("     .:-:::::::::::::::--::-=-::::-");
            Console.WriteLine("       .::::::::::::::-=-::::::::-:");
            Console.WriteLine("       .=:--:::::::---:+:::::::::-.");
            Console.WriteLine("       .=-@%*::::::@@@:=:::::::-=-.");
            Console.WriteLine("       -*+-:::::::::::=+=:=.       ");
            Console.WriteLine("      .-***-::::::::-***=::-:      ");
            Console.WriteLine("        :*-::::::::::-*::=:::=.    ");
            Console.WriteLine("        :-:--::::::---:=:--:.      ");
            Console.WriteLine("       .-:::::---:-::::-**-        ");
            Console.WriteLine("      :-::::::-::+::::::-.         ");
            Console.WriteLine("   .::=:-:::::=::-::::--:=...      ");
            Console.WriteLine("   .==-:--::::--=:::::-:-=-=.      ");
            Console.WriteLine("    .===-==:::===::::*--==-        ");
            Console.WriteLine("      .+=+++---..=-:+==+-          ");
        }

        private void InteragirComMascote()
        {
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("Você não tem nenhum mascote adotado.");
                return;
            }

            Console.WriteLine("Escolha um mascote para interagir:");
            for (int i = 0; i < mascotesAdotados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mascotesAdotados[i].Nome}");
            }

            int indiceMascote = tamagotchiView.ObterEscolhaDoJogador(mascotesAdotados.Count) - 1;
            Dto mascoteEscolhido = mascotesAdotados[indiceMascote];

            int opcaoInteracao = 0;
            while (opcaoInteracao != 4)
            {
                tamagotchiView.MostrarMenuInteracao();
                opcaoInteracao = tamagotchiView.ObterEscolhaDoJogador(4);

                switch (opcaoInteracao)
                {
                    case 1:
                        mascoteEscolhido.MostrarStatus();
                        break;
                    case 2:
                        mascoteEscolhido.Alimentar();
                        break;
                    case 3:
                        mascoteEscolhido.Brincar();
                        break;
                }
            }
        }
    }
}
