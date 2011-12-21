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
public partial class _Default : System.Web.UI.Page
{
    DataSet datasetProductDisplay = new DataSet();
    protected string str ="Tuấn Em";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Doc co so du lieu va liet ke tat ca cac san pham
        SearchProduct searchProduct = new SearchProduct();
        searchProduct.SearchAll(datasetProductDisplay  );
        DisplayProduct displayProduct = new DisplayProduct(ProductResult);
        displayProduct.Display(datasetProductDisplay , false);
        searchProduct.CloseDataBase();
    }

   
}
