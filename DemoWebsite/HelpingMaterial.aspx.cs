using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebsite
{
    public partial class HelpingMaterial : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["usertype"] == "student")
            {
                Response.Redirect("HM_Student.aspx");

            }

            else
            {
                Response.Redirect("HM_Teacher.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}