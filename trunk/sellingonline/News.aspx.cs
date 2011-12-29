using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strId = Request.QueryString["Id"];
        int Id = Convert.ToInt32(strId);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet dataset = new DataSet();
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM News Where Id = '" + Id + "'", connection);
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
        sqlAdapter.Fill(dataset);
        DataRow dataRow = dataset.Tables[0].Rows[0];
        string mainContent = dataRow["contentmain"].ToString();
        string htmlMainContent = HttpUtility.HtmlDecode(mainContent);
        Response.Write(htmlMainContent);

    }
}