using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AcessaDados;
using Modelo;
using Utilitario;

namespace Repositorio
{
    public class RepositorioSolicitacao : IRepositorioSolicitacao
    {
        private readonly UnitOfWork uow;
        public RepositorioSolicitacao(UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        public bool Alterar(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(long id)
        {
            try
            {
                AcessaBanco acessaBanco = new AcessaBanco(uow);
                Solicitacao sol = new Solicitacao();
                acessaBanco.LimpaParametros();
                acessaBanco.AdicionaParametro("Id", id);
                return acessaBanco.Excluir();
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(ex.ToString());
                return false;
            }
        }

        public bool Inserir(Solicitacao solicitacao)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(Int64));
                dataTable.Columns.Add("Descricao", typeof(string));
                dataTable.Columns.Add("DataConclusao", typeof(DateTime));
                dataTable.Columns.Add("Responsavel", typeof(string));
                dataTable.Columns.Add("Status", typeof(int));

                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = solicitacao.Id;
                dataRow["Descricao"] = solicitacao.Descricao;
                dataRow["DataConclusao"] = solicitacao.DataConclusao;
                dataRow["Responsavel"] = solicitacao.Responsavel;
                dataRow["Status"] = solicitacao.Status;

                dataTable.Rows.Add(dataRow);
                AcessaBanco acessaBanco = new AcessaBanco(uow);
                acessaBanco.LimpaParametros();
                acessaBanco.AdicionaParametro("Valores", dataTable);
                return acessaBanco.ExecutaManipulacao("SP_INSERIR_ATUALIZAR_SOLICITACAO");
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(ex.ToString());
                throw ex;
            }
        }

        public Solicitacao ObterPorId(long id)
        {
            try
            {
                AcessaBanco acessaBanco = new AcessaBanco(uow);
                Solicitacao sol = new Solicitacao();
                acessaBanco.LimpaParametros();
                acessaBanco.AdicionaParametro("Id", id);
                sol = acessaBanco.GetPorId();
                return sol;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(ex.ToString());
                return null;
            }
        }

        public IEnumerable<Solicitacao> ObterTodos()
        {
            try
            {
                AcessaBanco acessaBanco = new AcessaBanco(uow);
                IEnumerable<Solicitacao> lst = null;
                lst = acessaBanco.GetTudo();
                return lst;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(ex.ToString());
                return null;
            }
        }


    }
}
