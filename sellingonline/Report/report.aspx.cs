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
using CrystalDecisions.CrystalReports.Engine;
public partial class Report_report : System.Web.UI.Page
{
    private SqlConnection connection;
    private SqlDataAdapter sqlAdapter1, sqlAdapter2, sqlAdapter3;
    private SqlCommand sqlCommand;
    private String sql1, sql2, sql3;
    private string isReload = "false";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (isReload == "false")
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            
            sql1 = "SELECT  SellProduct.Quantity , Product.Price FROM Recipe, SellProduct, Product WHERE Recipe.Id = SellProduct.RecipeId AND SellProduct.ProductId = Product.Id";
            sqlCommand = new SqlCommand(sql1, connection);
            sqlAdapter1 = new SqlDataAdapter(sqlCommand);
            DataSet1 dataset = new DataSet1();
            sqlAdapter1.Fill(dataset,"Sum");
            sql2 = "SELECT  Product.ProductName , SUM(SellProduct.Quantity) FROM Recipe, SellProduct, Product WHERE Recipe.Id = SellProduct.RecipeId AND SellProduct.ProductId = Product.Id AND Recipe.DateCreat = '11/11/1900' GROUP BY Product.ProductName";
            sqlCommand.CommandText = sql2;
            sqlAdapter2 = new SqlDataAdapter(sqlCommand);
            sqlAdapter2.Fill(dataset, "Top");

            sql3 = "SELECT Recipe.CustomerName, SUM(SellProduct.Quantity * Product.Price) FROM Recipe INNER JOIN SellProduct ON Recipe.Id = SellProduct.RecipeId INNER JOIN Product ON SellProduct.ProductId = Product.Id WHERE (Recipe.DateCreat = '11/11/1900') GROUP BY Recipe.CustomerName";
            sqlCommand.CommandText = sql3;
            sqlAdapter3 = new SqlDataAdapter(sqlCommand);
            sqlAdapter3.Fill(dataset, "Customer");
            
            ReportDocument myReport = new ReportDocument();
            myReport.Load(Server.MapPath("CrystalReport.rpt"));
            myReport.SetDataSource(dataset);
            CrystalReportViewer1.ReportSource = myReport;
            CrystalReportViewer1.RefreshReport();
           
            isReload = "true";
        }

        
    }

    protected void RenderReport(object sender, EventArgs e)
    {
        
        DateTime MyDateTime = Picker1.DateTime;;
        DateTime MyDateTime2 = Picker2.DateTime;;
        
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet1 dataset = new DataSet1();
        sql1 = "SELECT  SellProduct.Quantity , Product.Price , sellProduct.RecipeId FROM Recipe, SellProduct, Product WHERE Recipe.Id = SellProduct.RecipeId AND SellProduct.ProductId = Product.Id AND Recipe.DateCreat BETWEEN'"+MyDateTime+"' AND '"+MyDateTime2+"'";
        
        sqlCommand = new SqlCommand(sql1, connection);
        //sqlCommand = new SqlCommand("SELECT * FROM Product", connection);
        sqlAdapter1 = new SqlDataAdapter(sqlCommand);
        sqlAdapter1.Fill(dataset, "Sum");
       
        sql2 = "SELECT TOP(10) Product.ProductName, SUM(SellProduct.Quantity) AS Total, Product.Brand FROM Product INNER JOIN SellProduct ON Product.Id = SellProduct.ProductId INNER JOIN Recipe ON SellProduct.RecipeId = Recipe.Id WHERE (Recipe.DateCreat BETWEEN'" + MyDateTime + "' AND '" + MyDateTime2 + "') GROUP BY Product.ProductName, Product.Brand ORDER BY Total DESC";
        sqlCommand.CommandText = sql2;
        sqlAdapter2 = new SqlDataAdapter(sqlCommand);
        sqlAdapter2.Fill(dataset, "Top");

        sql3 = "SELECT TOP (3) Recipe.CustomerName, Recipe.PhoneNumber, SUM(SellProduct.Quantity * Product.Price) AS Money FROM Recipe INNER JOIN SellProduct ON Recipe.Id = SellProduct.RecipeId INNER JOIN Product ON SellProduct.ProductId = Product.Id WHERE (Recipe.DateCreat BETWEEN'" + MyDateTime + "' AND '" + MyDateTime2 + "') GROUP BY Recipe.PhoneNumber, Recipe.CustomerName ORDER BY Money DESC";
        sqlCommand.CommandText = sql3;
        sqlAdapter3 = new SqlDataAdapter(sqlCommand);
        sqlAdapter3.Fill(dataset, "Customer");
        connection.Close();
        
        int i;
        int sum1 = 0;
        int sum2 = 0;
        DataRow dataRow;
        for (i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            dataRow = dataset.Tables[0].Rows[i];
            sum1 = sum1 + Convert.ToInt32(dataRow[0]) * Convert.ToInt32(dataRow[1]);
            sum2 = sum2 + Convert.ToInt32(dataRow[0]);
        }
        ReportDocument myReport = new ReportDocument();
        myReport.Load(Server.MapPath("CrystalReport.rpt"));
        TextObject t1 = (TextObject)myReport.ReportDefinition.ReportObjects["Text11"];
        t1.Text = sum1.ToString();
        TextObject t2 = (TextObject)myReport.ReportDefinition.ReportObjects["Text2"];
        t2.Text = MyDateTime.ToString("dd/MM/yyyy");
        TextObject t3 = (TextObject)myReport.ReportDefinition.ReportObjects["Text5"];
        t3.Text = MyDateTime2.ToString("dd/MM/yyyy");
        TextObject t4 = (TextObject)myReport.ReportDefinition.ReportObjects["Text7"];
        t4.Text = sum2.ToString();
        TextObject t5 = (TextObject)myReport.ReportDefinition.ReportObjects["Text9"];
        t5.Text = dataset.Tables[0].Rows.Count.ToString();
                       
        myReport.SetDataSource(dataset);           
               
        CrystalReportViewer1.ReportSource = myReport;
        
        
    }
}