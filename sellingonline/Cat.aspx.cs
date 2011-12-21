using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using App_Code;
public partial class Cat : System.Web.UI.Page
{
    DataSet datasetProductDisplay = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie Productcode = Request.Cookies["ProductCode"];
        HttpCookie ProductNumber = Request.Cookies["ProductNumber"];
        HttpCookie ProductIndex = Request.Cookies["ProductIndex"];
        float sum = 0;
        int number = 0;


        if (Productcode.Value != null )
        {
            try
            {
                number = Int16.Parse(ProductNumber.Value);
            }
            catch (InvalidCastException act)
            {
            }

            string[] stringSeparators = new string[] { "%20" };
            string[] products = Productcode.Value.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] productsIndex = ProductIndex.Value.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int pos = 0;

            while (pos > 0) ;

            if (number == 0)
            {
                ProductTable.InnerHtml = "Qúy khách chưa chọn sản phẩm nào";
            }
            else
            {
                ProductTable.InnerHtml = "";
                ProductTable.InnerHtml += "<table id='ProductShow' style = 'border:1px solid black; border-collapse: separate; border-spacing: 2px;'>";
                ProductTable.InnerHtml += "<tr class = 'product' style = 'font-weight:bold;'>" +
                                            "<td class ='productshow'> Stt</td>" +
                                            "<td class ='productshow'> Tên sản phẩm </td>" +
                                            "<td class ='productshow'> Đơn giá</td>" +
                                            "<td class ='productshow'> Số lượng</td>" +
                                            "<td class ='productshow'> Thành tiền</td>" +
                                            "<td class ='productshow'><td>";
                for (int i = 0; i < products.Length; i++)
                {
                    products[i].Remove(products[i].Length - 1, 1);

                }

                SearchProduct searchProduct = new SearchProduct();
                for (int i = 0; i < products.Length; i++)
                {
                    searchProduct.SearchProductInfoById(products[i], datasetProductDisplay);
                    DataRow dataRow = datasetProductDisplay.Tables[0].Rows[i];
                    string strProductName = dataRow[datasetProductDisplay.Tables[0].Columns[2]].ToString();
                    float price = float.Parse(dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString());
                    sum += price * float.Parse(productsIndex[i]);

                    ProductTable.InnerHtml += "<tr class='product'>";
                    ProductTable.InnerHtml += "<td class ='productshow'>" + (i + 1) + "</td>";
                    ProductTable.InnerHtml += "<td class ='productshow'>" + strProductName + "</td>";
                    ProductTable.InnerHtml += "<td class ='productshow'>" + price + ".000 </td>";
                    ProductTable.InnerHtml += "<td class ='productshow'>" + "<input type ='text' class = 'numorder' value = '" + productsIndex[i] + "'>" + "</td>";
                    ProductTable.InnerHtml += "<td class ='productshow'>" + (price * float.Parse(productsIndex[i])) + ".000 </td>";
                    ProductTable.InnerHtml += "<td class ='productshow'> <input type='button' value ='Xóa' class = 'deleteCookie' id ='" + i + "' > </td>";
                    ProductTable.InnerHtml += "</tr>";
                    searchProduct.CloseDataBase();
                }
                ProductTable.InnerHtml += "<tr><td> Tổng số tiền trong hóa đơn "+ sum + "</td></tr>";
                ProductTable.InnerHtml += "<tr><td>  <a href ='RecipePage.aspx'> Đặt hàng</a> </td></tr>";
                ProductTable.InnerHtml += "</table>";


            }
        }
        else
        {
            ProductTable.InnerHtml = "Qúy khách chưa chọn sản phẩm nào";
        }

    }
}