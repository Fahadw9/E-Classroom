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
            using (SqlConnection con = new SqlConnection(connString))
            {
                l2.Text = "Sign Up Page";
                con.Open();
                //string query;
                SqlCommand SQLCMD;

                if (rdStudent.Checked)
                {
                    SQLCMD = new SqlCommand("StudentSignUp", con);
                }
                else
                {
                    SQLCMD = new SqlCommand("TeacherSignUp", con);
                }

                try
                {
                    SQLCMD.CommandType = CommandType.StoredProcedure;

                    SQLCMD.Parameters.Add("@email", SqlDbType.VarChar, 30);
                    SQLCMD.Parameters.Add("@name", SqlDbType.VarChar, 25);
                    SQLCMD.Parameters.Add("@password", SqlDbType.VarChar, 30);
                    SQLCMD.Parameters.Add("@age", SqlDbType.Int);
                    SQLCMD.Parameters.Add("@address", SqlDbType.VarChar, 50);
                    SQLCMD.Parameters.Add("@contact_no", SqlDbType.VarChar, 11);
                    //SQLCMD.Parameters.Add("@roll_no", SqlDbType.Int);
                    //SQLCMD.Parameters.Add("@check", SqlDbType.VarChar, 20);

                    SQLCMD.Parameters["@email"].Value = Email.Text;
                    SQLCMD.Parameters["@name"].Value = FullName.Text;
                    SQLCMD.Parameters["@password"].Value = Password.Text;
                    SQLCMD.Parameters["@age"].Value = Age.Text;
                    SQLCMD.Parameters["@address"].Value = Address.Text;
                    SQLCMD.Parameters["@contact_no"].Value = Contact_no.Text;
                    //SQLCMD.Parameters["@check"].Value = "";


                    SQLCMD.ExecuteNonQuery();

                    con.Close();

                }
                catch (SqlException ex)
                {
                    l2.Text = "Sign Up Unsuccessful";
                }
/*                finally
                {
                    con.Close();
                    Response.Redirect("Default.aspx");
                }*/
            }
        }
    }
}