using System.Data;
using Microsoft.Data.SqlClient;
using PayrollAPI.Models;

namespace PayrollAPI.DBInterface;

public class DBInterface
{

    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);

    private SqlCommand HRCrud_Ops(int mode,EmployeeDetail employeeDetail)
    {
        try
        {
            connection.Open();
            var MyCmd = new SqlCommand()
            {
                CommandText = "[dbo].[Asp_HR]",
                CommandTimeout = 120,
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            MyCmd.Parameters.Add("@mode", SqlDbType.Int).Value = mode;
            MyCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = employeeDetail.FirstName;
            MyCmd.Parameters.Add("@Citizenship", SqlDbType.VarChar).Value = employeeDetail.Citizenship;
            MyCmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = employeeDetail.Citizenship;
            MyCmd.Parameters.Add("@EmployeeEducations", SqlDbType.VarChar).Value = employeeDetail.EmployeeEducations;
            MyCmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = employeeDetail.EmployeeId;
            MyCmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = employeeDetail.EmployeeNo;
            MyCmd.Parameters.Add("@EmployerCode", SqlDbType.VarChar).Value = employeeDetail.EmployerCode;
            MyCmd.Parameters.Add("@EmployerPin", SqlDbType.VarChar).Value = employeeDetail.EmployerPin;
            MyCmd.Parameters.Add("@GrossPay", SqlDbType.VarChar).Value = employeeDetail.GrossPay;
            MyCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = employeeDetail.LastName;
            MyCmd.Parameters.Add("@KRANo", SqlDbType.VarChar).Value = employeeDetail.KRANo;
            MyCmd.Parameters.Add("@Mnth", SqlDbType.VarChar).Value = employeeDetail.;
            MyCmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = EmployeeNo;
            MyCmd.Parameters.Add("@Results", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;


            return MyCmd;
        }
        catch (Exception ex)
        {
            //ApiInterfaceCs.DoLogs(ApiInterfaceCs.PrepareErrorMessage(Page, "cboLanguagePref_SelectedIndexChanged", ex));
            //showErrorMessage("Error occured in ASP_StaffPayrollRpt.");
            return null;
        }
    }
}