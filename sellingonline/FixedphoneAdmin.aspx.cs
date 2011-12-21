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

public partial class FixedphoneAdmin : System.Web.UI.Page
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
            if (Request.QueryString["param"] == "null")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, null, 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
                string url = Request.Url.ToString();
                int index = url.IndexOf('?');
                string strParam = url.Substring(index+1);

                displayProduct.Display(datasetDisplayProduct, true, true, "param=null");
                searchProduct.CloseDataBase();
            }
            
            if (Request.QueryString["param"] == "Panasonic")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Panasonic", 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
                displayProduct.Display(datasetDisplayProduct, true, true,"param=Panasonic");
                searchProduct.CloseDataBase();

            }
            if (Request.QueryString["param"] == "AT&T")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "AT&T", 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
                displayProduct.Display(datasetDisplayProduct, true, true,"param=AT&T");
                searchProduct.CloseDataBase();

            }
            if (Request.QueryString["param"] == "Siements")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Siements", 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
                displayProduct.Display(datasetDisplayProduct, true, true,"param=Siements");
                searchProduct.CloseDataBase();

            }
            if (Request.QueryString["param"] == "Uniden")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Uniden", 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);

                displayProduct.Display(datasetDisplayProduct, true, true,"param=Uniden");

                searchProduct.CloseDataBase();

            }
            if (Request.QueryString["param"] == "Nippon")
            {
                DataSet datasetDisplayProduct = new DataSet();
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Nippon", 2);
                DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);

                displayProduct.Display(datasetDisplayProduct, true, true,"param=Nippon");

                searchProduct.CloseDataBase();

            }

        }
        else 
        {
            Response.Redirect("AdminLogin.aspx");
        }

    }
}