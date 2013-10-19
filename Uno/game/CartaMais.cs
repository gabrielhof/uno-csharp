using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class CartaMais : Carta
    {

        public CartaMais(int numero, Cor cor)
            : base(numero, cor)
        {}

        public override void realizaAcao(Jogo jogo)
        {
            Jogador jogador = jogo.pegaProximoJogador();

            for (int i = 0; i < this.numero; i++)
            {
                jogador.compraCarta(jogo);
            }
        }

        public override string ToString()
        {
            return "plus" + numero;
        }

    }
}