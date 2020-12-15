
using App.Domain.Desctop;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository.Desctop
{
    public class UsuarioDAO
    {
        //teste de conexão
        //string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];

        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDB"].ConnectionString;

        private IDbConnection conexao;

        public UsuarioDAO()
        {
            //string stringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\aulasCSharp\Udemy\Aula02\WebApp\WebApp\App_Data\Database.mdf;Integrated Security=True";
            //string stringConexao = @"Data Source = (localdb)\MSSQLLocalDB; Database = DBWattsAppApi; User ID = sa; Password = senha; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
            //return;
            StringConexaoDB stringConexaoBd = new StringConexaoDB();
            
            //conexao = new SqlConnection(stringConexao);
            conexao = new SqlConnection(stringConexaoBd.PathConexaoDB());
            conexao.Open();
        }

        public List<UsuarioDTO> ListarUsuariosDb()
        {
            //return TesteListaUsuarios();
            var listaUsuarios = new List<UsuarioDTO>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "Select * from Usuarios";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var usuario = new UsuarioDTO()
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        Nome = Convert.ToString(resultado["Nome"]),
                        //Contatos = Convert.ToString(resultado["IdContatos"]),
                        Senha = Convert.ToString(resultado["Senha"]),
                    };
                    listaUsuarios.Add(usuario);
                }
                return listaUsuarios;
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

        public UsuarioDTO ListarUsuarioDb(int id)
        {
            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "select * from Usuarios where Id = " + id;

                IDataReader resultado = selectCmd.ExecuteReader();
                resultado.Read();

                var usuario = new UsuarioDTO()
                {
                    Id = Convert.ToInt32(resultado["Id"]),
                    Nome = Convert.ToString(resultado["Nome"]),
                    Senha = Convert.ToString(resultado["Senha"]),
                };
                return usuario;
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

        public void InserirUsuariosDb(UsuarioDTO usuario)
        {
            try
            {
                IDbCommand inserirCmd = conexao.CreateCommand();
                inserirCmd.CommandText = "insert into Usuarios(Nome, IdContatos, Senha) values(@Nome, 0, @Senha)";

                IDbDataParameter paraNome = new SqlParameter("Nome", usuario.Nome);
                inserirCmd.Parameters.Add(paraNome);

                IDbDataParameter paraSenha = new SqlParameter("Senha", usuario.Senha);
                inserirCmd.Parameters.Add(paraSenha);

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

        public void AtualizarUsuariosDb(UsuarioDTO usuario)
        {
            try
            {
                IDbCommand inserirCmd = conexao.CreateCommand();
                inserirCmd.CommandText = "update Usuarios set Nome = @Nome, Senha = @Senha where Id = @Id";

                IDbDataParameter paraId = new SqlParameter("Id", usuario.Id);
                inserirCmd.Parameters.Add(paraId);

                IDbDataParameter paraNome = new SqlParameter("Nome", usuario.Nome);
                inserirCmd.Parameters.Add(paraNome);

                IDbDataParameter paraSenha = new SqlParameter("Senha", usuario.Senha);
                inserirCmd.Parameters.Add(paraSenha);

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

        public void DeletarUsuarioDb(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "delete Usuarios where Id = " + id;
                deleteCmd.ExecuteNonQuery();
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

        public List<UsuarioDTO> TesteListaUsuarios()
        {
            var us1 = new UsuarioDTO()
            {
                Id = 1,
                Nome = "Maria",
                Senha = "1234",
                Contatos = null
            };
            var us2 = new UsuarioDTO()
            {
                Id = 2,
                Nome = "Carlos",
                Senha = "12345",
                Contatos = null
            };
            var us3 = new UsuarioDTO()
            {
                Id = 3,
                Nome = "Jéssica",
                Senha = "123456",
                Contatos = null
            };
            var listaUsuarios = new List<UsuarioDTO>();
            listaUsuarios.Add(us1);
            listaUsuarios.Add(us2);
            listaUsuarios.Add(us3);
            return listaUsuarios;
        }
    }
}