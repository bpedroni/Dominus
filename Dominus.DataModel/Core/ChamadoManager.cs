﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class ChamadoManager
    {
        public const int CHAMADO_VALIDADO = 1;
        public const int CHAMADO_NAO_VALIDADO = 0;

        public static List<Chamado> GetChamados()
        {
            try
            {
                // Retorna uma lista de chamados cadastrados sistema:
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                List<Chamado> chamados = connection.context.Chamados.ToList();
                connection.CloseConnection();
                return chamados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Chamado> GetChamadosAbertos()
        {
            try
            {
                // Retorna uma lista de chamados que estão abertos no sistema:
                return GetChamados().Where(x => x.Validado == CHAMADO_NAO_VALIDADO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Chamado GetChamadoById(Guid idChamado)
        {
            try
            {
                // Verifica se existe um usuário com o id fornecido:
                Chamado chamado = GetChamados().FirstOrDefault(x => x.IdChamado == idChamado);
                return chamado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddChamado(Chamado chamado)
        {
            try
            {
                if (GetChamadoById(chamado.IdChamado) != null)
                {
                    throw new Exception("O sistema já possui um chamado com o id informado.");
                }
                // A aplicação gera um novo chamado com as definições padrões:
                chamado.IdChamado = Guid.NewGuid();
                chamado.DataCriacao = DateTime.Now;
                chamado.Validado = CHAMADO_NAO_VALIDADO;
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditChamado(Chamado chamado)
        {
            try
            {
                // A aplicação atualiza os dados do chamado fornecido:
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteChamado(Chamado chamado)
        {
            try
            {
                // A aplicação remove o chamado fornecido:
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Deleted;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
