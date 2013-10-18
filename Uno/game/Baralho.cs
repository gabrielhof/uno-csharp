using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uno.game
{
    public class Baralho
    {
        private List<Carta> cartas {get; set;}

        public Baralho()
        {
            this.cartas = new List<Carta>();
            this.inicializaBaralho();
            this.embaralhar();
        }

        public Carta pegarCarta() {
            Random random = new Random();
            int pos = random.Next(0, cartas.Count-1);

            Carta carta = cartas[pos];
            this.cartas.Remove(carta);

            return carta;
        }

        public Boolean possuiCartas() {
            return this.cartas.Count > 0;
        }

        private void inicializaBaralho()
        {
            Cor[] cores = (Cor[]) Enum.GetValues(typeof(Cor));
            foreach (Cor cor in cores)
            {
                cartas.Add(new Carta(0, cor));

                for (int i = 1; i <= 9; i++)
                {
                    cartas.Add(new Carta(i, cor));
                    cartas.Add(new Carta(i, cor));
                }

                cartas.Add(new CartaMais(2, cor));
                cartas.Add(new CartaMais(2, cor));
                cartas.Add(new CartaMais(4, cor));

                cartas.Add(new CartaInverter(cor));
                cartas.Add(new CartaInverter(cor));

                cartas.Add(new CartaBloquear(cor));
                cartas.Add(new CartaBloquear(cor));
            }
        }

        protected void embaralhar()
        {
            Random random = new Random();

            for (int i = cartas.Count-1; i > 1; i--)
            {
                int k = random.Next(i + 1);
                Carta carta = cartas[k];

                cartas[k] = cartas[i];
                cartas[i] = carta;
            }
        }
    }
}