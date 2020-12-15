using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    public class SincronizadorDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDB"].ConnectionString;
        private IDbConnection conexao;
        public SincronizadorDTO PegaTodasMaxSincronia(SincronizadorDTO sincroniaBase, SincronizadorDTO sincroniaResult)
        {
            //sincroniaResult.MaxSincMensagem = PegarMaxSincMensagem(sincroniaBase.MaxSincMensagem);
            return sincroniaResult;
        }
        private int PegarMaxSincMensagem(int SincBase)
        {
            try
            {
                conexao = new SqlConnection(stringConexao);
                conexao.Open();
                IDbCommand selectCmd = conexao.CreateCommand();
                //colocar uma lista de grupos dto
                selectCmd.CommandText = "select MAX(ContSyncronia) as ContSyncronia from Mensagem where PaiSyncronia = 1 and Grupo = 1";
                IDataReader resultado = selectCmd.ExecuteReader();
                resultado.Read();

                int maxSincronia = Convert.ToInt32(resultado["ContSyncronia"]);

                if (maxSincronia.Equals(null))
                {
                    return SincBase;
                }
                return maxSincronia;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public SincronizadorDTO PegarMensagensNaoSincronizadas(SincronizadorDTO listaMensagemSinc)
        {

            List<MensagemDTO> listaMensagens = new List<MensagemDTO>();

            try
            {
                conexao = new SqlConnection(stringConexao);
                conexao.Open();
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "select * from mensagem where grupo = 1 and ContSyncronia > 1";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var mensagen = new MensagemDTO()
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        Mensagem = Convert.ToString(resultado["Mensagem"]),
                        Grupo = Convert.ToInt32(resultado["Grupo"]),
                        PaiMensagem = Convert.ToInt32(resultado["PaiMensagem"]),
                        ContSyncronia = Convert.ToInt32(resultado["ContSyncronia"]),
                        PaiSyncronia = Convert.ToInt32(resultado["PaiSyncronia"])
                    };
                    listaMensagens.Add(mensagen);
                }
                listaMensagemSinc.ListaMensagem = listaMensagens;
                return listaMensagemSinc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
