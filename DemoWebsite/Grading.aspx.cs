using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebsite
{
    public partial class Grading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["usertype"] == "student")
            {
                Response.Redirect("Grading_Student.aspx");

            }

            else
            {
                Response.Redirect("Grading_Teacher.aspx");
            }

        }
    }
}