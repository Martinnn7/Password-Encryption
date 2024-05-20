using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DataHelper;

namespace Tabirao_LongQuiz.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataAccess myData = new DataAccess();
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool EmailExist = true;
            bool PasswordExist = true;

            DataTable dt = myData.GetUserAccount(txtEmail.Text);

            if (dt == null)
            {
                lblInvalidEmail.Text = "* Email not found";
                EmailExist = false;
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr["Password"].Equals(myData.EncryptData(txtPassword.Text)))
                {
                    lblInvalidPassword.Text = "* Invalid Password";
                    PasswordExist = false;
                    return;
                }
            }

            if (EmailExist && PasswordExist)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Session["AccountID"] = dr["AccountID"].ToString();
                    Session["lName"] = dr["LastName"].ToString();
                    Session["fName"] = dr["FirstName"].ToString();
                    Session["Initial"] = dr["LastName"].ToString();
                    Session["HomeAddress"] = dr["HomeAddress"].ToString();
                    Session["Password"] = dr["Password"].ToString();
                    Session["Phone"] = dr["PhoneNumber"].ToString();
                }
                Response.Redirect("/User/UserProfile.aspx");
            }
            
        }
    }
}