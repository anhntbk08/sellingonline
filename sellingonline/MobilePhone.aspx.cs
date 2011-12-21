using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
public partial class MobilePhone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param"] == "null")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, null, 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "Nokia")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Nokia", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "Samsung")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Samsung", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "LG")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "LG", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "Apple")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Apple", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }

        if (Request.QueryString["param"] == "SonyErricson")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "SonyErricson", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "QMobile")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "QMobile", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "FMobile")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "FMobile", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "HTC")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "HTC", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "Blackberry")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "Blackberry", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }
        if (Request.QueryString["param"] == "FPT")
        {
            DataSet datasetDisplayProduct = new DataSet();
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.SearchByCategoryAndBrand(datasetDisplayProduct, "FPT", 1);
            DisplayProduct displayProduct = new DisplayProduct(divMobilePhoneDisplay);
            displayProduct.Display(datasetDisplayProduct, true);
            searchProduct.CloseDataBase();
        }





    }
}