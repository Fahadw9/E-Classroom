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


// TODO add queries according to table
namespace DemoWebsite
{
    public partial class Attendance : System.Web.UI.Page
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
                        if (Session["usertype"].ToString() == "teacher")
                        {

                            Label1.Text = "Mark Attendance";
                            Label2.Text = "Mark Attendance";
                            DDListClass.Items.Insert(0, new ListItem("--Select Class --", "0"));
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
                            Date.Text = "Today is " + Convert.ToString(DateTime.Now.ToShortDateString());
                            Cn.Close();

                        }
                        else
                        {
                            BtnSave.Enabled = false;
                            Label2.Text = "Show Attendance";
                            Label1.Text = "Show Attendance";           
                            DDListClass.Items.Insert(0, new ListItem("--Select Class --", "0"));
                            Cn.Open();
                            string query = ("select course_name from enrollment where s_email= '" + Session["username"].ToString() + "'");
                            SqlCommand cmd = new SqlCommand(query, Cn);
                            SqlDataReader reader = cmd.ExecuteReader();
                            int i = 1;
                            while (reader.Read())
                            {

                                DDListClass.Items.Insert(i, new ListItem(reader[0].ToString(),i.ToString() ));
                                i++;
                            }
                            reader.Close();
                            Cn.Close();

                          

                        }/*
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
                if (Session["usertype"].ToString() == "teacher")
                {
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
                }
                else
                {
                    BtnSave.Enabled = false;

                    DataTable dt = new DataTable();
                    DataColumn dc = new DataColumn("Date", typeof(String));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("Attendance", typeof(String));
                    dt.Columns.Add(dc);
                    DataRow dr = dt.NewRow();
                    String query = ("select attendance_date, classattendance from attendance where s_email= '" + Session["username"].ToString() + "' AND course = '" + DDListClass.SelectedItem.Text.Trim().ToString() + "'");
                    SqlCommand cmd = new SqlCommand(query, Cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dr[0] = reader[0].ToString().Substring(0, 10);
                        dr[1] = reader[1].ToString();
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                    }
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
                

        }

        public void Class_Onload()
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                if (Session["usertype"].ToString() == "student")
                {
                    BtnSave.Enabled = false;
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
                }

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "teacher")
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
                        RadioButton rbtn1 = (row.Cells[1].FindControl("RadioButton1") as RadioButton);
                        RadioButton rbtn2 = (row.Cells[1].FindControl("RadioButton2") as RadioButton);

                        if (rbtn1.Checked)
                        {
                            status = "P";

                        }
                        else
                        {
                            status = "A";
                        }
                        dateofclass = DateTime.Now.ToShortDateString();
                        sclass = DDListClass.SelectedItem.Text;

                    }

                    str = "INSERT INTO Attendance(attendance_date , course , s_email , classattendance) VALUES('" + dateofclass + "','" + sclass + "','" + rollno + "','" + status + "')";
                    SqlCommand SQLCMD = new SqlCommand(str, Cn);
                    SQLCMD.ExecuteScalar();
                    Cn.Close();
                    LblMsg.Visible = true;
                    LblMsg.Text = "Attendance Has Been Saved Successfully";
                }
            }
        }
    }
}