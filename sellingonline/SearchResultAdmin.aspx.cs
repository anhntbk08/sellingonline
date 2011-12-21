using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
using System.Data.SqlClient;
using System.Configuration;

public partial class SearchResultAdmin : System.Web.UI.Page
{
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

                SqlCommand cmd = new SqlCommand("DELETE FROM Product  WHERE Product.Id = '" + ID + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
           
            String strSearchBy, strSearchKeyWord;
            strSearchBy = Request.QueryString["searchby"];
            strSearchKeyWord = Request.QueryString["searchkeyword"];
            string strParam;
            strParam = "searchby=" + strSearchBy + "&searchkeyword=" + strSearchKeyWord;
            if (strSearchBy == "ProductName")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByProductName(strSearchKeyWord, datasetDisplayProduct);
                DisplayProduct displayProduct = new DisplayProduct(divSearchPhoneDisplay);
                displayProduct.Display(datasetDisplayProduct, true, true,strParam);
                searchProduct.CloseDataBase();
            }
            
        }
        else 
        {       
            Response.Redirect("AdminLogin.aspx");
        }
    }
}