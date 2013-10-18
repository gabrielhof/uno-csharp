using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class CartaBloquear : Carta
    {

        public CartaBloquear(Cor cor)
            : base(-1, cor)
        {
        }

        public override bool combinaCom(Carta carta)
        {
            return carta is CartaBloquear || carta.cor == this.cor;
        }

        public override void realizaAcao(Jogo jogo)
        {
            jogo.pegaProximoJogador().bloquear();
        }

        public override string ToString()
        {
            return "Bloquear";
        }
    }
}