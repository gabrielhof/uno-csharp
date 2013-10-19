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

        private Boolean _houveAlteracao = false;
        public Boolean houveAlteracao
        {
            get {
                return _houveAlteracao;
            }
 
            set {
                if (value)
                {
                    foreach (Jogador jogador in jogadores)
                    {
                        jogador.atualizou = false;
                    }
                }

                _houveAlteracao = value;
            }
        }

        public Jogo()
        {
            this.jogadores = new List<Jogador>();
            this.descartadas = new List<Carta>();

            this.houveAlteracao = false;
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
            Jogador antigoJogador = null;
            if (this.jogadorAtual != null)
            {
                antigoJogador = this.jogadorAtual;
                this.jogadorAtual.jaComprouCarta = false;
            }

            do
            {
                this.jogadorAtual = pegaProximoJogador();
            } while (this.jogadorAtual.estaBloqueado());

            houveAlteracao = true;

            if (antigoJogador != null)
            {
                antigoJogador.atualizou = true;
            }
            
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
            this.houveAlteracao = true;
            jogador.atualizou = true;
        }

        public void removerJogador(Jogador jogador)
        {
            this.jogadores.Remove(jogador);
            this.houveAlteracao = true;
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