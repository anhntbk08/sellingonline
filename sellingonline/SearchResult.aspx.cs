using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
public partial class SearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string parameter = Request.QueryString["param"];
        string lowPrice = Request.QueryString["lowprice"];
        string hightPrice = Request.QueryString["highprice"];
        SearchProduct searchProduct = new SearchProduct();
        DataSet dataset = new DataSet();
        searchProduct.SearchProductByCostAndCatogoryOrBrand(Convert.ToInt32(lowPrice), Convert.ToInt32(hightPrice), parameter, dataset);
        searchProduct.CloseDataBase();
        DisplayProduct disPlayProduct = new DisplayProduct(divSearchDisplay);
        disPlayProduct.Display(dataset, true, false);
    }
}