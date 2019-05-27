using System.Data.SqlClient;

namespace AcessaDados
{
    public class UnitOfWorkFactory 
    {
        public static UnitOfWork Create(string stringConnection)
        {
            var connection = new SqlConnection(stringConnection);
            connection.Open();
            return new UnitOfWork(connection, true);
        }
    }
}
