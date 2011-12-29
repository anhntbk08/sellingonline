using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Deletenews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strId = Request.QueryString["Id"];
        int Id = Convert.ToInt32(strId);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM News WHERE Id = '"+Id+"'", connection);
        cmd.ExecuteNonQuery();
        connection.Close();
    }
}