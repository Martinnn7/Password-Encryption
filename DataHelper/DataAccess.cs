using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class DataAccess
    {
        static string ConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Visual Studio Programs\Tabirao_LongQuiz\Tabirao_LongQuiz\App_Data\MasterFIle.mdf"";Integrated Security=True";
        SqlConnection myConn = new SqlConnection(ConnStr);

        public string EncryptData(string userPassWord)
        {
            MD5CryptoServiceProvider mdHash = new MD5CryptoServiceProvider();
            byte[] totalBytes = Encoding.ASCII.GetBytes(userPassWord);
            byte[] hashBytes = mdHash.ComputeHash(totalBytes);

            //String Builder
            StringBuilder sb = new StringBuilder();
            for (int generateChar = 0; generateChar < hashBytes.Length; generateChar++)
            {
                sb.AppendFormat("{0:x2}", hashBytes[generateChar]);

            }
            return sb.ToString();
        }
        string encryptedUserPassword;

        public string EncryptedUserPassword
        {
            get { return encryptedUserPassword; }
            set { encryptedUserPassword = value; }
        }

        public void CreateAccount(string email, string lName, string fName, string middleInitial, string phoneNumber, string address, string birthday, string password, string gender)
        {
            myConn.Open();
            encryptedUserPassword = EncryptData(password);
            SqlCommand saveCmd = new SqlCommand("CreateAccount", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            saveCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lName;
            saveCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = fName;
            saveCmd.Parameters.Add("@MiddleInitial", SqlDbType.NVarChar).Value = middleInitial;
            saveCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = phoneNumber;
            saveCmd.Parameters.Add("@HomeAddress", SqlDbType.NVarChar).Value = address;
            saveCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = birthday;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = encryptedUserPassword;
            saveCmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public bool CheckEmail(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public DataTable GetUserByEmail(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetUserAccount(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable GetUserByAccountID(string AccountID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetUserByAccountID", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void UpdateAddress(string AccountID, string address)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("UpdateAddress", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            saveCmd.Parameters.Add("@HomeAddress", SqlDbType.NVarChar).Value = address;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void UpdateNumber(string AccountID, string phoneNumber)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("UpdateNumber", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            saveCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = phoneNumber;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void UpdatePassword(string AccountID, string password)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("UpdatePassword", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public DataTable GetUsers()
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccounts", myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
