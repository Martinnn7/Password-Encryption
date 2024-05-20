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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataAccess myData = new DataAccess();
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DateTime Bday;
            bool isValidDate = DateTime.TryParse(txtBday.Text, out Bday);

            int age = CalculateAge(Bday);

            if (age < 18)
            {
                lblInvalid.Text = "* You must be at least 18 years old to continue.";
                return;
            }

            if (Page.IsValid)
            {
                if (myData.CheckEmail(txtEmail.Text))
                {
                    lblRegistered.Text = "* Email Already Registered";
                    return;
                }
                else
                {
                    myData.CreateAccount(txtEmail.Text, txtLname.Text, txtFname.Text, txtMiddle.Text, txtPhone.Text, txtAddress.Text, txtBday.Text, txtPass.Text, txtGender.Text);

                    DataTable dt = myData.GetUserByEmail(txtEmail.Text);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Session["lName"] = dr["LastName"].ToString();
                        Session["fName"] = dr["FirstName"].ToString();
                        Session["Initial"] = dr["LastName"].ToString();
                        Session["HomeAddress"] = dr["HomeAddress"].ToString();
                        Session["Password"] = dr["Password"].ToString();
                        Session["Phone"] = dr["PhoneNumber"].ToString();
                    }
                }
                lblSuccess.Text = "* Registered Successfully.";
                lblEncrypted.Text = myData.EncryptedUserPassword;
            }
        }
        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;

            if (dob > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}

