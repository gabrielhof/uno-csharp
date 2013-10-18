using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Uno.game;

namespace Uno
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession=true)]
        public Boolean FoiAtualizado()
        {
            Jogo jogo = (Jogo) Application["jogo"];

            if (jogo == null)
            {
                return false;
            }

            if (jogo.houveAlteracao)
            {
                Boolean todosAtualizaram = true;
                foreach (Jogador jogador in jogo.jogadores)
                {
                    if (!jogador.atualizou)
                    {
                        todosAtualizaram = false;
                        break;
                    }
                }

                if (todosAtualizaram)
                {
                    jogo.houveAlteracao = false;
                    foreach (Jogador jogador in jogo.jogadores)
                    {
                        jogador.atualizou = false;
                    }
                }
            }


            Jogador jogadorSessao = (Jogador)Session["jogador"];

            Boolean result = jogo.houveAlteracao && !jogadorSessao.atualizou;

            if (result)
            {
                jogadorSessao.atualizou = true;
            }

            return result;
        }
    }
}
