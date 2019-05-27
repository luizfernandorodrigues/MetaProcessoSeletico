using System;
using System.Data;
using System.Data.SqlClient;

namespace AcessaDados
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool HasConnection { get; set; }
        public SqlTransaction Transaction { get; set; }
        public SqlConnection Connection { get; set; }

        public UnitOfWork(SqlConnection connection, bool hasConnection)
        {
            HasConnection = hasConnection;
            Connection = connection;
            Transaction = connection.BeginTransaction();
        }
        public SqlCommand CreateCommand()
        {
            var command = Connection.CreateCommand();
            command.Transaction = Transaction;
            return command;
        }

        public void SaveChanges()
        {
            if(Transaction == null)
            {
                throw new InvalidOperationException("Transação já comitada");
            }
            Transaction.Commit();
            Transaction = null;
        }
        public void Dispose()
        {
            if (Transaction !=null)
            {
                Transaction.Rollback();
                Transaction = null;
            }

            if (Connection !=null && HasConnection)
            {
                Connection.Close();
                Connection = null;
            }
        }
    }
}
