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
