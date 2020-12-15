using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace App.Repository
{
    public class MensagemDAO
    {
        //string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public MensagemDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<MensagemDTO> ListarMensagensDB()
        {
            var listaMensagens = new List<MensagemDTO>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "select * from Mensagem";

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
                return listaMensagens;
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

        public void InserirMensagemDB(MensagemDTO mensagem)
        {
            try
            {
                IDbCommand inserirCmd = conexao.CreateCommand();
                //inserirCmd.CommandText = "insert into Mensagem values('Bom dia! Tudo bem?',1,2)";
                //inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem) values(@Mensagem, @Grupo, @PaiMensagem)";
                inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem,ContSyncronia,PaiSyncronia) values(@Mensagem, @Grupo, @PaiMensagem, @ContSyncronia, @PaiSyncronia)";

                IDbDataParameter paraMensagem = new SqlParameter("Mensagem", mensagem.Mensagem);
                inserirCmd.Parameters.Add(paraMensagem);

                IDbDataParameter paraGrupo = new SqlParameter("Grupo", mensagem.Grupo);
                inserirCmd.Parameters.Add(paraGrupo);

                IDbDataParameter paraPaiMensagem = new SqlParameter("PaiMensagem", mensagem.PaiMensagem);
                inserirCmd.Parameters.Add(paraPaiMensagem);

                IDbDataParameter paraContSyncronia = new SqlParameter("ContSyncronia", mensagem.ContSyncronia);
                inserirCmd.Parameters.Add(paraContSyncronia);

                IDbDataParameter paraPaiSyncronia = new SqlParameter("PaiSyncronia", mensagem.PaiSyncronia);
                inserirCmd.Parameters.Add(paraPaiSyncronia);

                inserirCmd.ExecuteNonQuery();
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

        //public int PegarDadosUltimaSincronia(int paiSync, int grupo)
        //{
        //    try
        //    {
        //        IDbCommand selectCmd = conexao.CreateCommand();
        //        selectCmd.CommandText = "select PaiSyncronia,Max(ContSyncronia) as MaxSyncronia from Mensagem where Grupo = " + grupo + " group by PaiSyncronia";

        //        IDataReader resultado = selectCmd.ExecuteReader();
        //        while (resultado.Read())
        //        {
        //            var mensagen = new MensagemDTO()
        //            {
        //                Id = Convert.ToInt32(resultado["Id"]),
        //                Mensagem = Convert.ToString(resultado["Mensagem"]),
        //                Grupo = Convert.ToInt32(resultado["Grupo"]),
        //                PaiMensagem = Convert.ToInt32(resultado["PaiMensagem"]),
        //                ContSyncronia = Convert.ToInt32(resultado["ContSyncronia"]),
        //                PaiSyncronia = Convert.ToInt32(resultado["PaiSyncronia"])
        //            };
        //            listaMensagens.Add(mensagen);
        //        }
        //        return listaMensagens;

        //        if (maxSincronia.Equals(null))
        //        {
        //            return 1;
        //        }
        //        return maxSincronia;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        public void SincronizarMenagens(List<MensagemDTO> objMensagem)
        {
            try
            {
                foreach (MensagemDTO obj in objMensagem)
                {
                    IDbCommand inserirCmd = conexao.CreateCommand();
                    //inserirCmd.CommandText = "insert into Mensagem(Mensagem, Grupo, PaiMensagem, ContSyncronia, PaiSyncronia) values('teste', 1, 1, 3, 1)";
                    //inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem,ContSyncronia,PaiSyncronia) values(@Mensagem, @Grupo, @PaiMensagem, @ContSyncronia, @PaiSyncronia)";
                    inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem,ContSyncronia,PaiSyncronia) values(@Mensagem, @Grupo, @PaiMensagem, @ContSyncronia, @PaiSyncronia)";

                    IDbDataParameter paraMensagem = new SqlParameter("Mensagem", obj.Mensagem);
                    inserirCmd.Parameters.Add(paraMensagem);

                    IDbDataParameter paraGrupo = new SqlParameter("Grupo", obj.Grupo);
                    inserirCmd.Parameters.Add(paraGrupo);

                    IDbDataParameter paraPaiMensagem = new SqlParameter("PaiMensagem", obj.PaiMensagem);
                    inserirCmd.Parameters.Add(paraPaiMensagem);

                    IDbDataParameter paraContSyncronia = new SqlParameter("ContSyncronia", obj.ContSyncronia);
                    inserirCmd.Parameters.Add(paraContSyncronia);

                    IDbDataParameter paraPaiSyncronia = new SqlParameter("PaiSyncronia", obj.PaiSyncronia);
                    inserirCmd.Parameters.Add(paraPaiSyncronia);

                    inserirCmd.ExecuteNonQuery();
                }
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

        public List<MensagemDTO> PegarDadosParaEnviarSincronia(SincronizadorDTO objSinc)
        {
            try
            {
                List<MensagemDTO> listaDeMensagens = new List<MensagemDTO>();
                foreach (GrupoSincronizadoresPaiDTO obj in objSinc.ListaDeGruposSincroniaPay)
                {
                    foreach (PaiSincronia objPaisSinc in obj.SincroniasPai)
                    {
                        IDbCommand selectCmd = conexao.CreateCommand();
                        selectCmd.CommandText = "select * from Mensagem where Grupo = " + obj.IdGrupo + " and PaiSyncronia = " + objPaisSinc.Id + " and ContSyncronia > " + objPaisSinc.MaxSincronia;

                        IDataReader resultado = selectCmd.ExecuteReader();

                        while (resultado.Read())
                        {
                            var mensagem = new MensagemDTO()
                            {
                                Id = Convert.ToInt32(resultado["Id"]),
                                Mensagem = Convert.ToString(resultado["Mensagem"]),
                                Grupo = Convert.ToInt32(resultado["Grupo"]),
                                PaiMensagem = Convert.ToInt32(resultado["PaiMensagem"]),
                                ContSyncronia = Convert.ToInt32(resultado["ContSyncronia"]),
                                PaiSyncronia = Convert.ToInt32(resultado["PaiSyncronia"])
                            };
                            listaDeMensagens.Add(mensagem);
                        }
                        conexao.Close();
                        conexao.Open();
                    }
                }
                return listaDeMensagens;
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

        public List<GrupoSincronizadoresPaiDTO> PegarDadosParaSolicitarSincronia(SincronizadorDTO objSinc)
        {
            try
            {
                conexao.Open();
                List<GrupoSincronizadoresPaiDTO> ListaGrupoSincronizadores = new List<GrupoSincronizadoresPaiDTO>();
                foreach (GrupoSincronizadoresPaiDTO obj in objSinc.ListaDeGruposSincroniaPay)
                {
                    GrupoSincronizadoresPaiDTO grupoSincronizadoresPaiDTO = new GrupoSincronizadoresPaiDTO();
                    foreach (PaiSincronia objPaisSinc in obj.SincroniasPai)
                    {
                        
                        IDbCommand selectCmd = conexao.CreateCommand();
                        selectCmd.CommandText = "select PaiSyncronia, MAX(ContSyncronia) as MaxSincronia from Mensagem where Grupo = "+obj.IdGrupo
                            +" and ContSyncronia< "+objPaisSinc.MaxSincronia+ "  and((select Max(ContSyncronia) from Mensagem) < " + objPaisSinc.MaxSincronia 
                            + ") Group by PaiSyncronia";

                        List<PaiSincronia> listaPaiSincronias = new List<PaiSincronia>();
                        IDataReader resultado = selectCmd.ExecuteReader();
                        while (resultado.Read())
                        {
                            var paiSyncronia = new PaiSincronia()
                            {
                                Id = Convert.ToInt32(resultado["PaiSyncronia"]),
                                MaxSincronia = Convert.ToInt32(resultado["MaxSincronia"])
                            };
                            if (!paiSyncronia.Equals(null))
                            {
                                listaPaiSincronias.Add(paiSyncronia);
                            }
                        }
                        if (listaPaiSincronias.Any())
                        {
                            grupoSincronizadoresPaiDTO.IdGrupo = obj.IdGrupo;
                            grupoSincronizadoresPaiDTO.SincroniasPai = listaPaiSincronias;
                        }
                        
                        conexao.Close();
                        conexao.Open();
                    }
                    ListaGrupoSincronizadores.Add(grupoSincronizadoresPaiDTO);
                }
                return ListaGrupoSincronizadores;
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
