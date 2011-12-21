using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        textUserName.Text = "admin";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string strUserName = textUserName.Text;
        string strPassword = textPassword.Text;
        if (strUserName == "admin" && strPassword == "admin")
        {
            Session["admin"] = "admin";
            Response.Redirect("AdminPage.aspx");

        }
        else
        {
            Session["admin"] = null;
            //  Response.Redirect ("AdminLogin.aspx");
        }
    }
}