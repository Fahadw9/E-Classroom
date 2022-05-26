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
using System.Windows.Forms;

namespace DemoWebsite
{
    public partial class About_Student : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Student_View_Profile";
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@email", Session["username"].ToString());


                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    FullName.Text = Convert.ToString(dr["NAME"]);
                    Address.Text = Convert.ToString(dr["address"]);
                    Contact_no.Text = Convert.ToString(dr["contact_no"]);
                    Password.Text = Convert.ToString(dr["password"]);
                    Age.Text = Convert.ToString(dr["age"]);
                }

                con.Close();

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                l7.Text = "Modify Credentials For Updation";
                SqlCommand SQLCMD;
                SQLCMD = new SqlCommand("Update_Student_Profile", con);

                //trigger
                con.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
                con.FireInfoMessageEventOnUserErrors = true;

                con.Open();
                try
                {
                    SQLCMD.CommandType = CommandType.StoredProcedure;

                    SQLCMD.Parameters.Add("@email", SqlDbType.VarChar, 30);
                    SQLCMD.Parameters.Add("@name", SqlDbType.VarChar, 25);
                    SQLCMD.Parameters.Add("@age", SqlDbType.Int);
                    SQLCMD.Parameters.Add("@address", SqlDbType.VarChar, 50);
                    SQLCMD.Parameters.Add("@contact_no", SqlDbType.VarChar, 11);
                    SQLCMD.Parameters.Add("@password", SqlDbType.VarChar, 20);



                    SQLCMD.Parameters["@email"].Value = Session["username"].ToString();
                    SQLCMD.Parameters["@name"].Value = FullName.Text;
                    SQLCMD.Parameters["@age"].Value = Age.Text;
                    SQLCMD.Parameters["@address"].Value = Address.Text;
                    SQLCMD.Parameters["@contact_no"].Value = Contact_no.Text;
                    SQLCMD.Parameters["@password"].Value = Password.Text;


                    SQLCMD.ExecuteNonQuery();

                    con.Close();

                }
                catch (SqlException ex)
                {
                    l7.Text = "Update Unsuccessful";
                }
            }
        }
        static void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}