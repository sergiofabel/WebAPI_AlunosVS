using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebAPI_AlunosVS.Library.Entities;
using WebAPI_AlunosVS.Library.Repositories.Interfaces;
using WebAPI_AlunosVS.Library.Extensions;

namespace WebAPI_AlunosVS.Library.Repositories
{
    public class AlunoRepository:IAlunoRepository
    {
        private readonly IConfiguration _Configuration;
        private readonly Connection _Connection;

        public AlunoRepository(Connection Connection,IConfiguration Configuration)
        {
            _Connection = Connection;
            _Configuration = Configuration;
        }

        /// <summary>
        /// Metodo que insert um Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int InsertAluno(Aluno aluno)
        {
            int count = 0;
       
            using (var connection = new SqlConnection(_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    var query = "INSERT INTO dbo.Aluno (Nome,Email) VALUES(@Nome,@Email)";
                    count = connection.Execute(query, aluno);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return count;
            }
        }
        
        public List<Aluno> GetAlunos()
        {      
            List<Aluno> alunos = null;

            using (var connection = new SqlConnection(_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT AlunoId,Nome,Email FROM dbo.Aluno";
                    alunos = connection.Query<Aluno>(query).ToList();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
               return alunos;
        }

        public Aluno GetByIdAluno(int id)
        {
            Aluno aluno = null;

            using (var connection = new SqlConnection(_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT AlunoId,Nome,Email FROM dbo.Aluno WHERE AlunoId=" + id;
                    aluno = connection.Query<Aluno>(query).FirstOrDefault();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return aluno;
        }
        
        public int UpdateAluno(Aluno aluno)
        {
            var count = 0;

            using (var connection = new SqlConnection(_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();

                    var query = "UPDATE dbo.Aluno SET Nome=@Nome,Email=@Email WHERE AlunoId=" + aluno.AlunoId;
                    count   = connection.Execute(query, aluno);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return count;
        }
        
        public int DeleteAluno(int id)
        {
            var count = 0;

            using (var connection = new SqlConnection(_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();

                    var query = "DELETE FROM dbo.Aluno WHERE AlunoId=" + id;
                    count = connection.Execute(query);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return count;
        }
    }
}