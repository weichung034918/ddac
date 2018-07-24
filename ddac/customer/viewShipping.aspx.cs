﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ddac.customer
{
    public partial class viewShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].Equals(WebConfigurationManager.AppSettings["customer"]))
            {
                Response.Redirect("Account/Login");
            }
            emptyTable.Visible = recordTable.Rows.Count.Equals(0);           
        }
    }
}