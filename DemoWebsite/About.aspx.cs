using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DemoWebsite.DAL;

namespace DemoWebsite
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["usertype"] == "student")
            {
                Response.Redirect("About_Student.aspx");

            }

            else
            {
                Response.Redirect("About_Teacher.aspx");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
        }
    }
}