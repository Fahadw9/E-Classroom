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
            //use in inserting data maybe
            //if (!IsPostBack)
            //{
            //    DisplayRecord();
            //}
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

                command1.CommandText = @"select * from helpingmaterial where materialtype = 'book' and course_name = @course";
                command1.Parameters.Add(new SqlParameter("course", Course.Text));

                SqlDataAdapter Adp1 = new SqlDataAdapter(command1);
                DataTable Dt1 = new DataTable();
                Adp1.Fill(Dt1);
                grid1.DataSource = Dt1;
                grid1.DataBind();

                SqlCommand command2 = con.CreateCommand();

                command2.CommandText = @"select * from helpingmaterial where materialtype = 'practice' and course_name = @course";
                command2.Parameters.Add(new SqlParameter("course", Course.Text));

                SqlDataAdapter Adp2 = new SqlDataAdapter(command2);
                DataTable Dt2 = new DataTable();
                Adp2.Fill(Dt2);
                grid2.DataSource = Dt2;
                grid2.DataBind();

                SqlCommand command3 = con.CreateCommand();

                command3.CommandText = @"select * from helpingmaterial where materialtype = 'notes' and course_name = @course";
                command3.Parameters.Add(new SqlParameter("course", Course.Text));

                SqlDataAdapter Adp3 = new SqlDataAdapter(command3);
                DataTable Dt3 = new DataTable();
                Adp3.Fill(Dt3);
                grid3.DataSource = Dt3;
                grid3.DataBind();

                con.Close();
                return Dt1;
            }
        }
    }
}