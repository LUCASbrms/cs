using System;
using System.Collections.Generic;
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
