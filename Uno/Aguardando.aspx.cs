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

        private Jogo jogo;
        private Jogador jogadorSessao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.validarRequisicao())
            {
                return;
            }

            this.carregarJogadores();
            this.carregarAcoes();
        }

        private Boolean validarRequisicao()
        {
            if (Session.IsNewSession || Session["jogador"] == null)
            {
                Response.Redirect("Index.aspx");
                return false;
            }

            jogo = (Jogo)Application["jogo"];

            if (jogo.podeIniciar())
            {
                if (!jogo.estaIniciado())
                {
                    jogo.iniciar();
                }

                Response.Redirect("JogoUno.aspx");
                return false;
            }

            jogadorSessao = (Jogador) Session["jogador"];

            return true;
        }

        private void carregarJogadores()
        {
            foreach (Jogador jogador in jogo.jogadores)
            {
                TableCell icon = new TableCell();
                icon.Text = "<span class='glyphicon glyphicon-user'></span>";

                TableCell nomeJogador = new TableCell();
                nomeJogador.Text = jogador.nome;

                TableCell estaPronto = new TableCell();
                estaPronto.Text = jogador.estaPronto ? "<span class='glyphicon glyphicon-thumbs-up'></span>" : "<span class='glyphicon glyphicon-thumbs-down'></span>";

                TableRow row = new TableRow();
                row.Cells.Add(icon);
                row.Cells.Add(nomeJogador);
                row.Cells.Add(estaPronto);

                Tabela.Rows.Add(row);
            }
        }

        private void carregarAcoes()
        {
            Pronto.Visible = !jogadorSessao.estaPronto;
            PararDeJogar.Visible = !jogadorSessao.estaPronto;
            AguardandoButton.Visible = jogadorSessao.estaPronto;
        }

        protected void Pronto_Click(object sender, EventArgs e)
        {
            Jogador jogador = (Jogador) Session["jogador"];
            jogador.estaPronto = true;
            
            Jogo jogo = (Jogo) Application["jogo"];
            jogo.houveAlteracao = true;
            jogador.atualizou = true;

            Response.Redirect("Aguardando.aspx");
        }

        protected void PararDeJogar_Click(object sender, EventArgs e)
        {
            Jogo jogo = (Jogo) Application["jogo"];
            jogo.removerJogador((Jogador) Session["jogador"]);

            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}