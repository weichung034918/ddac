using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ddac.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace ddac.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LogIn(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                con.Open();
                string sql = "select * from users where username = @username and password = @password";
                SqlCommand login = new SqlCommand(sql, con);
                login.Parameters.Add(new SqlParameter("@username", Username.Text));
                login.Parameters.Add(new SqlParameter("@password", Password.Text));
                SqlDataReader dataReader = login.ExecuteReader();
                if (dataReader.Read())
                {                    
                    Session["id"] = dataReader["id"];
                    Session["username"] = dataReader["username"];
                    Session["name"] = dataReader["name"];
                    Session["role"] = dataReader["role"];

                    Type type = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(type, "PopupScript"))
                    {
                        String cstext = "alert('login success!');";
                        cs.RegisterStartupScript(type, "PopupScript", cstext, true);
                    }

                    //if (dataReader["role"].Equals(WebConfigurationManager.AppSettings["customer"]))
                    //{

                    //}
                    //else if (dataReader["role"].Equals(WebConfigurationManager.AppSettings["admin"]))
                    //{

                    //}
                    //else if (dataReader["role"].Equals(WebConfigurationManager.AppSettings["staff"]))
                    //{

                    //}
                }
                else
                {
                    Type type = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(type, "PopupScript"))
                    {
                        String cstext = "alert('Invalid username/password entered!');";
                        cs.RegisterStartupScript(type, "PopupScript", cstext, true);
                    }
                }
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
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