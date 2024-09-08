using System;
using System.Collections.Generic;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class TamagotchiView
    {
        public void MostrarMensagemDeBoasVindas()
        {
            Console.WriteLine("Bem-vindo ao menu de adoção ao mascote!");
            Console.Write("Por favor, digite seu nome: ");
            string nomeJogador = Console.ReadLine();
            Console.WriteLine("Olá, " + nomeJogador + "! Seja bem vindo, escolha uma opção abaixo: ");
        }

        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("1. Adotar um Mascote");
            Console.WriteLine("2. Interagir com seu Mascote");
            Console.WriteLine("3. Ver Mascotes Adotados");
            Console.WriteLine("4. Sair do Jogo");
            Console.Write("Escolha uma opção: ");
        }

        public void MostrarMenuInteracao()
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Menu de Interação:");
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("1. Saber como o mascote está");
            Console.WriteLine("2. Alimentar o mascote");
            Console.WriteLine("3. Brincar com o mascote");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção: ");
        }

        public int ObterEscolhaDoJogador(int maxOpcao)
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maxOpcao)
            {
                Console.Write($"Escolha inválida. Por favor, escolha uma opção entre 1 e {maxOpcao}: ");
            }
            return escolha;
        }

        public void MostrarMenuDeAdocao()
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Menu de Adoção de Mascotes:");
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("1. Ver Espécies Disponíveis");
            Console.WriteLine("2. Ver Detalhes de uma Espécie");
            Console.WriteLine("3. Adotar um Mascote");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public void MostrarEspeciesDisponiveis(List<MvcResult> especies)
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Espécies Disponíveis para Adoção:");
            Console.WriteLine("\n ------------------------------");
            for (int i = 0; i < especies.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + especies[i].Name);
            }
        }

        public void MostrarDetalhesDaEspecie(PokemonDetailsResult detalhes)
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Detalhes da Espécie:");
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Nome: " + detalhes.Name);
            double alturaEmMetros = detalhes.Height / 10.0; 
            double pesoEmQuilos = detalhes.Weight / 10.0;  

            Console.WriteLine($"Altura: {alturaEmMetros:F1} metros");
            Console.WriteLine($"Peso: {pesoEmQuilos:F1} kg");
            Console.WriteLine("Habilidades:");
            foreach (var habilidade in detalhes.Abilities)
            {
                Console.WriteLine("- " + habilidade.Ability.Name);
            }
        }

        public bool ConfirmarAdocao()
        {
            Console.WriteLine("\n ------------------------------");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void MostrarMascotesAdotados(List<Dto> mascotesAdotados)
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Mascotes Adotados:");
            Console.WriteLine("\n ------------------------------");
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum mascote.");
            }
            else
            {
                for (int i = 0; i < mascotesAdotados.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + mascotesAdotados[i].Nome);
                }
            }
        }

        public int ObterEspecieEscolhida(List<Species> especies)
        {
            Console.WriteLine("\n ------------------------------");
            int escolha;
            while (true)
            {
                Console.WriteLine("\n ------------------------------");
                Console.Write("Escolha uma espécie pelo número (1-" + especies.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= especies.Count)
                {
                    break;
                }
                Console.WriteLine("\n ------------------------------");
                Console.WriteLine("Escolha inválida.");
            }
            return escolha - 1;
        }

        internal int ObterEspecieEscolhida(List<MvcResult> especiesDisponiveis)
        {
            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("Escolha uma espécie da lista abaixo:");

            for (int i = 0; i < especiesDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {especiesDisponiveis[i].Name}");
            }

            int escolha;
            do
            {
                Console.WriteLine("\n ------------------------------");
                Console.WriteLine("Digite o número da espécie escolhida:");
                string input = Console.ReadLine();

                // Verifica se o input é um número e está dentro do intervalo válido
                bool isValid = int.TryParse(input, out escolha) && escolha >= 1 && escolha <= especiesDisponiveis.Count;

                if (!isValid)
                {
                    Console.WriteLine("\n ------------------------------");
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            } while (escolha < 1 || escolha > especiesDisponiveis.Count);

            // Retorna o índice da escolha do usuário (ajustado para índice base 0)
            return escolha - 1;
        }
    }
    public class Mascot
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<Ability> Abilities { get; set; }
        public int Alimentacao { get; set; }
        public int Humor { get; set; }

        public Mascot()
        {
            Random rand = new Random();
            Alimentacao = rand.Next(0, 11);
            Humor = rand.Next(0, 11);
        }

        public void BrincaMascote()
        {
            if (Humor < 10)
            {
                Humor++;
            }
            if (Alimentacao > 0)
            {
                Alimentacao--;
            }

            Console.WriteLine("^_^");

            Console.WriteLine($"{Name} brincou! Humor agora é {Humor} e alimentação é {Alimentacao}.");
        }

        public void AlimentarMascote()
        {
            if (Alimentacao < 10)
            {
                Alimentacao++;
            }

            Console.WriteLine("^_^");

            Console.WriteLine($"{Name} foi alimentado! Alimentação agora é {Alimentacao}.");
        }

        public void VerificarStatus()
        {
            Console.WriteLine($"{Name}'s Status:");
            Console.WriteLine($"Alimentação: {Alimentacao}/10");
            Console.WriteLine($"Humor: {Humor}/10");
        }
    }

    public class Ability
    {
        public string Name { get; set; }
    }
}