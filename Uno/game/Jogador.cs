using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class Jogador
    {
        public String nome { get; set; }
        public Boolean estaPronto { get; set; }
        public List<Carta> cartas {get; set;}

        private Boolean bloqueado = false;

        public Boolean jaComprouCarta { get; set; }

        public Jogador()
        {
            estaPronto = false;
            cartas = new List<Carta>();

            this.jaComprouCarta = false;
        }

        public void compraCarta(Jogo jogo)
        {
            this.cartas.Add(jogo.baralho.pegarCarta());
        }

        public Boolean descarta(Carta carta, Jogo jogo)
        {
            Carta ultimaCarta = jogo.pegaUltimaCartaDescartada();

            Boolean resultado = ultimaCarta.combinaCom(carta);
            if (resultado) {
                this.cartas.Remove(carta);
                carta.realizaAcao(jogo);

                jogo.descartadas.Add(carta);

                if (cartas.Count == 0)
                {
                    jogo.vencedor = this;
                }
                else
                {
                    jogo.trocarJogador();
                }
            }

            return resultado;
        }

        public void bloquear()
        {
            this.bloqueado = true;
        }

        public Boolean estaBloqueado()
        {
            Boolean bloqueado = this.bloqueado;
            this.bloqueado = false;

            return bloqueado;
        }

    }
}