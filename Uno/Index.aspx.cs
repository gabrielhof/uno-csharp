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
        private Jogo jogo;
        private Jogador jogador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.validarRequisicao())
            {
                return;
            }
        }

        private Boolean validarRequisicao()
        {
            jogo = (Jogo)Application["jogo"];
            if (jogo == null)
            {
                jogo = new Jogo();
                Application["jogo"] = jogo;
            }

            jogador = Session.IsNewSession ? null : (Jogador)Session["jogador"];

            if (jogo.estaIniciado() && jogador == null)
            {
                Response.Redirect("AguardarNovoJogo.aspx");
                return false;
            }
            else if (!jogo.estaIniciado() && jogador != null)
            {
                Response.Redirect("Aguardando.aspx");
                return false;
            }
            else if (jogo.estaIniciado() && jogador != null)
            {
                Response.Redirect("JogoUno.aspx");
                return false;
            }

            return true;
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