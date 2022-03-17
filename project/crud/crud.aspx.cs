using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud_operation
{
    public partial class crud : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=crud_operation; Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            btnupdate.Enabled = false;
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            try

            {
                SqlCommand cmd = new SqlCommand("Insert into Employee1 values(@id,@name,@salary,@address)", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.Parameters.AddWithValue("@id", TextBox1.Text);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text);

                cmd.Parameters.AddWithValue("@salary", TextBox3.Text);

                cmd.Parameters.AddWithValue("@address", TextBox4.Text);

                cmd.ExecuteNonQuery();

                Label1.Text = "Data has been saved";

                con.Close();

                TextBox1.Text = "";

                TextBox2.Text = "";

                TextBox3.Text = "";

                TextBox4.Text = "";

            }
            catch
            {
                Label1.Text = "First Search Data";
            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Update Employee1 set name=@name,salary=@salary,address=@address where id=@id", con);

            cmd.CommandType = CommandType.Text;

            con.Open();

            cmd.Parameters.AddWithValue("@name", TextBox2.Text);

            cmd.Parameters.AddWithValue("@salary", TextBox3.Text);

            cmd.Parameters.AddWithValue("@address", TextBox4.Text);

            cmd.Parameters.AddWithValue("@id", TextBox1.Text);





            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            Label1.Text = "Data has been Updated";

            con.Close();

            TextBox1.Text = "";

            TextBox2.Text = "";

            TextBox3.Text = "";

            TextBox4.Text = "";





        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try

            {

                SqlCommand cmd = new SqlCommand("delete from Employee1 where id=" + TextBox1.Text, con);

                cmd.CommandType = CommandType.Text;

                con.Open();

                cmd.ExecuteNonQuery();

                Label1.Text = "Data has been Deleted";

                con.Close();

                TextBox1.Text = "";

                TextBox2.Text = "";

                TextBox3.Text = "";

                TextBox4.Text = "";

            }

            catch

            {

                Label1.Text = " invalid Please selct ID First ";

            }



        }

        protected void btnviews_Click(object sender, EventArgs e)
        {

            SqlDataAdapter Adp = new SqlDataAdapter("select * from Employee1", con);

            //DataTable Dt = new DataTable();

            DataSet ds = new DataSet();

            Adp.Fill(ds);

            GridView1.DataSource = ds;

            GridView1.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Employee1 where id=" + TextBox1.Text, con);

            cmd.CommandType = CommandType.Text;



            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)

            {

                Label2.Text = "Id is Found Successfully";

                Label1.Text = "";

                TextBox2.Text = ds.Tables[0].Rows[0]["name"].ToString();

                TextBox3.Text = ds.Tables[0].Rows[0]["salary"].ToString();

                TextBox4.Text = ds.Tables[0].Rows[0]["address"].ToString();

                btnupdate.Enabled = true;



            }

            else

            {

                Label2.Text = "No Particular Searched id  Found";

            }

            con.Close();



        }



    }
}
       