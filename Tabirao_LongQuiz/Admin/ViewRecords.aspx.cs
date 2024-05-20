using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DataHelper;
namespace Tabirao_LongQuiz.Admin
{
    public partial class ViewRecords : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdUsers.DataSource = myData.GetUsers();
            grdUsers.DataBind();
        }
    }
}