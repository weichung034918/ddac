using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ddac.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Configuration;

namespace ddac.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = "  INSERT INTO users (username,password,email,contact_no,name,role) VALUES(@username,@password,@email,@contact_no,@name,@role);";
            SqlCommand registerUser = new SqlCommand(sql, con);
            registerUser.Parameters.Add("@username", SqlDbType.NVarChar);
            registerUser.Parameters["@username"].Value = Username.Text;
            registerUser.Parameters.Add("@password", SqlDbType.NVarChar);
            registerUser.Parameters["@password"].Value = Password.Text;
            registerUser.Parameters.Add("@email", SqlDbType.NVarChar);
            registerUser.Parameters["@email"].Value = Email.Text;
            registerUser.Parameters.Add("@contact_no", SqlDbType.NVarChar);
            registerUser.Parameters["@contact_no"].Value = ContactNo.Text;
            registerUser.Parameters.Add("@name", SqlDbType.VarChar);
            registerUser.Parameters["@name"].Value = Name.Text;
            registerUser.Parameters.Add("@role", SqlDbType.VarChar);
            registerUser.Parameters["@role"].Value = WebConfigurationManager.AppSettings["customer"];
            con.Open();
            int s = registerUser.ExecuteNonQuery();
            con.Close();
            if (s != 0)
            {
                Response.Redirect("/Account/Login",false);
            }
        }
    }
}