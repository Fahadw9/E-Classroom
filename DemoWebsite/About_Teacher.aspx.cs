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
    public partial class About_Teacher : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {


                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Teacher_View_Profile";
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@email", Session["username"].ToString());


                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    Address.Text = Convert.ToString(dr["address"]);
                    Contact_no.Text = Convert.ToString(dr["contact_no"]);
                    Password.Text = Convert.ToString(dr["password"]);
                    Age.Text = Convert.ToString(dr["age"]);
                    FullName.Text = Convert.ToString(dr["NAME"]);
                }

                con.Close();

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
        }
    }
}