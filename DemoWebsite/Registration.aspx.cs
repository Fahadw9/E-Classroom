using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DemoWebsite.DAL;
using System.Windows.Forms;
namespace DemoWebsite
{
    public partial class Registration : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
            if (Session["usertype"].ToString() == "student")
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = "course_finding";
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@email", Session["username"].ToString());
                    com.Parameters.AddWithValue("@course_name", "Programming Fundamentals");
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        CheckBox1.Checked = true;
                        CheckBox1.Enabled = false;
                    }
                    dr.Close();
                    com.Parameters["@course_name"].Value = "Calculus 1";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CheckBox2.Checked = true;
                        CheckBox2.Enabled = false;
                    }
                    dr.Close();

                    com.Parameters["@course_name"].Value = "Physics";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CheckBox3.Checked = true;
                        CheckBox3.Enabled = false;
                    }
                    dr.Close();
                    com.Parameters["@course_name"].Value = "ICT";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CheckBox4.Checked = true;
                        CheckBox4.Enabled = false;
                    }
                    dr.Close();
                    com.Parameters["@course_name"].Value = "Pakistan Studies";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CheckBox6.Checked = true;
                        CheckBox6.Enabled = false;
                    }
                    dr.Close();

                    con.Close();

                }
            }
            else
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                Label6.Text = "You do not have access to registration";
            }

            }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "student")
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlCommand SQLCMD;
                    if (CheckBox1.Checked && CheckBox1.Enabled)
                    {

                        SQLCMD = new SqlCommand("course_registration", con);
                        SQLCMD.CommandType = CommandType.StoredProcedure;
                        SQLCMD.Parameters.AddWithValue("@email", Session["username"].ToString());
                        SQLCMD.Parameters.AddWithValue("@course_name", "Programming Fundamentals");
                        CheckBox1.Enabled = false;
                        SQLCMD.ExecuteNonQuery();
                    }
                    if (CheckBox2.Checked && CheckBox2.Enabled)
                    {
                        SQLCMD = new SqlCommand("course_registration", con);
                        SQLCMD.CommandType = CommandType.StoredProcedure;
                        SQLCMD.Parameters.AddWithValue("@email", Session["username"].ToString());
                        SQLCMD.Parameters.AddWithValue("@course_name", "Calculus 1");
                        CheckBox2.Enabled = false;
                        SQLCMD.ExecuteNonQuery();
                    }
                    if (CheckBox3.Checked && CheckBox3.Enabled)
                    {
                        SQLCMD = new SqlCommand("course_registration", con);
                        SQLCMD.CommandType = CommandType.StoredProcedure;
                        SQLCMD.Parameters.AddWithValue("@email", Session["username"].ToString());
                        SQLCMD.Parameters.AddWithValue("@course_name", "Physics");
                        CheckBox3.Enabled = false;
                        SQLCMD.ExecuteNonQuery();
                    }
                    if (CheckBox4.Checked && CheckBox4.Enabled)
                    {
                        SQLCMD = new SqlCommand("course_registration", con);
                        SQLCMD.CommandType = CommandType.StoredProcedure;
                        SQLCMD.Parameters.AddWithValue("@email", Session["username"].ToString());
                        SQLCMD.Parameters.AddWithValue("@course_name", "ICT");
                        CheckBox4.Enabled = false;
                        SQLCMD.ExecuteNonQuery();
                    }
                    if (CheckBox6.Checked && CheckBox6.Enabled)
                    {
                        SQLCMD = new SqlCommand("course_registration", con);
                        SQLCMD.CommandType = CommandType.StoredProcedure;
                        SQLCMD.Parameters.AddWithValue("@email", Session["username"].ToString());
                        SQLCMD.Parameters.AddWithValue("@course_name", "Pakistan Studies");
                        CheckBox6.Enabled = false;
                        SQLCMD.ExecuteNonQuery();
                    }

                    con.Close();

                }
            }
        }
    }
}