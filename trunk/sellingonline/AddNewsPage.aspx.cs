using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AddNewsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO News (Title , ContentMain ,Author ,DatePost ) Values ('" + textTitle.Text + "' , '" + textMainContent.Text + "' ,'" + textAuthor.Text + "' , '" + textDatePost.Text + "')", connection);
        cmd.ExecuteNonQuery();
        connection.Close();
    }
}