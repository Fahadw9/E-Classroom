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
    public partial class Homeworks_Teacher : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            Email.Text = "";
            list3.SelectedValue = "Select Course";
            Name.Text = "";
            Date.Text = "mm/dd/yyyy";
            OMarks.Text = "";
            Total.Text = "";
            DisplayRecord();
        }
        public DataTable DisplayRecord()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand command1 = con.CreateCommand();

                command1.CommandText = @"select * from homework where course=@course";
                command1.Parameters.Add(new SqlParameter("course", list1.SelectedValue));

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

        protected void btnSave_Add(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                l6.Text = "";
                con.Open();
                SqlCommand conn = new SqlCommand("Add_Hw", con);
                try
                {
                    conn.CommandType = CommandType.StoredProcedure;

                    conn.Parameters.Add("@id", SqlDbType.Int);
                    conn.Parameters.Add("@email", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@course", SqlDbType.VarChar, 25);
                    conn.Parameters.Add("@assesment_type", SqlDbType.VarChar, 15);
                    conn.Parameters.Add("@assesment_name", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@taken_date", SqlDbType.Date);
                    conn.Parameters.Add("@link", SqlDbType.VarChar, 100);
                    conn.Parameters.Add("@marks", SqlDbType.Int);
                    conn.Parameters.Add("@total", SqlDbType.Int);

                    conn.Parameters["@id"].Value = ID.Text;
                    conn.Parameters["@email"].Value = Email.Text;
                    conn.Parameters["@course"].Value = list3.SelectedValue;
                    conn.Parameters["@assesment_type"].Value = "homework";
                    conn.Parameters["@assesment_name"].Value = Name.Text;
                    conn.Parameters["@taken_date"].Value = Date.Text;
                    conn.Parameters["@link"].Value = Link.Text;
                    conn.Parameters["@marks"].Value = OMarks.Text;
                    conn.Parameters["@total"].Value = Total.Text;

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
                SqlCommand conn = new SqlCommand("Remove_Hw", con);
                try
                {
                    //deletion me bs key attributes ke zarorat he baki bs khana pori ke liye hn
                    conn.CommandType = CommandType.StoredProcedure;

                    conn.Parameters.Add("@id", SqlDbType.Int);
                    conn.Parameters.Add("@email", SqlDbType.VarChar, 30);
                    conn.Parameters.Add("@course", SqlDbType.VarChar, 25);
                    //conn.Parameters.Add("@assesment_type", SqlDbType.VarChar, 15);
                    //conn.Parameters.Add("@assesment_name", SqlDbType.VarChar, 30);
                    //conn.Parameters.Add("@taken_date", SqlDbType.Date);
                    //conn.Parameters.Add("@marks", SqlDbType.Int);
                    //conn.Parameters.Add("@total", SqlDbType.Int);

                    conn.Parameters["@id"].Value = ID.Text;
                    conn.Parameters["@email"].Value = Email.Text;
                    conn.Parameters["@course"].Value = list3.SelectedValue;
                    //conn.Parameters["@assesment_type"].Value = "assignment";
                    //conn.Parameters["@assesment_name"].Value = Name.Text;
                    //conn.Parameters["@taken_date"].Value = Date.Text;
                    //conn.Parameters["@marks"].Value = OMarks.Text;
                    //conn.Parameters["@total"].Value = Total.Text;

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