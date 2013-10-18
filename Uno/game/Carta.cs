using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class Carta
    {
        public int numero {get; set;}
        public Cor cor {get; set;}

        public Carta(int numero, Cor cor)
        {
            this.numero = numero;
            this.cor = cor;
        }

        public virtual Boolean combinaCom(Carta carta)
        {
            return carta.numero == this.numero || carta.cor == this.cor;
        }

        public virtual void realizaAcao(Jogo jogo) {}

        public override string ToString()
        {
            return numero.ToString();
        }

        public String ToColorHash()
        {
            switch (cor)
            {
                case Cor.AMARELO: return "#B3B000";
                case Cor.AZUL: return "#0059FF";
                case Cor.VERDE: return "#00A120";
                case Cor.VERMELHO: return "#A10000";
            }

            return "";
        }

    }
}