using System.Data;
using System.Data.SqlClient;

namespace LibararyApps.Models
{
    public class DatabaseInfo
    {
        //Server=myServerAddress;Database=myDataBase;User Id = myUsername; Password=myPassword;
        public string SERVERADRESS { get; set; }
        public string DATABASE { get; set; }
        public string? USERNAME { get; set; }
        public string? PASSWORD { get; set; }
        public bool TRUNCATE { get; set; }

        public DatabaseInfo()
        {
            
        }

        public IDbConnection Connection()
        {
            string sqlString = $"Server=myServerAddress;Database=myDataBase;User Id = myUsername; Password=myPassword";
            IDbConnection dbConnection = new SqlConnection("Server=celilcavus\\SQLEXPRESS;Database=BOOKS;Trusted_Connection=True;");
            dbConnection.Open();

            return dbConnection;


        }
    }
}
