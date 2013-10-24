using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uno.game;

namespace Uno
{
    public partial class AguardarNovoJogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.validarRequisicao())
            {
                return;
            }
        }

        private Boolean validarRequisicao()
        {
            Jogo jogo = (Jogo) Application["jogo"];

            if (jogo == null || !jogo.estaIniciado())
            {
                Response.Redirect("Index.aspx");
                return false;
            }

            return true;
        }
    }
}