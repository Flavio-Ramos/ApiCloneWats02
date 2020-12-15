
using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace ApiCloneWats02.Models
{
    public class UsuarioModel
    {
        public List<UsuarioDTO> ListarUsuarios()
        {
            try
            {
                UsuarioDAO daoUsuario = new UsuarioDAO();
                return daoUsuario.ListarUsuariosDb();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar Usuarios: {e.Message}");
            }
            
        }

        public UsuarioDTO ListarUsuario(int id)
        {
            try
            {
                UsuarioDAO daoUsuario = new UsuarioDAO();
                return daoUsuario.ListarUsuarioDb(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar Usuario: {e.Message}");
            }

        }

        public void InserirUsuarios(UsuarioDTO usuario)
        {
            try
            {
                UsuarioDAO daoUsuario = new UsuarioDAO();
                daoUsuario.InserirUsuariosDb(usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir Usuario: {e.Message}");
            }
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            try
            {
                UsuarioDAO daoUsuario = new UsuarioDAO();
                daoUsuario.AtualizarUsuariosDb(usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao deletar Usuario: {e.Message}");
            }

        }

        public void DeletarUsuario(int id)
        {
            try
            {
                UsuarioDAO daoUsuario = new UsuarioDAO();
                daoUsuario.DeletarUsuarioDb(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao deletar Usuario: {e.Message}");
            }

        }
    }
}