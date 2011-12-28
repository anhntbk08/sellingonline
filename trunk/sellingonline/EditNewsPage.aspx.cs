using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;

public partial class EditNewsPage : System.Web.UI.Page
{
    private SqlConnection connection;
    private SqlDataAdapter sqlAdapter;
    private SqlCommand sqlCommand;
    private DataSet datasetProductDisplay;
    protected void Page_Load(object sender, EventArgs e)
    {
        //connect to database
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        // fill it to dataset
        sqlCommand = new SqlCommand("SELECT * FROM News", connection);
        sqlAdapter = new SqlDataAdapter(sqlCommand);
        datasetProductDisplay = new DataSet();
        sqlAdapter.Fill(datasetProductDisplay);

        int numberRow = datasetProductDisplay.Tables[0].Rows.Count;

        // show it in page
        divMainDisplay.InnerHtml += "<ul class='list-product'>";
        for (var i = 0; i < numberRow ; i++)
        {
            DataRow dataRow = datasetProductDisplay.Tables[0].Rows[i];
            string strProductName = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
            string ImagePath = dataRow[datasetProductDisplay.Tables[0].Columns[3]].ToString();

            divMainDisplay.InnerHtml += "<li style = 'margin-left:10px; margin-right:10px;'>";
            divMainDisplay.InnerHtml += "<a href ='News.aspx?Id=" + dataRow[datasetProductDisplay.Tables[0].Columns[4]].ToString() + "'> " + dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString() + "</a>";
            divMainDisplay.InnerHtml += "<a href = 'Updatenews.aspx?Id=" + dataRow[datasetProductDisplay.Tables[0].Columns[4]].ToString() + "' class='news-btn'> Edit</a> <a href = 'DeleteNews.aspx?Id=" + dataRow[datasetProductDisplay.Tables[0].Columns[4]].ToString() + "' class='news-btn'>Delete</a></li>";
            
        }

        divMainDisplay.InnerHtml += "</ul>";
    
        }
    
}
