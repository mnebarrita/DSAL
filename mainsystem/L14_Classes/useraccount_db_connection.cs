using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    internal class useraccount_db_connection
    {
        public String useraccount_connectionString = null;
        public SqlConnection useraccount_sql_connection;
        public SqlCommand useraccount_sql_command;
        public DataSet useraccount_sql_dataset;
        public SqlDataAdapter useraccount_sql_dataadapter;
        public String useraccount_sql = null;

        public void useraccount_connString()
        {
            //codes to establish connection from C# Forms to the SQL Server database
            useraccount_sql_connection = new SqlConnection();
            useraccount_connectionString = "Data Source=MICACHU\\SQLEXPRESS; " +
                "Initial Catalog=SampleDatabaseDb; User ID=Micachu; Password=morats;";
        }
        public void useraccount_cmd()//public function codes that support the mssql query
        {
            useraccount_sql_command = new SqlCommand(useraccount_sql, useraccount_sql_connection);
            useraccount_sql_command.CommandType = CommandType.Text;
        }

        public void useraccount_sqldataadapterSelect()
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.SelectCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }
        public void useraccount_sqldataadapterInsert()
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.InsertCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }
        public void useraccount_sqldataadapterDelete()//public function codes for mediating
                                                      //between C# language and the MSSQL DELETE command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.DeleteCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }
        public void useraccount_sqldataadapterUpdate()//public function codes for mediating
                                                      //between C# language and the MSSQL UPDATE command
        {
            useraccount_sql_dataadapter = new SqlDataAdapter();
            useraccount_sql_dataadapter.UpdateCommand = useraccount_sql_command;
            useraccount_sql_command.ExecuteNonQuery();
        }
        public void useraccount_sqldatasetSELECT()//codes for mirroring the contents of
                                                  //the database inside MSSQL to C# or Visual Studio
        {
            useraccount_sql_dataset = new DataSet();
            useraccount_sql_dataadapter.Fill(useraccount_sql_dataset, "pos_empRegTbl");
        }
        public void useraccount_sqldatasetSELECT_Account()//codes for mirroring the
                                                          //contents of the database inside the MSSQL going to C# or Visual Studio
        {
            useraccount_sql_dataset = new DataSet();
            useraccount_sql_dataadapter.Fill(useraccount_sql_dataset, "useraccountTbl");
        }
    }

}
