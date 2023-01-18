using EntidadesPesquisa;
using Newtonsoft.Json;
using PesquisaDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utils;


namespace WebApplication1.Controllers
{
  [RoutePrefix("api/Pesquisa")]
  public class PesquisaController : ApiController
    {
    [Route("Pesquisa")]
    [HttpPost]
    public string PesquisarVacinados([FromBody] SolicitanteDTO solicitante)
    {
      if (solicitante == null)
        return "Parâmetros inválidos";

      if (String.IsNullOrEmpty(solicitante.Nome) || String.IsNullOrEmpty(solicitante.CPF))
      {
        return "Dados inválidos";
      }
      else
      {
        if (!Util.ValidarCPF(solicitante.CPF))
          return "CPF informado não é válido";
      }


      SolicitanteDAO pesquisa = new SolicitanteDAO();
      SolicitacaoDAO solicitacao = new SolicitacaoDAO();
      string verificaSolicitante = pesquisa.CadastarCliente(solicitante);

      if (!verificaSolicitante.Equals("OK"))
        return "Erro ao cadastrar o solicitante";

      //Verificando se o CPF já fez uma pesquisa na data de hoje
      if (solicitacao.VerificarPesquisaDia(solicitante) == "1")
        return "O solicitante já realizou pesquisa no dia de hoje. Favor aguardar 24 horas para pesquisar novamente.";


      string resultadoPesquisa = Util.EnviarRest("{ \"size\": 10000 }");

      dynamic json = JsonConvert.DeserializeObject(resultadoPesquisa);
      string dataEnviada;
      string resultado;

      try
      {
        for (int i=0; i <= json["hits"]["hits"].Count - 1; i++)
        {
          if (json["hits"]["hits"][i]["_source"]["paciente_endereco_uf"] == "RJ"  && json["hits"]["hits"][i]["_source"]["vacina_fabricante_nome"] == "PFIZER")
          {
            string teste = json["hits"]["hits"][i]["_source"]["vacina_dataAplicacao"];
            dataEnviada = json["hits"]["hits"][i]["_source"]["vacina_dataAplicacao"].ToString("yyyyMMdd");
            resultado = solicitacao.CadastrarPesquisa(solicitante, dataEnviada);
          }
        }

        return "Pesquisa realizada com sucesso para o solicitante " + solicitante.Nome + "(" + solicitante.CPF + ")";
      }
      catch(Exception ex)
      {
        return "Erro ao cadastrar a pesquisa: " + ex.Message;
      }

      
    }

    [Route("relatorio")]
    [HttpPost]
    public string RelatorioRJ()
    {
      SolicitacaoDAO solicitacao = new SolicitacaoDAO();
      string relatorio = solicitacao.Relatorio();

      return relatorio;
    }

  }
}
