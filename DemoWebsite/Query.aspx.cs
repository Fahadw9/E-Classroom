using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DemoWebsite
{
    public partial class Query : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        SqlConnection Cn;
        SqlDataAdapter Da;
        DataSet Ds;
        int Max = 0;
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "teacher")
            {
            }
            else
            {
                label0.Text = "You do not have acccess to this feature";
                G1.Enabled = false;
                G2.Enabled = false;
            }
        }

        protected void btn_Grade_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "teacher")
            {
                {
                    using (SqlConnection Cn = new SqlConnection(connString))
                    {
                        Cn.Open();
                        String MinRange;
                        String MaxRange;
                        try
                        {
                            if (Session["usertype"].ToString() == "teacher")
                            {

                                if (G1.Text.ToString() == "")
                                {
                                    MaxRange = "A";
                                }
                                else
                                {
                                    MaxRange = G1.Text.ToString();
                                }
                                if (G2.Text.ToString() == "")
                                {
                                    MinRange = "F";
                                }
                                else
                                {
                                    MinRange = G2.Text.ToString();
                                }
                                if ((G1.Text.ToString() != "A" && G1.Text.ToString() != "B" && G1.Text.ToString() != "C" && G1.Text.ToString() != "D" && G1.Text.ToString() != "E" && G1.Text.ToString() != "F") ||
                                    (G2.Text.ToString() != "A" && G2.Text.ToString() != "B" && G2.Text.ToString() != "C" && G2.Text.ToString() != "D" && G2.Text.ToString() != "E" && G2.Text.ToString() != "F"))
                                {
                                    Response.Write("<script language=javascript>alert('Invalid Range For Grades Entered.')</script>");
                                    return;
                                }


                                DataTable dt = new DataTable();

                                DataColumn dc = new DataColumn("Email", typeof(String));
                                dt.Columns.Add(dc);
                                dc = new DataColumn("Course", typeof(String));
                                dt.Columns.Add(dc);
                                dc = new DataColumn("Grade", typeof(String));
                                dt.Columns.Add(dc);
                                DataRow dr = dt.NewRow();
                                String query;
                                if (list1.SelectedValue.ToString() == "0")
                                {
                                    query = ("select * from grade where lettergrade >= '" + MaxRange + "' AND  lettergrade <= '" + MinRange + "'");
                                }
                                else
                                {
                                    query = ("select * from grade where lettergrade >= '" + MaxRange + "' AND  lettergrade <= '" + MinRange + "' AND course = '" + list1.SelectedItem.Text.ToString() + "'");
                                }
                                SqlCommand cmd = new SqlCommand(query, Cn);
                                SqlDataReader reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    dr[0] = reader[0].ToString();
                                    dr[1] = reader[1].ToString();
                                    dr[2] = reader[2].ToString();
                                    dt.Rows.Add(dr);
                                    dr = dt.NewRow();
                                }
                                GridView3.DataSource = dt;
                                GridView3.DataBind();

                                Cn.Close();


                            }
                        }
                        catch
                        {
                            Response.Write("<script language=javascript>alert('Database connection not found.')</script>");
                            return;
                        }

                    }

                }
            }
            else
            {
                label0.Text = "You do not have acccess to this feature";
                G1.Enabled = false;
                G2.Enabled = false;
            }
        }
    }
}