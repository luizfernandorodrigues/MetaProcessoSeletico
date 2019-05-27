using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace AcessaDados
{
   public interface IUnitOfWork : IDisposable
    {
        bool HasConnection { get; set; }
        SqlTransaction Transaction { get; set; }
        SqlConnection Connection { get; set; }
        SqlCommand CreateCommand();
        void SaveChanges();
        void Dispose();
    }
}
