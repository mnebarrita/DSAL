using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem.L14_Classes
{
    public class employee_dbconnection
    {
        // declaration of variables for database connections and queries to access from one form to another
        public String employee_connectionString = null;
        public SqlConnection employee_sql_connection;
        public SqlCommand employee_sql_command;
        public DataSet employee_sql_dataset;
        public SqlDataAdapter employee_sql_dataadapter;
        public string employee_sql = null;

        public void employee_connString()
        {
            // connection of c# to sql
            employee_sql_connection = new SqlConnection();
            employee_connectionString = "Data Source=MICACHU\\SQLEXPRESS; Initial Catalog=POSDB; User ID=Micachu; Password=morats;";
            employee_sql_connection = new SqlConnection(employee_connectionString);
            employee_sql_connection.ConnectionString = employee_connectionString;
            employee_sql_connection.Open();
        }

        // punlic func that supports MS SQL query
        public void employee_cmd()
        {
            employee_sql_command = new SqlCommand(employee_sql, employee_sql_connection);
            employee_sql_command.CommandType = CommandType.Text;
        }

        public void employee_sqladapterSelect()
        {
            employee_sql_dataadapter = new SqlDataAdapter();
            employee_sql_dataadapter.SelectCommand = employee_sql_command;
            employee_sql_command.ExecuteNonQuery();
        }

        public void employee_sqladapterInsert()
        {
            employee_sql_dataadapter = new SqlDataAdapter();
            employee_sql_dataadapter.InsertCommand = employee_sql_command;
            employee_sql_command.ExecuteNonQuery();
        }

        public void employee_sqladapterDelete()
        {
            employee_sql_dataadapter = new SqlDataAdapter();
            employee_sql_dataadapter.DeleteCommand = employee_sql_command;
            employee_sql_command.ExecuteNonQuery();
        }

        public void employee_sqladapterUpdate()
        {
            employee_sql_dataadapter = new SqlDataAdapter();
            employee_sql_dataadapter.UpdateCommand = employee_sql_command;
            employee_sql_command.ExecuteNonQuery();
        }

        public void employee_sqldatasetSELECT()
        {
            employee_sql_dataset = new DataSet();
            employee_sql_dataadapter.Fill(employee_sql_dataset, "pos_empRegTb1");
        }
    }
}
