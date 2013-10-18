using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class Jogo
    {
        private Boolean iniciado = false;

        public List<Jogador> jogadores {get; set;}
        public Jogador jogadorAtual {get; set;}
        public Jogador vencedor { get; set; }

        public Baralho baralho { get; set; }

        public List<Carta> descartadas;

        public Jogo()
        {
            this.jogadores = new List<Jogador>();
            this.descartadas = new List<Carta>();

            this.baralho = new Baralho();
        }

        public void iniciar()
        {
            foreach (Jogador jogador in jogadores)
            {
                for (int i = 0; i < 7; i++)
                {
                    jogador.compraCarta(this);
                }
            }

            this.iniciado = true;

            Carta carta = this.baralho.pegarCarta();
            this.descartadas.Add(carta);

            this.trocarJogador();
        }

        public Boolean estaIniciado()
        {
            return this.iniciado;
        }

        public Boolean podeIniciar()
        {
            if (jogadores.Count < 2)
            {
                return false;
            }

            foreach (Jogador jogador in jogadores)
            {
                if (!jogador.estaPronto)
                {
                    return false;
                }
            }

            return true;
        }

        public void trocarJogador()
        {
            if (this.jogadorAtual != null)
            {
                this.jogadorAtual.jaComprouCarta = false;
            }

            this.jogadorAtual = pegaProximoJogador();
        }

        public Jogador pegaProximoJogador()
        {
            int position = jogadores.IndexOf(jogadorAtual);
            position++;

            if (position >= jogadores.Count)
            {
                position = 0;
            }

            return jogadores[position];
        }

        public Carta pegaUltimaCartaDescartada()
        {
            return descartadas[descartadas.Count - 1];
        }

        public void inverterOrdem()
        {
            jogadores.Reverse();
        }

        public void novoJogador(Jogador jogador)
        {
            this.jogadores.Add(jogador);
        }

        public Boolean possuiVencedor()
        {
            return vencedor != null;
        }

        public Boolean empatou()
        {
            return vencedor == null && !baralho.possuiCartas();
        }
    }
}