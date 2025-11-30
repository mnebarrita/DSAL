using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    internal class posdb_connect
    {
        // Declaration of variables for database connections and query which to access from one form to another
        public string pos_connectionString = null;
        public SqlConnection pos_sql_connection;
        public SqlCommand pos_sql_command;
        public DataSet pos_sql_dataset;
        public SqlDataAdapter pos_sql_dataadapter;
        public string pos_sql = null;

        public void pos_connString()
        {
            pos_connectionString = "Data Source=MICACHU\\SQLEXPRESS; Initial Catalog=POSDB; User ID=Micachu; Password=morats;";
            pos_sql_connection = new SqlConnection(pos_connectionString);
        }

        public void posdb_open()
        {
            if (pos_sql_connection.State == ConnectionState.Closed)
            {
                pos_sql_connection.Open();
            }
        }

        public void posdb_close()
        {
            if (pos_sql_connection.State == ConnectionState.Open)
            {
                pos_sql_connection.Close();
            }
        }


        public void pos_cmd()
        {
            // Public function codes that support the write code
            pos_sql_command = new SqlCommand(pos_sql, pos_sql_connection);
            pos_sql_command.CommandType = CommandType.Text;
        }

        public void pos_sqladapterSelect()
        {
            // Public function codes for mediating between C# language and the MSSQL SELECT command
            pos_sql_dataadapter = new SqlDataAdapter();
            pos_sql_dataadapter.SelectCommand = pos_sql_command;
            pos_sql_command.ExecuteNonQuery();
        }


        public void pos_sqladapterInsert()
        {
            // Public function codes for mediating between C# language and the MSSQL INSERT command
            pos_sql_dataadapter = new SqlDataAdapter();
            pos_sql_dataadapter.InsertCommand = pos_sql_command;
            pos_sql_command.ExecuteNonQuery();
        }

        public void pos_sqladapterDelete()
        {
            // Public function codes for mediating between C# language and the MSSQL DELETE command
            pos_sql_dataadapter = new SqlDataAdapter();
            pos_sql_dataadapter.DeleteCommand = pos_sql_command;
            pos_sql_command.ExecuteNonQuery();
        }

        public void pos_sqladapterUpdate()
        {
            // Public function codes for mediating between C# language and the MSSQL UPDATE command
            pos_sql_dataadapter = new SqlDataAdapter();
            pos_sql_dataadapter.UpdateCommand = pos_sql_command;
            pos_sql_command.ExecuteNonQuery();
        }

        public void pos_sqldatasetSELECT()
        {
            // Codes for mirroring the contents of the database inside MSSQL going to C# or Visual Studio
            pos_sql_dataset = new DataSet();
            pos_sql_dataadapter.Fill(pos_sql_dataset, "pos_nameTb1");
        }
        public void pos_sqldatasetSELECTSALES()
        {  
            pos_sql_dataset = new DataSet();
            pos_sql_dataadapter.Fill(pos_sql_dataset, "pos_salesTb1");
        }
        public void pos_select()
        {
            pos_sql = "SELECT * FROM pos_nameTb1 INNER JOIN pos_picTb1 ON " +
                "pos_nameTb1.pos_id = pos_picTb1.pos_id INNER JOIN pos_priceTb1 ON " +
                "pos_picTb1.pos_id = pos_priceTb1.pos_id";
        }
        public void pos_select_cashier()
        {
            pos_sql = "SELECT * FROM pos_nameTb1 INNER JOIN pos_picTb1 ON" +
                "pos_nameTb1.pos_id = pos_picTb1.pos_id INNER JOIN pos_priceTb1 ON" +
                "pos_picTb1.pos_id = pos_priceTb1.pos_id WHERE pos_nameTb1.pos_id = 1";
        }
        public void pos_select_cashier1()
        {
            pos_sql = "SELECT * FROM pos_nameTb1 INNER JOIN pos_picTb1 ON" +
                "pos_nameTb1.pos_id = pos_picTb1.pos_id INNER JOIN pos_priceTb1 ON" +
                "pos_picTb1.pos_id = pos_priceTb1.pos_id WHERE pos_nameTb1.pos_id = 2";
        }
        public void pos_select_cashier_display()
        {
            pos_sql = "SELECT pos_empRegTb1.emp_id, emp_fname, emp_surname," +
                "pos_terminal_no, account_type FROM pos_empRegTb1 INNER JOIN useraccountTb1" +
                "ON pos_empRegTb1.emp_id = useraccountTb1.emp_id WHERE account_type = " +
                "'Administrator'";
        }
        public void pos_select_cashier_SELECTdisplay()
        {
            pos_sql_dataset = new DataSet();
            pos_sql_dataadapter.Fill(pos_sql_dataset, "pos_empRegTb1");
        }
    }
}
