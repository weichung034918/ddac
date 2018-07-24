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
    public partial class addPort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void createPort_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                con.Open();                
                string sql = "INSERT INTO port (name,longtitude,latitude) VALUES(@name,@longtitude,@latitude);";
                SqlCommand createPort = new SqlCommand(sql, con);
                createPort.Parameters.Add("@name", SqlDbType.NVarChar);
                createPort.Parameters["@name"].Value = portName.Text;
                createPort.Parameters.Add("@longtitude", SqlDbType.NVarChar);
                createPort.Parameters["@longtitude"].Value = longtitude.Text;
                createPort.Parameters.Add("@latitude", SqlDbType.NVarChar);
                createPort.Parameters["@latitude"].Value = latitude.Text;
                int s = createPort.ExecuteNonQuery();
                if (s != 0)
                {
                    Response.Redirect("/staff/viewPort", false);
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