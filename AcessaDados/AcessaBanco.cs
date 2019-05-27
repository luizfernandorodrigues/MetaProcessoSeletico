using Modelo;
using Modelo.Enumerador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilitario;

namespace AcessaDados
{
    public class AcessaBanco
    {
        private readonly UnitOfWork uow;

        public AcessaBanco(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentException("Uow");
            }

            uow = unitOfWork as UnitOfWork;
            if (uow == null)
            {
                throw new NotSupportedException("UnitOfWork Factory está Nula");
            }
        }

        private readonly SqlParameterCollection sqlParametros = new SqlCommand().Parameters;

        public void LimpaParametros()
        {
            sqlParametros.Clear();
        }

        public void AdicionaParametro(string nomeParametro, object valorParametro)
        {
            try
            {
                sqlParametros.Add(new SqlParameter("@" + nomeParametro, valorParametro));
            }
            catch (ArgumentNullException ex)
            {
                string erro = string.Format("Ocorreu um Erro, Valor do Parâmetro Nulo {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
            catch (InvalidCastException ex)
            {
                string erro = string.Format("ocorreu um erro, na conversão do parametro! {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
            catch (Exception ex)
            {
                string erro = string.Format("ocorreu um erro! {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
        }

        public bool ExecutaManipulacao(string nomeProcedure)
        {
            try
            {
                using (var comando = uow.CreateCommand())
                {
                    comando.CommandText = nomeProcedure;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandTimeout = 7200;
                    foreach (SqlParameter sqlParameter in sqlParametros)
                    {
                        sqlParameter.DbType = System.Data.DbType.Object;
                        comando.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }
                    int retorno = comando.ExecuteNonQuery();
                    uow.SaveChanges();
                    return true ? retorno == 1 : false;
                }
            }
            catch (InvalidCastException ex)
            {
                string erro = string.Format("ocorreu um erro, na conversão do parametro! {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
            catch (ArgumentException ex)
            {
                string erro = string.Format("ocorreu um erro! {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
            catch (SqlException ex)
            {
                string erro = string.Format("ocorreu um erro na base de dados! {0}", ex.Message);
                LogErro.GravaLog(erro);
                throw ex;
            }
        }

        public IEnumerable<Solicitacao> GetTudo()
        {
            List<Solicitacao> lista = new List<Solicitacao>();

            try
            {
                using (var comando = uow.CreateCommand())
                {
                    comando.CommandText = "SELECT * FROM SOLICITACAO";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandTimeout = 7200;
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Solicitacao solicitacao = new Solicitacao();
                        solicitacao.Id = Convert.ToInt64(reader["Id"]);
                        solicitacao.Descricao = Convert.ToString(reader["Descricao"]);
                        solicitacao.DataConclusao = Convert.ToDateTime(reader["DataConclusao"]);
                        solicitacao.Responsavel = Convert.ToString(reader["Responsavel"]);
                        solicitacao.Status = (EStatusSolicitacao)Convert.ToInt16(reader["Status"]);
                        lista.Add(solicitacao);
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Solicitacao GetPorId()
        {
            Solicitacao retorno = new Solicitacao();

            try
            {
                using (var comando = uow.CreateCommand())
                {
                    comando.CommandText = "SELECT * FROM SOLICITACAO WHERE Id = @Id";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandTimeout = 7200;

                    foreach (SqlParameter sqlParameter in sqlParametros)
                    {
                        sqlParameter.DbType = System.Data.DbType.Object;
                        comando.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }


                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        retorno.Id = Convert.ToInt64(reader["Id"]);
                        retorno.Descricao = Convert.ToString(reader["Descricao"]);
                        retorno.DataConclusao = Convert.ToDateTime(reader["DataConclusao"]);
                        retorno.Responsavel = Convert.ToString(reader["Responsavel"]);
                        retorno.Status = (EStatusSolicitacao)Convert.ToInt16(reader["Status"]);
                    }
                }
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Excluir()
        {
             try
            {
                using (var comando = uow.CreateCommand())
                {
                    comando.CommandText = "DELETE FROM SOLICITACAO WHERE Id = @Id";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandTimeout = 7200;

                    foreach (SqlParameter sqlParameter in sqlParametros)
                    {
                        sqlParameter.DbType = System.Data.DbType.Object;
                        comando.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }
                    int retorno = comando.ExecuteNonQuery();
                    uow.SaveChanges();
                    return true ? retorno == 1 : false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
