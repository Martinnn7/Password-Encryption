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
    public partial class UserProfile : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = myData.GetUserByAccountID(Session["AccountID"].ToString());

            lblEmail.Text = dt.Rows[0]["EmailAddress"].ToString();
            lblName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["MiddleInitial"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            lblAddress.Text = dt.Rows[0]["HomeAddress"].ToString();
            lblNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
            lblPassword.Text = dt.Rows[0]["Password"].ToString();
        }
    }
}