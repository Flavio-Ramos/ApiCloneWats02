using App.Domain.Desctop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository.Desctop
{
    public class MensagemDAO
    {
        ~MensagemDAO() { }
        //string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
        //private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public MensagemDAO()
        {
            StringConexaoDB stringConexaoDB = new StringConexaoDB();
            //conexao = new SqlConnection(stringConexao);
            conexao = new SqlConnection(stringConexaoDB.PathConexaoDB());
        }
    
        public List<MensagemDTO> ListarMensagensDB(int qtdRegistros)
        {
            var listaMensagens = new List<MensagemDTO>();

            try
            {
                conexao.Open();
                IDbCommand selectCmd = conexao.CreateCommand();
                //selectCmd.CommandText = "select * from Mensagem";
                //selectCmd.CommandText = "select top("+qtdRegistros+")*from Mensagem order by Id desc";
                selectCmd.CommandText = "select top("+qtdRegistros+")*from Mensagem order by Id desc";

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

        public List<MensagemDTO> PegarDadosParaEnviarSincronia(SincronizadorDTO objSinc)
        {
            try
            {
                conexao.Open();
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

        //public void InserirMensagemDB(MensagemDTO mensagem)
        //{
        //    try
        //    {
        //        IDbCommand inserirCmd = conexao.CreateCommand();
        //        //inserirCmd.CommandText = "insert into Mensagem values('Bom dia! Tudo bem?',1,2)";
        //        inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem) values(@Mensagem, @Grupo, @PaiMensagem)";

        //        IDbDataParameter paraMensagem = new SqlParameter("Mensagem", mensagem.Mensagem);
        //        inserirCmd.Parameters.Add(paraMensagem);

        //        IDbDataParameter paraGrupo = new SqlParameter("Grupo", mensagem.Grupo);
        //        inserirCmd.Parameters.Add(paraGrupo);

        //        IDbDataParameter paraPaiMensagem = new SqlParameter("PaiMensagem", mensagem.PaiMensagem);
        //        inserirCmd.Parameters.Add(paraPaiMensagem);

        //        inserirCmd.ExecuteNonQuery();
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

        public void InserirMensagemDB(MensagemDTO mensagem)
        {
            try
            {
                conexao.Open();
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
        public void SalvarMensagem(MensagemDTO mensagem)
        {
            try
            {
                conexao.Open();
                IDbCommand inserirCmd = conexao.CreateCommand();
                //inserirCmd.CommandText = "insert into Mensagem(Mensagem, Grupo, PaiMensagem, ContSyncronia, PaiSyncronia) values('teste', 1, 1, 3, 1)";
                //inserirCmd.CommandText = "insert into Mensagem (Mensagem, Grupo, PaiMensagem,ContSyncronia,PaiSyncronia) values(@Mensagem, @Grupo, @PaiMensagem, @ContSyncronia, @PaiSyncronia)";
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

        public void SincronizarMenagens(List<MensagemDTO> objMensagem)
        {
            try
            {
                conexao.Open();
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

        public int PegarDadosUltimaSincronia()
        {
            try
            {
                conexao.Open();
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "select MAX(ContSyncronia) as ContSyncronia from Mensagem";

                IDataReader resultado = selectCmd.ExecuteReader();

                resultado.Read();

                if (resultado["ContSyncronia"].ToString() == "")
                {
                    return 0;
                }
                int maxSincronia = Convert.ToInt32(resultado["ContSyncronia"]);
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

        public SincronizadorDTO PegarDadosParaSolicitarSincronia()
        {
            try
            {
                conexao.Open();
                IDbCommand selectGroupCmd = conexao.CreateCommand();
                selectGroupCmd.CommandText = "select Grupo from Mensagem group by Grupo";
                List<GrupoSincronizadoresPaiDTO> ListaGrupoSincronizadores = new List<GrupoSincronizadoresPaiDTO>();
                IDataReader resultadoGroup = selectGroupCmd.ExecuteReader();
                while (resultadoGroup.Read())
                {
                    var grupoSincronizadoresPaiDTO = new GrupoSincronizadoresPaiDTO()
                    {
                        IdGrupo = Convert.ToInt32(resultadoGroup["Grupo"])
                    };
                    if (!grupoSincronizadoresPaiDTO.Equals(null))
                    {
                        ListaGrupoSincronizadores.Add(grupoSincronizadoresPaiDTO);
                    }
                }

                conexao.Close();
                conexao.Open();
                SincronizadorDTO sincronizador = new SincronizadorDTO();
                foreach (GrupoSincronizadoresPaiDTO obj in ListaGrupoSincronizadores)
                {
                    IDbCommand selectCmd = conexao.CreateCommand();
                    selectCmd.CommandText = "select PaiSyncronia,MAX(ContSyncronia) as MaxContSyncronia from Mensagem where Grupo = " + obj.IdGrupo + " group by PaiSyncronia";

                    List<PaiSincronia> listaPaiSincronias = new List<PaiSincronia>();
                    IDataReader resultado = selectCmd.ExecuteReader();
                    while (resultado.Read())
                    {
                        var paiSyncronia = new PaiSincronia()
                        {
                            Id = Convert.ToInt32(resultado["PaiSyncronia"]),
                            MaxSincronia = Convert.ToInt32(resultado["MaxContSyncronia"])
                        };
                        if (!paiSyncronia.Equals(null))
                        {
                            listaPaiSincronias.Add(paiSyncronia);
                        }
                    }

                    obj.SincroniasPai = listaPaiSincronias;
                    sincronizador.ListaDeGruposSincroniaPay.Add(obj);
                    conexao.Close();

                }//fim foreach

                return sincronizador;
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

        //public List<MensagemDTO> PegarDadosParaSincronia(SincronizadorDTO objSinc)
        //{
        //    try
        //    {
        //        List<MensagemDTO> listaDeMensagens = new List<MensagemDTO>();
        //        foreach(SincronizadorPaiDTO obj in objSinc.ListaSincroniaPay)
        //        {
        //            foreach (int objGrupo in obj.Grupo) 
        //            {
        //                IDbCommand selectCmd = conexao.CreateCommand();
        //                selectCmd.CommandText = "select * from Mensagem  where  ContSyncronia > "+obj.MaxSincronia+" and Grupo = "+objGrupo+" and PaiSyncronia = "+obj.Id;

        //                IDataReader resultado = selectCmd.ExecuteReader();
        //                while (resultado.Read())
        //                {
        //                    var mensagem = new MensagemDTO()
        //                    {
        //                        Id = Convert.ToInt32(resultado["Id"]),
        //                        Mensagem = Convert.ToString(resultado["Mensagem"]),
        //                        Grupo = Convert.ToInt32(resultado["Grupo"]),
        //                        PaiMensagem = Convert.ToInt32(resultado["PaiMensagem"]),
        //                        ContSyncronia = Convert.ToInt32(resultado["ContSyncronia"]),
        //                        PaiSyncronia = Convert.ToInt32(resultado["PaiSyncronia"])
        //                    };
        //                    listaDeMensagens.Add(mensagem);
        //                }
        //            }
        //        }
        //        return listaDeMensagens;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
    }//}
}
