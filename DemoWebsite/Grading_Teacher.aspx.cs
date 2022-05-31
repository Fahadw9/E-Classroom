using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DemoWebsite
{
    public partial class Grading_Teacher : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        SqlConnection Cn;
        SqlDataAdapter Da;
        DataSet Ds;
        int Max = 0;
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["usertype"].ToString() == "teacher")
            {
                Response.Redirect("Attendance_Teacher.aspx");
            }
            */
            if (!Page.IsPostBack)
            {
                {
                    using (SqlConnection Cn = new SqlConnection(connString))
                    {
                        LblMsg.Visible = false;
                        //if (Session["usertype"].ToString() == "teacher")
                        //{

                            Label1.Text = "Enter Grades Here";
                            DDListClass.Items.Insert(0, new ListItem("-- Select Class --", "0"));
                            Cn.Open();
                            string query = ("select DISTINCT course_name from enrollment where t_email= '" + Session["username"].ToString() + "'");
                            SqlCommand cmd = new SqlCommand(query, Cn);
                            SqlDataReader reader = cmd.ExecuteReader();
                            int i = 1;
                            while (reader.Read())
                            {
                                DDListClass.Items.Insert(i, new ListItem(reader[0].ToString(), i.ToString()));
                                i++;
                            }
                            reader.Close();
                            Cn.Close();

                        //}
                        /*
                if (!IsPostBack)
                {
                    Class_Onload();
                }*/

                    }
                }

            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                Cn.Open();
                //if (Session["usertype"].ToString() == "teacher")
                //{
                    try
                    {
                        //Cn.Open();
                        Da = new SqlDataAdapter("SELECT * FROM enrollment WHERE course_name='" + DDListClass.SelectedItem.Text.Trim() + "'", Cn);


                        Ds = new DataSet();
                        Da.Fill(Ds, "TempStud");
                        Max = Ds.Tables["TempStud"].Rows.Count;

                        if (Max > 0)
                        {

                            GridView1.DataSource = Ds.Tables["TempStud"];

                            GridView1.DataBind();
                            Cn.Close();

                        }
                        else
                        {
                            Ds.Tables["TempStud"].Rows.Add(Ds.Tables["TempStud"].NewRow());

                            GridView1.DataSource = Ds;
                            GridView1.DataBind();

                            int GViewColumnCount = GridView1.Rows[0].Cells.Count;
                            GridView1.Rows[0].Cells.Clear();
                            GridView1.Rows[0].Cells.Add(new TableCell());
                            GridView1.Rows[0].Cells[0].ColumnSpan = GViewColumnCount;

                            GridView1.Rows[0].Cells[0].Text = "No Records Found.";

                        }

                        Cn.Close();
                    }
                    catch
                    {
                        Response.Write("<script language=javascript>alert('Database connection not found.')</script>");
                        return;
                    }
                //}
            }


        }

        public void Class_Onload()
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                //if (Session["usertype"].ToString() == "student")
                //{
                    try
                    {
                        Cn.Open();
                        Da = new SqlDataAdapter("SELECT * FROM student", Cn);
                        Ds = new DataSet();
                        Da.Fill(Ds, "TempClass");
                        Max = Ds.Tables["TempClass"].Rows.Count;

                        if (Max > 0)
                        {
                            DDListClass.DataTextField = Ds.Tables["TempClass"].Columns["class"].ToString(); // text field name of table dispalyed in dropdown

                            DDListClass.DataSource = Ds.Tables["TempClass"];      //assigning Value datasource to the dropdownlist
                            DDListClass.DataBind();  //binding dropdownlist
                            DDListClass.Items.Insert(0, new ListItem("--Select Class --", "0"));
                            Cn.Close();

                        }
                        else
                        {
                            DDListClass.DataSource = Ds.Tables["TempClass"];      //assigning Value datasource to the dropdownlist
                            DDListClass.DataBind();  //binding dropdownlist
                            DDListClass.Items.Insert(0, new ListItem("--Class not found--", "0"));
                        }
                    }
                    catch
                    {

                    }
                //}

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                Cn.Open();
                String rollno = "";
                String studentname = "", dateofclass = "", sclass = "", status = "";

                foreach (GridViewRow row in GridView1.Rows)
                {

                    rollno = Convert.ToString(row.Cells[0].Text);
                    studentname = row.Cells[1].Text;

                    TextBox TB1 = (row.Cells[1].FindControl("TextBox1") as TextBox);

                    status = TB1.Text.Trim();
                    dateofclass = DateTime.Now.ToShortDateString();
                    sclass = DDListClass.SelectedItem.Text;

                }
                str = "DELETE FROM grade;";
                SqlCommand SQLCMD1 = new SqlCommand(str, Cn);
                SQLCMD1.ExecuteScalar();

                str = "INSERT INTO grade(studentemail, course, lettergrade) VALUES('" + rollno + "','" + sclass + "','" + status + "')";
                SqlCommand SQLCMD = new SqlCommand(str, Cn);
                SQLCMD.ExecuteScalar();
                Cn.Close();
                LblMsg.Visible = true;
                LblMsg.Text = "Grades Saved Successfully";
            }
        }
    }

}