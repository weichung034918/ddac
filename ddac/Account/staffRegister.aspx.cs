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

namespace ddac.Account
{
    public partial class staffRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (!WebConfigurationManager.AppSettings["companyStaffKey"].Equals(companyKey.Text))
            {
                Type type = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                if (!cs.IsStartupScriptRegistered(type, "PopupScript"))
                {
                    String cstext = "alert('Invalid authentication. Please retry.');";
                    cs.RegisterStartupScript(type, "PopupScript", cstext, true);
                }
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                try
                {
                    con.Open();
                    string sql = "select * from users where username = @username";
                    SqlCommand checkUsername = new SqlCommand(sql, con);
                    checkUsername.Parameters.Add(new SqlParameter("@username", Username.Text));
                    SqlDataReader dataReader = checkUsername.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Type type = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        if (!cs.IsStartupScriptRegistered(type, "PopupScript"))
                        {
                            String cstext = "alert('Username Exists! please change your username.');";
                            cs.RegisterStartupScript(type, "PopupScript", cstext, true);
                        }
                    }
                    else
                    {
                        if (!dataReader.IsClosed)
                        {
                            dataReader.Close();
                        }
                        sql = "INSERT INTO users (username,password,email,contact_no,name,role) VALUES(@username,@password,@email,@contact_no,@name,@role);";
                        SqlCommand registerCustomer = new SqlCommand(sql, con);
                        registerCustomer.Parameters.Add("@username", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@username"].Value = Username.Text;
                        registerCustomer.Parameters.Add("@password", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@password"].Value = Password.Text;
                        registerCustomer.Parameters.Add("@email", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@email"].Value = Email.Text;
                        registerCustomer.Parameters.Add("@contact_no", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@contact_no"].Value = ContactNo.Text;
                        registerCustomer.Parameters.Add("@name", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@name"].Value = Name.Text;
                        registerCustomer.Parameters.Add("@role", SqlDbType.NVarChar);
                        registerCustomer.Parameters["@role"].Value = WebConfigurationManager.AppSettings["staff"];
                        int s = registerCustomer.ExecuteNonQuery();
                        if (s != 0)
                        {
                            Type type = this.GetType();
                            ClientScriptManager cs = Page.ClientScript;
                            if (!cs.IsStartupScriptRegistered(type, "PopupScript"))
                            {
                                String cstext = "alert('Create Success. Please login to continue.');";
                                cs.RegisterStartupScript(type, "PopupScript", cstext, true);
                            }
                            Response.Redirect("/Account/Login", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
}