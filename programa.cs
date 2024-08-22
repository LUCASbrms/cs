using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Campeonato campeonato = new Campeonato("Campeonato de CS:GO");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Criar jogador");
            Console.WriteLine("2. Criar equipe");
            Console.WriteLine("3. Adicionar jogador à equipe");
            Console.WriteLine("4. Iniciar partida");
            Console.WriteLine("5. Ver classificação");
            Console.WriteLine("6. Sair");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.Write("Digite o nome do jogador: ");
                    string nomeJogador = Console.ReadLine();
                    Console.Write("Digite o nickname do jogador: ");
                    string nicknameJogador = Console.ReadLine();
                    Jogador jogador = new Jogador(nomeJogador, nicknameJogador);
                    break;

                case 2:
                    Console.Write("Digite o nome da equipe: ");
                    string nomeEquipe = Console.ReadLine();
                    Equipe equipe = new Equipe(nomeEquipe);
                    campeonato.EquipesParticipantes.Add(equipe);
                    break;

                case 3:
                    Console.Write("Digite o nome da equipe: ");
                    string nomeEquipeParaAdicionar = Console.ReadLine();
                    Equipe equipeParaAdicionar = campeonato.EquipesParticipantes.Find(e => e.NomeEquipe == nomeEquipeParaAdicionar);

                    if (equipeParaAdicionar != null)
                    {
                        Console.Write("Digite o nickname do jogador: ");
                        string nicknameJogadorParaAdicionar = Console.ReadLine();
                        Jogador jogadorParaAdicionar = new Jogador("Nome fictício", nicknameJogadorParaAdicionar);
                        equipeParaAdicionar.AdicionarJogador(jogadorParaAdicionar);
                    }
                    else
                    {
                        Console.WriteLine("Equipe não encontrada.");
                    }
                    break;

                case 4:
                    Console.Write("Digite o nome da primeira equipe: ");
                    string nomeEquipe1 = Console.ReadLine();
                    Equipe equipe1 = campeonato.EquipesParticipantes.Find(e => e.NomeEquipe == nomeEquipe1);

                    Console.Write("Digite o nome da segunda equipe: ");
                    string nomeEquipe2 = Console.ReadLine();
                    Equipe equipe2 = campeonato.EquipesParticipantes.Find(e => e.NomeEquipe == nomeEquipe2);

                    if (equipe1 != null && equipe2 != null)
                    {
                        campeonato.IniciarPartida(equipe1, equipe2);
                        Console.WriteLine("Partida simulada.");
                    }
                    else
                    {
                        Console.WriteLine("Equipe(s) não encontrada(s).");
                    }
                    break;

                case 5:
                    campeonato.Classificacao();
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
