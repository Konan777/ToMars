using System.Data.SqlClient;
using System.Data.SQLite;

namespace ToMars.Model.Context
{
    public abstract class Database
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public abstract TMContext GetNewContext();
        public virtual bool ConnectionIsValid()
        {
            try {
                using (var context = GetNewContext())
                {
                    var cnn = context.Database.Connection;
                    cnn.Open();
                    cnn.Close();
                }
            }
            catch { return false; }
            return true;
        }
    }

    public class MSSQL_Database : Database
    {
        public override TMContext GetNewContext()
        {
            return new TMContext(new SqlConnection(ConnectionString), false);
        }
    }
    public class SQLite_Database : Database
    {
        public override TMContext GetNewContext()
        {
            return new TMContext(new SQLiteConnection(ConnectionString), true);
        }
    }

}


