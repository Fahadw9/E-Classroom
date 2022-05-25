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
    public partial class SignIn : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString)) {
                con.Open();
                if (rdStudent.Checked)
                {
                    string query = "SELECT COUNT(1) FROM student WHERE email=@username AND password=@password";
                    SqlCommand SQLCMD = new SqlCommand(query, con);
                    SQLCMD.Parameters.AddWithValue("@username", txtUserName.Text);
                    SQLCMD.Parameters.AddWithValue("@password", txtPassword.Text);
                    int count = Convert.ToInt32(SQLCMD.ExecuteScalar());
                    if (count == 1)
                    {
                        Session["username"] = txtUserName.Text.Trim();
                        Response.Redirect("Home.aspx");
                    }
                }
                else if (rdTeacher.Checked) {
                    string query = "SELECT COUNT(1) FROM teacher WHERE email=@username AND password=@password";
                    SqlCommand SQLCMD = new SqlCommand(query, con);
                    SQLCMD.Parameters.AddWithValue("@username", txtUserName.Text);
                    SQLCMD.Parameters.AddWithValue("@password", txtPassword.Text);
                    int count = Convert.ToInt32(SQLCMD.ExecuteScalar());
                    if (count == 1)
                    {
                        Session["username"] = txtUserName.Text.Trim();
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    Console.WriteLine("No Option Selected");
                }
            }
        }
    }
}