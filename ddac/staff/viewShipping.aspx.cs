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
    public partial class viewShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            emptyApproval.Visible = tableApproval.Rows.Count.Equals(0);
            emptyArrival.Visible = tableArrival.Rows.Count.Equals(0);
        }
        protected void tableAction(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string sql = "update shipping set status = @status where id = @id";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand approveShipRequest = new SqlCommand(sql, con);
            approveShipRequest.Parameters.Add("@id", SqlDbType.Int);
            approveShipRequest.Parameters.Add("@status", SqlDbType.NVarChar);
            if (command.Equals("approval"))
            {
                int shippingId = int.Parse(tableApproval.Rows[rowIndex].Cells[0].Text);
                approveShipRequest.Parameters["@id"].Value = shippingId;
                approveShipRequest.Parameters["@status"].Value = WebConfigurationManager.AppSettings["approved"];
            }
            else if(command.Equals("arrival"))
            {
                int shippingId = int.Parse(tableArrival.Rows[rowIndex].Cells[0].Text);
                approveShipRequest.Parameters["@id"].Value = shippingId;
                approveShipRequest.Parameters["@status"].Value = WebConfigurationManager.AppSettings["arrived"];
            }
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