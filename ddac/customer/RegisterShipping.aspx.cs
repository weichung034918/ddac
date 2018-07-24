using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Device.Location;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ddac.customer
{
    public partial class RegisterShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].Equals(WebConfigurationManager.AppSettings["customer"]))
            {
                Response.Redirect("Account/Login");
            }
            departurePort.Items[0].Attributes.Add("disabled", "disabled");
            arrivalPort.Items[0].Attributes.Add("disabled", "disabled");
            containerSize.Items[0].Attributes.Add("disabled", "disabled");
        }

        protected void registerShipping(object sender, EventArgs e)
        {
            var departure = departurePort.SelectedValue;
            var arrival = arrivalPort.SelectedValue;
            var containerRate = containerSize.SelectedValue;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = "INSERT INTO shipping (departure_port,arrival_port,date,status,cost,remark,user_id,container_id) VALUES(@departure_port,@arrival_port,GETDATE(),@status,@cost,@remark,@user_id,@container_id);";
            SqlCommand registerShipping = new SqlCommand(sql, con);
            registerShipping.Parameters.Add("@departure_port", SqlDbType.Int);
            registerShipping.Parameters["@departure_port"].Value = int.Parse(departure.Split(',')[0]);
            registerShipping.Parameters.Add("@arrival_port", SqlDbType.Int);
            registerShipping.Parameters["@arrival_port"].Value = int.Parse(arrival.Split(',')[0]);
            registerShipping.Parameters.Add("@status", SqlDbType.NVarChar);
            registerShipping.Parameters["@status"].Value = WebConfigurationManager.AppSettings["pendingApproval"];
            registerShipping.Parameters.Add("@cost", SqlDbType.NVarChar);
            registerShipping.Parameters["@cost"].Value = Price.Text;
            registerShipping.Parameters.Add("@remark", SqlDbType.NVarChar);
            registerShipping.Parameters["@remark"].Value = remark.Text;
            registerShipping.Parameters.Add("@user_id", SqlDbType.Int);
            registerShipping.Parameters["@user_id"].Value = Session["id"];
            registerShipping.Parameters.Add("@container_id", SqlDbType.Int);
            registerShipping.Parameters["@container_id"].Value = double.Parse(containerRate.Split(',')[0]);
            con.Open();
            int s = registerShipping.ExecuteNonQuery();
            con.Close();
            if (s != 0)
            {
                Response.Redirect("/customer/RegisterShipping", false);
            }
        }
        protected void updatePrice(object sender,EventArgs e)
        {            
            if(!departurePort.SelectedIndex.Equals(0) && !arrivalPort.SelectedIndex.Equals(0) && !containerSize.SelectedIndex.Equals(0))
            {
                var departure = departurePort.SelectedValue;
                var arrival = arrivalPort.SelectedValue;
                var containerRate = containerSize.SelectedValue;
                var departureCoordinate = new GeoCoordinate(double.Parse(departure.Split(',')[1]), double.Parse(departure.Split(',')[2]));
                var arrivalCoordinate = new GeoCoordinate(double.Parse(arrival.Split(',')[1]), double.Parse(arrival.Split(',')[2]));
                double price = Math.Round((departureCoordinate.GetDistanceTo(arrivalCoordinate) / 1000)* int.Parse(containerRate.Split(',')[1]),2);
                Price.Text = price.ToString();
            }
        }
    }
}