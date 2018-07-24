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
    public partial class viewPort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void tableAction(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;
            if (command.Equals("delete"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string sql = "delete from port where id = @id";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand approveShipRequest = new SqlCommand(sql, con);
                approveShipRequest.Parameters.Add("@id", SqlDbType.Int);
                int shippingId = int.Parse(portTable.Rows[rowIndex].Cells[0].Text);
                approveShipRequest.Parameters["@id"].Value = shippingId;
                con.Open();
                int success = approveShipRequest.ExecuteNonQuery();
                con.Close();
                if (success != 0)
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}