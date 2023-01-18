using PesquisaDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  [RoutePrefix("api")]
  public class RelatorioController : Controller
    {
      [Route("relatorio")]
      [HttpPost]
      public string RelatorioRJ()
      {
        SolicitacaoDAO solicitacao = new SolicitacaoDAO();
        string relatorio =solicitacao.Relatorio();

        return relatorio;
      }
    }
}