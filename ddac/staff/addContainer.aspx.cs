using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ddac.staff
{
    public partial class addContainer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].Equals(WebConfigurationManager.AppSettings["staff"]))
            {
                Response.Redirect("Account/Login");
            }
        }
        protected void createContainer_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                con.Open();
                string sql = "INSERT INTO container (size,rate) VALUES(@size,@rate);";
                SqlCommand createPort = new SqlCommand(sql, con);
                createPort.Parameters.Add("@size", SqlDbType.NVarChar);
                createPort.Parameters["@size"].Value = size.Text;
                createPort.Parameters.Add("@rate", SqlDbType.NVarChar);
                createPort.Parameters["@rate"].Value = rate.Text;
                int s = createPort.ExecuteNonQuery();
                if (s != 0)
                {
                    Response.Redirect("/staff/viewContainer", false);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
            }
        }
    }
}