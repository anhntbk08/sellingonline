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
    private SqlDataAdapter sqlAdapter;
    private SqlCommand sqlCommand;
    private string isReload = "false";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (isReload == "false")
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _1 dataset = new _1();
            sqlCommand = new SqlCommand("SELECT * FROM Recipe", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);

            ReportDocument myReport = new ReportDocument();
            myReport.Load(Server.MapPath("CrystalReport.rpt"));
            myReport.SetDataSource(dataset.Tables[1]);
            CrystalReportViewer1.ReportSource = myReport;
            CrystalReportViewer1.RefreshReport();
            isReload = "true";
        }

        
    }

    protected void RenderReport(object sender, EventArgs e)
    {
        
        DateTime MyDateTime = Picker1.DateTime;;
        
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        _1 dataset = new _1();
        sqlCommand = new SqlCommand("SELECT * FROM recipe Where DateCreat = '" + MyDateTime+"'", connection);
        //sqlCommand = new SqlCommand("SELECT * FROM Product", connection);
        sqlAdapter = new SqlDataAdapter(sqlCommand);
        sqlAdapter.Fill(dataset);
        ReportDocument myReport = new ReportDocument();        
        myReport.Load(Server.MapPath("CrystalReport.rpt"));
        myReport.SetDataSource(dataset.Tables[1]);
        CrystalReportViewer1.ReportSource = myReport;
        
    }
}