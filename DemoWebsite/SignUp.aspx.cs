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
    public partial class SignUp : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //this code doesnot work. Time wasted here is 2 hours
            /*using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query;

                try
                {
                    SqlCommand SQLCMD = new SqlCommand("StudentSignUp", con);
                    SQLCMD.CommandType = CommandType.StoredProcedure;

                    SQLCMD.Parameters.Add("@email", SqlDbType.VarChar, 30);
                    SQLCMD.Parameters.Add("@name", SqlDbType.VarChar, 25);
                    SQLCMD.Parameters.Add("@password", SqlDbType.VarChar, 30);
                    SQLCMD.Parameters.Add("@age", SqlDbType.Int);
                    SQLCMD.Parameters.Add("@address", SqlDbType.VarChar, 50);
                    SQLCMD.Parameters.Add("@contact_no", SqlDbType.VarChar, 11);
                    SQLCMD.Parameters.Add("@roll_no", SqlDbType.Int);
                    SQLCMD.Parameters.Add("@check", SqlDbType.VarChar, 20);

                }
                catch (Exception)
                {

                    throw;
                }

                SQLCMD.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                SQLCMD.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(SQLCMD.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Home.aspx");
                }
            }*/
        }
    }
}