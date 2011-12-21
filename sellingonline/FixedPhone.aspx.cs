using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
public partial class FixedPhone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param"] == "null")
        {
            DataSet datasetDisplayProduct = new DataSet();    
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, null, 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "Panasonic")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Panasonic", 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
 
        }
        if (Request.QueryString["param"] == "AT&T")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "AT&T", 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();

        }
        if (Request.QueryString["param"] == "Siements")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Siements", 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();

        }
        if (Request.QueryString["param"] == "Uniden")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Uniden", 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();

        }
        if (Request.QueryString["param"] == "Nippon")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Nippon", 2);
            DisplayProduct displayProduct = new DisplayProduct(divFixedPhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();

        }
    }
}