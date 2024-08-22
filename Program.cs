using System;
using System.Collections.Generic;

class Jogador
{
    public string Nome { get; set; }
    public string Nickname { get; set; }
    public int Pontos { get; private set; }

    public Jogador(string nome, string nickname)
    {
        Nome = nome;
        Nickname = nickname;
        Pontos = 0;
    }

    public void Jogar()
    {
        Random random = new Random();
        int pontosDaPartida = random.Next(1, 101);
        Pontos += pontosDaPartida;
    }
}

class Equipe
{
    public string NomeEquipe { get; set; }
    private List<Jogador> Jogadores { get; set; }

    public Equipe(string nomeEquipe)
    {
        NomeEquipe = nomeEquipe;
        Jogadores = new List<Jogador>();
    }

    public int PontosTotal()
    {
        int totalPontos = 0;
        foreach (var jogador in Jogadores)
        {
            totalPontos += jogador.Pontos;
        }
        return totalPontos;
    }

    public void AdicionarJogador(Jogador jogador)
    {
        if (Jogadores.Count < 5)
        {
            Jogadores.Add(jogador);
        }
        else
        {
            Console.WriteLine("A equipe já tem 5 jogadores. Não é possível adicionar mais.");
        }
    }
}

class Campeonato
{
    public string NomeCampeonato { get; set; }
    private List<Equipe> EquipesParticipantes { get; set; }

    public Campeonato(string nomeCampeonato)
    {
        NomeCampeonato = nomeCampeonato;
        EquipesParticipantes = new List<Equipe>();
    }

    public void IniciarPartida(Equipe e1, Equipe e2)
    {
        foreach (var jogador in e1.Jogadores)
        {
            jogador.Jogar();
        }

        foreach (var jogador in e2.Jogadores)
        {
            jogador.Jogar();
        }
    }

    public void Classificacao()
    {
        EquipesParticipantes.Sort((e1, e2) => e2.PontosTotal().CompareTo(e1.PontosTotal()));
        Console.WriteLine("Classificação:");
        for (int i = 0; i < EquipesParticipantes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {EquipesParticipantes[i].NomeEquipe} - {EquipesParticipantes[i].PontosTotal()} pontos");
        }
    }
}

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
