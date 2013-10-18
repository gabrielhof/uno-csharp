using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uno.game;

namespace Uno
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Jogo jogo = (Jogo) Application["jogo"];
            if (jogo == null)
            {
                jogo = new Jogo();
                Application["jogo"] = jogo;
            }

            if (!Session.IsNewSession)
            {
                Jogador jogador = (Jogador) Session["jogador"];
                if (jogador != null)
                {
                    if (jogo.estaIniciado())
                    {
                        Response.Redirect("JogoUno.aspx");
                        return;
                    }
                    else
                    {
                        Response.Redirect("Aguardando.aspx");
                        return;
                    }
                }
            }
        }

        protected void Iniciar_Click(object sender, EventArgs e)
        {
            if (Nome.Text == null || Nome.Text.Trim().Length == 0)
            {
                return;
            }

            Jogador jogador = new Jogador();
            jogador.nome = Nome.Text;
            jogador.estaPronto = false;

            Jogo jogo = (Jogo) Application["jogo"];
            jogo.novoJogador(jogador);

            Session["jogador"] = jogador;

            Response.Redirect("Aguardando.aspx");
        }
    }
}