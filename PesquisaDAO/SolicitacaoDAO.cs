using EntidadesPesquisa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace PesquisaDAO
{
  public class SolicitacaoDAO
  {
    private string stringConexao;

    public SolicitacaoDAO()
    {
      this.stringConexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
    }
    public string VerificarPesquisaDia(SolicitanteDTO solicitante)
    {
      string conexao = this.stringConexao;

      SqlDataReader dr;

      string retorno = "";

      using (SqlConnection sqlConn = new SqlConnection(conexao))
      {
        sqlConn.Open();

        SqlCommand sqlCmd = new SqlCommand("sp_VerificaPesquisaSolicitanteDia", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
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

    public string CadastrarPesquisa(SolicitanteDTO solicitante, string dataAplicacao)
    {
      string conexao = this.stringConexao;

      SqlDataReader dr;

      string retorno = "";

      using (SqlConnection sqlConn = new SqlConnection(conexao))
      {
        sqlConn.Open();

        SqlCommand sqlCmd = new SqlCommand("sp_CadastrarSolicitacao", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@CPF", SqlDbType.VarChar).Value = solicitante.CPF;
        sqlCmd.Parameters.AddWithValue("@data_aplicacao", SqlDbType.Date).Value = dataAplicacao;

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

    public string Relatorio()
    {
      string conexao = this.stringConexao;
      string retorno = "";

      DataTable table = new DataTable();
      using (var con = new SqlConnection(conexao))
      using (var cmd = new SqlCommand("sp_relatorios", con))
      using (var da = new SqlDataAdapter(cmd))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        da.Fill(table);
      }

      retorno = Util.DataTableParaJson(table);

      table.Dispose();

      return retorno;
    }
  }
}
