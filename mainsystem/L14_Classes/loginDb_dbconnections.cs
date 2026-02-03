using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    internal class loginDb_dbconnections
    {
        // Declaration of variables for database connections and query which to access from one form to another
        public string login_connectionString = null;
        public SqlConnection login_sql_connection;
        public SqlCommand login_sql_command;
        public DataSet login_sql_dataset;
        public SqlDataAdapter login_sql_dataadapter;
        public string login_sql = null;

        public void login_connString()
        {
            // Codes to establish a connection from C# forms to the SQL Server database
            login_sql_connection = new SqlConnection();
            login_connectionString = "Server=10.118.141.165,1433;Database=POS_Database;User Id=sa;Password=rylle;TrustServerCertificate=True;"; ;
            login_sql_connection = new SqlConnection(login_connectionString);
            login_sql_connection.ConnectionString = login_connectionString;
            login_sql_connection.Open();
        }

        public void login_cmd()
        {
            // Public function codes that support the write code
            login_sql_command = new SqlCommand(login_sql, login_sql_connection);
            login_sql_command.CommandType = CommandType.Text;
        }

        public void login_sqladapterSelect()
        {
            // Public function codes for mediating between C# language and the MSSQL SELECT command
            login_sql_dataadapter = new SqlDataAdapter();
            login_sql_dataadapter.SelectCommand = login_sql_command;
            login_sql_command.ExecuteNonQuery();
        }

        public void login_sqladapterInsert()
        {
            // Public function codes for mediating between C# language and the MSSQL INSERT command
            login_sql_dataadapter = new SqlDataAdapter();
            login_sql_dataadapter.InsertCommand = login_sql_command;
            login_sql_command.ExecuteNonQuery();
        }

        public void login_sqladapterDelete()
        {
            // Public function codes for mediating between C# language and the MSSQL DELETE command
            login_sql_dataadapter = new SqlDataAdapter();
            login_sql_dataadapter.DeleteCommand = login_sql_command;
            login_sql_command.ExecuteNonQuery();
        }

        public void login_sqladapterUpdate()
        {
            // Public function codes for mediating between C# language and the MSSQL UPDATE command
            login_sql_dataadapter = new SqlDataAdapter();
            login_sql_dataadapter.UpdateCommand = login_sql_command;
            login_sql_command.ExecuteNonQuery();
        }

        public void login_sqldatasetSELECT()
        {
            // Codes for mirroring the contents of the database inside MSSQL going to C# or Visual Studio
            login_sql_dataset = new DataSet();
            login_sql_dataadapter.Fill(login_sql_dataset, "pos_empRegTb1");
        }

    }
}
