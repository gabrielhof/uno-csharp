using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uno.game;

namespace Uno
{
    public partial class Terminou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession || Session["jogador"] == null)
            {
                Response.Redirect("Index.aspx");
                return;
            }

            Jogo jogo = (Jogo) Application["jogo"];
            if (!jogo.possuiVencedor() && !jogo.empatou())
            {
                Response.Redirect("JogoUno.aspx");
                return;
            }
            else if (jogo.empatou())
            {
                Resultado.Text = "O jogo empatou! :(";
            }
            else if (jogo.possuiVencedor())
            {
                Resultado.Text = "Parabéns " + jogo.vencedor.nome + ", você venceu o jogo!";
            }
        }

        protected void NovoJogo_Click(object sender, EventArgs e)
        {
            Jogo antigoJogo = (Jogo) Application["jogo"];

            Jogo jogo = new Jogo();
            foreach (Jogador jogador in antigoJogo.jogadores)
            {
                jogador.estaPronto = false;
                jogo.novoJogador(jogador);
            }

            Application["jogo"] = jogo;

            Response.Redirect("Index.aspx");
        }
    }
}