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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession || Session["jogador"] == null)
            {
                Response.Redirect("Index.aspx");
                return;
            }

            Jogo jogo = (Jogo) Application["jogo"];
            if (!jogo.podeIniciar())
            {
                Response.Redirect("Aguardando.aspx");
                return;
            }
            else if (jogo.possuiVencedor() || jogo.empatou())
            {
                Response.Redirect("Terminou.aspx");
                return;
            }

            Jogador jogadorSessao = (Jogador)Session["jogador"];

            if (jogadorSessao.estaBloqueado())
            {
                jogo.trocarJogador();

                Response.Redirect("JogoUno.aspx");
                return;
            }

            Carta ultimaCarta = jogo.pegaUltimaCartaDescartada();
            UltimaCarta.Text = ultimaCarta.ToString();
            UltimaCarta.Style["color"] = ultimaCarta.ToColorHash();

            foreach (Jogador jogador in jogo.jogadores)
            {
                if (!jogador.Equals(jogadorSessao))
                {
                    TableCell nomeJogador = new TableCell();
                    nomeJogador.Text = jogador.nome;

                    TableCell quantidadeCartas = new TableCell();
                    quantidadeCartas.Text = jogador.cartas.Count.ToString();

                    TableRow row = new TableRow();
                    row.Cells.Add(nomeJogador);
                    row.Cells.Add(quantidadeCartas);

                    Table.Rows.Add(row);
                }
            }

            CartasHeader.ColumnSpan = jogadorSessao.cartas.Count;
            TableRow cartasRow = new TableRow();
            foreach (Carta carta in jogadorSessao.cartas)
            {
                LinkButton link = new LinkButton();
                link.Text = carta.ToString();
                link.Style["color"] = carta.ToColorHash();
                link.Click += JogarCarta_Click;

                TableCell cell = new TableCell();
                cell.Controls.Add(link);

                cartasRow.Cells.Add(cell);
            }

            Cartas.Rows.Add(cartasRow);

            if (!jogadorSessao.Equals(jogo.jogadorAtual))
            {
                ComprarCarta.Enabled = false;
                PassarVez.Enabled = false;
            }
            else
            {
                ComprarCarta.Enabled = !jogadorSessao.jaComprouCarta;
                PassarVez.Enabled = jogadorSessao.jaComprouCarta;
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
            Jogador jogador = (Jogador) Session["jogador"];
            jogador.compraCarta((Jogo) Application["jogo"]);
            jogador.jaComprouCarta = true;

            Response.Redirect("JogoUno.aspx");
        }

        protected void JogarCarta_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton) sender;

            Jogo jogo = (Jogo) Application["jogo"];

            Jogador jogador = (Jogador) Session["jogador"];

            if (jogador.Equals(jogo.jogadorAtual))
            {
                foreach (Carta carta in jogador.cartas)
                {
                    if (carta.ToString().Equals(button.Text) && carta.ToColorHash().Equals(button.Style["color"]))
                    {
                        jogador.descarta(carta, jogo);
                        break;
                    }
                }
            }

            Response.Redirect("JogoUno.aspx");
        }
    }
}