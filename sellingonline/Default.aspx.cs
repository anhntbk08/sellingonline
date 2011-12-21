using System;
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

public partial class _Default : System.Web.UI.Page
{
    private SqlConnection connection;
    private SqlDataAdapter sqlAdapter;
    private SqlCommand sqlCommand;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet1 dataset = new DataSet1();
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        sqlCommand = new SqlCommand("SELECT Id FROM Product", connection);
        sqlAdapter = new SqlDataAdapter(sqlCommand);
        sqlAdapter.Fill(dataset);
        int r = dataset.Tables[2].Rows.Count;

    }
}