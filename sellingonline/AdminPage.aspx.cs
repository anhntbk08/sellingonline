using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using App_Code;
using System.Configuration;
using System.Data.SqlClient;
public partial class AdminPage : System.Web.UI.Page
{
    DataSet datasetProductDisplay = new DataSet();
    protected string str = "Tuấn Em";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] != null)
        {
            string ProductId;
            int ID;
            ProductId = Request.QueryString["delete"];
            if (ProductId != null)
            {
                ID = Convert.ToInt32(ProductId);
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM SellProduct  WHERE ProductId = '" + ID + "'", connection);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM Product  WHERE Product.Id = '" + ID + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            //Doc co so du lieu va liet ke tat ca cac san pham
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByHotProduct(datasetProductDisplay, (float)0.2);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetProductDisplay, true, true);
            searchProduct.CloseDataBase();
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");

        }
    }

}