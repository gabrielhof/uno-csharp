using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class CartaInverter : Carta
    {

        public CartaInverter(Cor cor)
            : base(-1, cor)
        {
        }

        public override bool combinaCom(Carta carta)
        {
            return carta is CartaInverter || carta.cor == this.cor;
        }

        public override void realizaAcao(Jogo jogo)
        {
            jogo.inverterOrdem();
        }

        public override string ToString()
        {
            return "TROCA";
        }

    }
}