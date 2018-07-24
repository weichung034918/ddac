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
    public partial class viewContainer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].Equals(WebConfigurationManager.AppSettings["staff"]))
            {
                Response.Redirect("Account/Login");
            }
        }
        protected void tableAction(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;
            if (command.Equals("delete"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string sql = "delete from container where id = @id";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand removeContainerRequest = new SqlCommand(sql, con);
                removeContainerRequest.Parameters.Add("@id", SqlDbType.Int);
                int shippingId = int.Parse(containerTable.Rows[rowIndex].Cells[0].Text);
                removeContainerRequest.Parameters["@id"].Value = shippingId;
                con.Open();
                int success = removeContainerRequest.ExecuteNonQuery();
                con.Close();
                if (success != 0)
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}