using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uno.game;

namespace Uno
{
    public partial class JogoUno : System.Web.UI.Page
    {
        private Jogo jogo;
        private Jogador jogadorSessao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.validarRequisicao())
            {
                return;
            }

            this.carregarCartasJogadorSessao();

            if (this.jogadorSessaoBloqueado())
            {
                return;
            }

            this.carregarUltimaCartaDescartada();
            this.carregarJogadores();
            this.configuraBotoes();
        }

        private Boolean validarRequisicao()
        {
            if (Session.IsNewSession || Session["jogador"] == null)
            {
                Response.Redirect("Index.aspx");
                return false;
            }

            jogo = (Jogo) Application["jogo"];
            if (!jogo.podeIniciar())
            {
                Response.Redirect("Aguardando.aspx");
                return false;
            }
            else if (jogo.possuiVencedor() || jogo.empatou())
            {
                Response.Redirect("Terminou.aspx");
                return false;
            }

            this.jogadorSessao = (Jogador) Session["jogador"];
            return true;
        }

        private void carregarCartasJogadorSessao()
        {
            if (jogadorSessao.Equals(jogo.jogadorAtual))
            {
                LiteralControl aviso = new LiteralControl();
                aviso.Text = "<div class='alert alert-success'>";
                aviso.Text += "<strong>" + jogadorSessao.nome  + ", é a sua vez agora!</strong>";
                aviso.Text += "</div>";

                SuaVezPanel.Visible = true;
                SuaVezPanel.Controls.Add(aviso);
            }
            else
            {
                SuaVezPanel.Visible = false;
            }

            SuasCartas.Text = "<strong>" + jogadorSessao.nome + "</strong>, essas são suas cartas:";
            SuasCartas.Text += "<span class='glyphicon glyphicon-tower' style='float: right;'></span> ";

            int contadorBotao = 0;
            foreach (Carta carta in jogadorSessao.cartas)
            {
                ImageButton imageButton = new ImageButton();
                imageButton.ID = "carta_" + contadorBotao++;
                imageButton.ImageUrl = carta.ToImageTag();
                imageButton.AlternateText = carta.ToIdentifier();
                imageButton.Attributes.Add("runat", "server");
                imageButton.Click += JogarCarta_Click;

                Cartas.Controls.Add(imageButton);
            }
        }

        private Boolean jogadorSessaoBloqueado()
        {
            if (jogadorSessao.estaBloqueado())
            {
                jogo.trocarJogador();

                Response.Redirect("JogoUno.aspx");
                return true;
            }

            return false;
        }

        private void carregarUltimaCartaDescartada()
        {
            Carta ultimaCarta = jogo.pegaUltimaCartaDescartada();
            UltimaCarta.Text = "<img src='" + ultimaCarta.ToImageTag() + "' />";
        }

        private void carregarJogadores()
        {
            foreach (Jogador jogador in jogo.jogadores)
            {
                TableCell icon = new TableCell();
                icon.Text = "<span class='glyphicon glyphicon-user'></span>";

                TableCell nomeJogador = new TableCell();
                nomeJogador.Text = jogador.nome;

                if (jogador.Equals(jogadorSessao))
                {
                    nomeJogador.Text = "<bold>" + nomeJogador.Text + "</bold>";
                }

                TableCell cartasJogador = new TableCell();
                cartasJogador.Text = "";

                foreach (Carta carta in jogador.cartas)
                {
                    cartasJogador.Text += "<img src='assets/image/VERSO.png' width='30px' height='40px'/>";
                }

                TableCell currentPlayerIcon = new TableCell();
                if (jogador.Equals(jogo.jogadorAtual))
                {
                    currentPlayerIcon.Text = "<span class='glyphicon glyphicon-arrow-right' title='Jogador Atual'></span>";
                }

                TableRow row = new TableRow();
                row.Cells.Add(currentPlayerIcon);
                row.Cells.Add(icon);
                row.Cells.Add(nomeJogador);
                row.Cells.Add(cartasJogador);

                Table.Rows.Add(row);
            }
        }

        private void configuraBotoes()
        {
            if (!jogadorSessao.Equals(jogo.jogadorAtual))
            {
                ComprarCarta.CssClass += " disabled";
                PassarVez.CssClass += " disabled";
            }
            else
            {
                ComprarCarta.CssClass += (!jogadorSessao.jaComprouCarta ? "" : " disabled");
                PassarVez.CssClass += (jogadorSessao.jaComprouCarta ? "" : " disabled");
            }
        }

        protected void PassarVez_Click(object sender, EventArgs e)
        {
            Jogo jogo = (Jogo) Application["jogo"];
            jogo.trocarJogador();

            Response.Redirect("JogoUno.aspx");
        }

        protected void ComprarCarta_Click(object sender, EventArgs e)
        {
            Jogo jogo = (Jogo)Application["jogo"];

            Jogador jogador = (Jogador) Session["jogador"];
            jogador.compraCarta(jogo);
            jogador.jaComprouCarta = true;

            jogo.houveAlteracao = true;
            jogador.atualizou = true;

            Response.Redirect("JogoUno.aspx");
        }

        protected void JogarCarta_Click(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;

            Jogo jogo = (Jogo) Application["jogo"];

            Jogador jogador = (Jogador) Session["jogador"];

            if (jogador.Equals(jogo.jogadorAtual))
            {
                foreach (Carta carta in jogador.cartas)
                {
                    if (carta.ToIdentifier().Equals(button.AlternateText))
                    {
                        jogador.descarta(carta, jogo);
                        break;
                    }
                }
            }

            Response.Redirect("JogoUno.aspx");
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            jogo.jogadores.Remove(jogadorSessao);
            Session.Abandon();

            if (jogo.jogadores.Count == 1)
            {
                jogo.vencedor = jogo.jogadores[0];
            }

            jogo.houveAlteracao = true;
            Response.Redirect("Index.aspx");
        }
    }
}