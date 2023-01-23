using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using PayrollAPI.Models;

namespace PayrollAPI.DBInterface;

public class DbConnection
{
    //private DbConn SqlConnString;
    //SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);

    SqlConnection MyConnection;
    DataTable dataTable;
    DataSet dataSet;
    //This is my main connection to the DB
    public SqlConnection MySqlConnection()
    {

        SqlConnection MySqlConnection = new SqlConnection();
        try
        {
            if (MySqlConnection.State == ConnectionState.Closed || MySqlConnection.State == ConnectionState.Broken)
            {
                MySqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString); ;
                MySqlConnection.Open();
            }
            
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            //' DoLogs("Error on MySqlConnection Function. " & Now().ToString & " " & Session("Currentusername").trim & "- " & Session("compname") & "=" & ex.Message)
        }
        return MySqlConnection;
    }

    public object ExecuteQuery(int Action, string SqlStr, string srcTable = "", SqlCommand CmdObject = null)
    {
        try
        {
            MyConnection = MySqlConnection();
            if (MyConnection == null)
            {
                return null;
            }

            if (MyConnection.State == ConnectionState.Closed || MyConnection.State == ConnectionState.Broken)
            {
                return null;
            }

            dataTable = new DataTable();
            dataSet = new DataSet();
            SqlCommand myCommand = null;
            SqlDataAdapter myAdapter = null;

            switch (Action)
            {
                case 1:
                    myAdapter = new SqlDataAdapter(SqlStr, MyConnection);
                    myAdapter.Fill(dataTable);
                    MyConnection.Close();
                    return dataTable;

                case 2:
                    myCommand = new SqlCommand(SqlStr, MyConnection);
                    myCommand.ExecuteNonQuery();
                    MyConnection.Close();

                    dataTable.Clear();
                    dataTable.Columns.Add("Successful", typeof(string));
                    return dataTable;

                case 3:
                    myCommand = new SqlCommand(SqlStr, MyConnection);
                    object ScalarItem = myCommand.ExecuteScalar();
                    MyConnection.Close();
                    return ScalarItem;

                case 4:
                    myCommand = MyConnection.CreateCommand();
                    myCommand.CommandText = SqlStr;
                    return myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                case 5:
                    myAdapter = new SqlDataAdapter(SqlStr, MyConnection);
                    System.Data.DataSet myDataSet = new System.Data.DataSet();
                    myAdapter.Fill(myDataSet);
                    MyConnection.Close();
                    return myDataSet;

                case 6:
                    if (CmdObject != null)
                    {
                        CmdObject.Connection = MyConnection;
                        CmdObject.CommandTimeout = 10000;
                        CmdObject.ExecuteNonQuery();
                        MyConnection.Close();

                        dataTable.Clear();
                        dataTable.Columns.Add("Successful", typeof(string));
                    }

                    return dataTable;

                case 7:
                    CmdObject.Connection = MyConnection;
                    CmdObject.CommandTimeout = 10000;
                    myAdapter = new SqlDataAdapter(CmdObject);
                    myAdapter.Fill(dataTable);
                    MyConnection.Close();
                    return dataTable;

                case 8:
                    myAdapter = new SqlDataAdapter(SqlStr, MyConnection);
                    return myAdapter;

                case 9:
                    CmdObject.Connection = MyConnection;
                    CmdObject.CommandTimeout = 10000;
                    myAdapter = new SqlDataAdapter(CmdObject);
                    myAdapter.Fill(dataSet);
                    MyConnection.Close();
                    return dataSet;
            }
        }
        catch (Exception ex)
        {
            //LogError("Error ", ex.Message.ToString().Trim());
            dataTable.Clear();
            dataTable.Columns.Add("ErrorMessage", typeof(string));
            return dataTable;
        }

        return dataTable;
    }
}