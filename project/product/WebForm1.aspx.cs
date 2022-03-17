using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace productmanagment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4PQK2PII\SQLEXPRESS01; Initial Catalog=product; Integrated Security=True");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductDesc.Text == null || txtProductName.Text == null || // add more coloum
                txtProductDesc.Text.ToString().Trim().Equals("") || txtProductName.Text.ToString().Trim().Equals(""))
                    lblInfo.Text = "Please enter all fields";
                else
                {

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "sp_EMP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMP_Name", txtProductName.Text.ToString());
                    cmd.Parameters.AddWithValue("@EMP_Desc", txtProductDesc.Text.ToString());// add more parameter for coloum
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select EMP_Name,EMP_Desc from EMP_DB", con));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    proDataGrid.DataSource = dt;
                    proDataGrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();

                    lblInfo.Text = "Added Successfully";
                    txtProductDesc.Text = "";
                    txtProductName.Text = "";
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
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select EMP_Name,EMP_Desc from EMP_DB", con)); ///
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                proDataGrid.DataSource = dt;
                proDataGrid.DataBind();
                adapter.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
        