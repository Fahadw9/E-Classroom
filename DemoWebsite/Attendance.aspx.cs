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
            LblMsg.Visible = false;
            Label1.Text = "Mark Attendance for " + DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                Class_Onload();
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                try
                {
                    Cn.Open();
                    Da = new SqlDataAdapter("SELECT * FROM enrollment WHERE courseid='" + DDListClass.SelectedItem.Text.Trim() + "'", Cn);


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
        }

        public void Class_Onload()
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                try
                {
                    Cn.Open();
                    Da = new SqlDataAdapter("SELECT * FROM StudentDetails", Cn);
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cn = new SqlConnection(connString))
            {
                Cn.Open();
                int rollno = 0;
                String studentname = "", dateofclass = "", sclass = "", status = "";

                foreach (GridViewRow row in GridView1.Rows)
                {

                    rollno = Convert.ToInt32(row.Cells[0].Text);
                    studentname = row.Cells[1].Text;
                    RadioButton rbtn1 = (row.Cells[2].FindControl("RadioButton1") as RadioButton);
                    RadioButton rbtn2 = (row.Cells[2].FindControl("RadioButton2") as RadioButton);

                    if (rbtn1.Checked)
                    {
                        status = "Present";

                    }
                    else
                    {
                        status = "Absent";
                    }
                    dateofclass = DateTime.Now.ToShortDateString();
                    sclass = DDListClass.SelectedItem.Text;

                }



                str = "INSERT INTO Attendance(rollno , studentname , dateofclass , attendancestatus, class ) VALUES('" + rollno + "','" + studentname + "','" + dateofclass + "','" + status + "','" + sclass + "')";
                //int x = Connection.UpdateRecord(Cn, str);
                Cn.Close();
                LblMsg.Visible = true;
                LblMsg.Text = "Attendance Has Been Saved Successfully";

            }
        }
    }
}