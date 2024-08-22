using System;
using System.Collections.Generic;

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