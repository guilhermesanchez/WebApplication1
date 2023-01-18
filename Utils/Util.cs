using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
  public static class Util
  {
    public static string EnviarRest(string json)
    {
      string username = "imunizacao_public";
      string password = "qlto5t&7r_@+#Tlstigi";

      string url = ConfigurationManager.AppSettings["urlPesquisa"].ToString();

      System.Net.ServicePointManager.SecurityProtocol =
                  SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;


      var client = new RestClient(url);
      var request = new RestRequest(Method.POST);
      request.AddParameter("application/json", json, ParameterType.RequestBody);

      String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
      request.AddHeader("Authorization", "Basic " + encoded);

      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      IRestResponse response = client.Execute(request);

      string content = string.Empty;
      if (!(response == null))
      {
        content = response.Content;
        if (string.IsNullOrEmpty(response.Content))
        {
          content = response.ErrorMessage;
        }
      }

      return content;
    }

		public static bool ValidarCPF(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}


		public static string DataTableParaJson(DataTable table)
		{
			string JSONString = string.Empty;
			JSONString = JsonConvert.SerializeObject(table);
			return JSONString;
		}

	}
}
