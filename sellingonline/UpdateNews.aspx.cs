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

public partial class UpdateNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strId = Request.QueryString["Id"];
            int Id = Convert.ToInt32(strId);
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataSet dataset = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM News Where Id = '"+Id+"'", connection);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
            DataRow dataRow = dataset.Tables[0].Rows[0];
            string strTitle = dataRow["Title"].ToString();
            string strMainContent = dataRow["ContentMain"].ToString();
            string strAuthor = dataRow["Author"].ToString();
            string strDatePost = dataRow["DatePost"].ToString();
            textTitle.Text = strTitle;
            textMainContent.Text = strMainContent;
            textAuthor.Text = strAuthor;
            textDatePost.Text = strDatePost;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strMainContent = HttpUtility.HtmlDecode(textMainContent.Text);
        string strId = Request.QueryString["Id"];
        int Id = Convert.ToInt32(strId);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("UPDATE  News Set Title = '" + textTitle.Text + "' , ContentMain = '" +strMainContent+ "' , Author = '" + textAuthor.Text + "' , DatePost = '" + textDatePost.Text + "' WHERE Id = '"+Id+"'", connection);
        cmd.ExecuteNonQuery();
        connection.Close();
    }
}