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

        public String ToColorCode()
        {
            switch (cor)
            {
                case Cor.AMARELO: return "AM";
                case Cor.AZUL: return "AZ";
                case Cor.VERDE: return "VR";
                case Cor.VERMELHO: return "VM";
            }

            return "";
        }

        public String ToIdentifier()
        {
            return ToColorCode() + "_" + ToString();
        }

        public String ToImageTag()
        {
            return "assets/image/" + ToColorCode() + "_" + ToString() + ".png";
        }

    }
}