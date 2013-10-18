using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uno.game;

namespace Uno
{
    public partial class Aguardando : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession || Session["jogador"] == null)
            {
                Response.Redirect("Index.aspx");
                return;
            }

            Jogo jogo = (Jogo) Application["jogo"];

            if (jogo.podeIniciar())
            {
                if (!jogo.estaIniciado())
                {
                    jogo.iniciar();
                }

                Response.Redirect("JogoUno.aspx");
                return;
            }
            else
            {
                foreach (Jogador jogador in jogo.jogadores)
                {
                    TableCell nomeJogador = new TableCell();
                    nomeJogador.Text = jogador.nome;

                    TableCell estaPronto = new TableCell();
                    estaPronto.Text = jogador.estaPronto ? "Sim" : "Não";

                    TableRow row = new TableRow();
                    row.Cells.Add(nomeJogador);
                    row.Cells.Add(estaPronto);

                    Tabela.Rows.Add(row);
                }
            }
        }

        protected void Pronto_Click(object sender, EventArgs e)
        {
            Jogador jogador = (Jogador) Session["jogador"];
            jogador.estaPronto = true;

            Response.Redirect("Aguardando.aspx");
        }
    }
}