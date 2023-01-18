using EntidadesPesquisa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace PesquisaDAO
{
  public class SolicitanteDAO
  {
    private string stringConexao;

    public SolicitanteDAO()
    {
      this.stringConexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
    }
    public string CadastarCliente(SolicitanteDTO solicitante)
    {

      string conexao = this.stringConexao;

      SqlDataReader dr;

      string retorno = "";

      using (SqlConnection sqlConn = new SqlConnection(conexao))
      {
        sqlConn.Open();

        SqlCommand sqlCmd = new SqlCommand("sp_verificasolicitante", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@Nome", SqlDbType.VarChar).Value = solicitante.Nome;
        sqlCmd.Parameters.AddWithValue("@CPF", SqlDbType.VarChar).Value = solicitante.CPF;

        dr = sqlCmd.ExecuteReader();

        if (dr.HasRows)
        {
          while (dr.Read())
          {
            retorno = dr["resultado"].ToString();
          }
        }

        dr.Close();

      }

      return retorno;
    }
  }
}
