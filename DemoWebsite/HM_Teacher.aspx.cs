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
    public partial class HM_Teacher : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //use in inserting data maybe
            if (this.IsPostBack) return;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            list2.SelectedValue = "Select Type";
            Name.Text = "";
            list3.SelectedValue = "Select Course";
            Link.Text = "xyz.com";
            DisplayRecord();
        }
        public DataTable DisplayRecord()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand command1 = con.CreateCommand();

                command1.CommandText = @"select * from helpingmaterial where materialtype = 'book' and course_name = @course";
                command1.Parameters.Add(new SqlParameter("course", list1.SelectedValue));

                SqlDataAdapter Adp1 = new SqlDataAdapter(command1);
                DataTable Dt1 = new DataTable();
                Adp1.Fill(Dt1);
                grid1.DataSource = Dt1;
                grid1.DataBind();

                SqlCommand command2 = con.CreateCommand();

                command2.CommandText = @"select * from helpingmaterial where materialtype = 'practice' and course_name = @course";
                command2.Parameters.Add(new SqlParameter("course", list1.SelectedValue));

                SqlDataAdapter Adp2 = new SqlDataAdapter(command2);
                DataTable Dt2 = new DataTable();
                Adp2.Fill(Dt2);
                grid2.DataSource = Dt2;
                grid2.DataBind();

                SqlCommand command3 = con.CreateCommand();

                command3.CommandText = @"select * from helpingmaterial where materialtype = 'notes' and course_name = @course";
                command3.Parameters.Add(new SqlParameter("course", list1.SelectedValue));

                SqlDataAdapter Adp3 = new SqlDataAdapter(command3);
                DataTable Dt3 = new DataTable();
                Adp3.Fill(Dt3);
                grid3.DataSource = Dt3;
                grid3.DataBind();

                con.Close();
                return Dt1;
            }
        }

        protected void btnSave_Add(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                l6.Text = "";
                con.Open();
                SqlCommand conn = new SqlCommand("Add_Material", con);
                try
                {
                    conn.CommandType = CommandType.StoredProcedure;

                    conn.Parameters.Add("@materialid", SqlDbType.Int);
                    conn.Parameters.Add("@materialtype", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@materialname", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@course_name", SqlDbType.VarChar, 25);
                    conn.Parameters.Add("@ref_link", SqlDbType.VarChar, 50);

                    conn.Parameters["@materialid"].Value = ID.Text;
                    conn.Parameters["@materialtype"].Value = list2.SelectedValue;
                    conn.Parameters["@materialname"].Value = Name.Text;
                    conn.Parameters["@course_name"].Value = list3.SelectedValue;
                    conn.Parameters["@ref_link"].Value = Link.Text;

                    conn.ExecuteNonQuery();

                    con.Close();
                    DisplayRecord();
                }
                catch (SqlException ex)
                {
                    l6.Text = "Enter Proper Values";
                    //l6.Text = ex.Message;
                }
            }
        }

        protected void btnSave_Remove(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                l6.Text = "";
                con.Open();
                SqlCommand conn = new SqlCommand("Remove_Material", con);
                try
                {
                    conn.CommandType = CommandType.StoredProcedure;

                    conn.Parameters.Add("@materialid", SqlDbType.Int);
                    conn.Parameters.Add("@materialtype", SqlDbType.VarChar, 30);
                    //conn.Parameters.Add("@materialname", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@course_name", SqlDbType.VarChar, 25);
                    //conn.Parameters.Add("@ref_link", SqlDbType.VarChar, 50);

                    conn.Parameters["@materialid"].Value = ID.Text;
                    conn.Parameters["@materialtype"].Value = list2.SelectedValue;
                    //conn.Parameters["@materialname"].Value = Name.Text;
                    conn.Parameters["@course_name"].Value = list3.SelectedValue;
                    //conn.Parameters["@ref_link"].Value = Link.Text;

                    conn.ExecuteNonQuery();

                    con.Close();
                    DisplayRecord();
                }
                catch (SqlException ex)
                {
                    l6.Text = "Enter Proper Values";
                    //l6.Text = ex.Message;
                }
            }
        }
    }
}