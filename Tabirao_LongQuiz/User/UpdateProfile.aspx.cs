using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;
namespace Tabirao_LongQuiz.User
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = myData.GetUserByAccountID(Session["AccountID"].ToString());
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            myData.UpdateAddress(Session["AccountID"].ToString(), txtAddress.Text);
            lblAddress.Text = "* Updated successfully.";
        }

        protected void btnNumber_Click(object sender, EventArgs e)
        {
            myData.UpdateNumber(Session["AccountID"].ToString(), txtNumber.Text);
            lblNumber.Text = "* Updated successfully.";
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            myData.UpdatePassword(Session["AccountID"].ToString(), txtPassword.Text);
            lblPassword.Text = "* Updated successfully.";
        }
    }
}