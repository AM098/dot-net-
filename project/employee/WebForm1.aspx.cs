using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace employee_table
{
    public partial class WebForm1 : System.Web.UI.Page
    {     //this line is for creating a connection between database and form
        SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=employee; Integrated Security=True");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
        if (!IsPostBack)
        FillGrid();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtempdes.Text == null || txtempName.Text == null || // add more coloum
                txtempdes.Text.ToString().Trim().Equals("") || txtempName.Text.ToString().Trim().Equals(""))
                    lblInfo.Text = "Please enter all fields";
                else
                {

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "sp_EMP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMP_NAME", txtempName.Text.ToString());
                    cmd.Parameters.AddWithValue("@EMP_DESC", txtempdes.Text.ToString());// add more parameter for coloum
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select EMP_NAME,EMP_DESC from EMP_DB", con));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    prodatagrid.DataSource = dt;
                    prodatagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();

                    lblInfo.Text = "Added Successfully";
                    txtempdes.Text = "";
                    txtempName.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error:" + ex.Message.ToString();
            }
        }

        public void FillGrid()
        {
            try
            {

                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select EMP_NAME,EMP_DESC from EMP_DB", con)); ///
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                prodatagrid.DataSource = dt;
                prodatagrid.DataBind();
                adapter.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}