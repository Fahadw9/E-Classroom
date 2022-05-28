﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebsite
{
    public partial class Homeworks : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["usertype"] == "student")
            {
                Response.Redirect("Homeworks_Student.aspx");

            }

            else if ((string)Session["usertype"] == "teacher")
            {
                Response.Redirect("Homeworks_Teacher.aspx");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}