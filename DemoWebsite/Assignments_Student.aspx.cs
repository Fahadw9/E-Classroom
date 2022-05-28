using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebsite
{
    public partial class Assignments_Student : Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DisplayRecord();
        }
        public DataTable DisplayRecord()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand command1 = con.CreateCommand();

                command1.CommandText = @"select * from assignment where course=@course and email=@email";
                command1.Parameters.Add(new SqlParameter("course", list1.SelectedValue));
                command1.Parameters.Add(new SqlParameter("email", (string)Session["username"]));

                SqlDataAdapter Adp1 = new SqlDataAdapter(command1);

                //SqlDataAdapter Adp1 = new SqlDataAdapter("select * from helpingmaterial", con);
                DataTable Dt1 = new DataTable();
                Adp1.Fill(Dt1);
                grid2.DataSource = Dt1;
                grid2.DataBind();

                con.Close();
                return Dt1;
            }
        }
    }
}