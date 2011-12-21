using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
using System.IO;
public partial class DisplayProductPage : System.Web.UI.Page
{
    DataSet datasetProductDisplay = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchProduct searchProduct = new SearchProduct();
        string code = Request.QueryString["Productcode"];
        searchProduct.SearchProductInfoDetailById(code, datasetProductDisplay);
        DataRow dataRow = datasetProductDisplay.Tables[0].Rows[0];
        string ImagePath = dataRow["ImageLink"].ToString();
        string productcode = dataRow["id"].ToString();
        string name = dataRow["ProductName"].ToString();
        int conhang = Convert.ToInt32(dataRow["Available"].ToString());
        string s1 = dataRow["PromotionPrice"].ToString();
        string s2 = dataRow["Price"].ToString();
        float x = (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[9]]) / (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[7]]);
        string available = "";
        if (conhang > 0)
        {
            available = "còn hàng";
        }
        else
        {
            available = "hết hàng";
        }
        //ProductHeader.InnerHtml ="";

        ProductHeader.InnerHtml += "<div class='ProductHeader' ><img id='z' alt='hihi' src ='" + ImagePath + "' />";
        ProductHeader.InnerHtml += "<div id='ProductDiscription' class='ProductHeader' >";

        ProductHeader.InnerHtml += "<h1 class='product_title'>" + name + "<h1/>";
        ProductHeader.InnerHtml += "<h3 class='product_price'>  <span class = 'infotitle'>Khuyến mãi </span> <span class ='promtion_text1'>" + x + "%" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() + " VNĐ </span><h3/>";
        ProductHeader.InnerHtml += "<h3 class='product_addition'><span class = 'infotitle'> Thông tin thêm </span>: <span class ='promtion_text'> " + dataRow[datasetProductDisplay.Tables[0].Columns[11]].ToString() + "</span><h3/>";
        ProductHeader.InnerHtml += "<h3 class='product_addition'> <span class = 'infotitle'> Bảo hành </span>  : <span class ='promtion_text'> " + dataRow[datasetProductDisplay.Tables[0].Columns[12]].ToString() + "</span>  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp& <span class = 'infotitle'>Kho :</span> <span class ='promtion_text'>" + available + " </span><h3/> </div>";
        ProductHeader.InnerHtml += "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='#' style = 'display:block'> Đặt hàng</a></div>";
        ProductHeader.InnerHtml += "<a href='3dResource/model3d_" + code + ".html?iframe=true&width=400&height=400' rel='prettyPhoto[iframe]' >Xem sản phẩm 3d</a>";

        /*
         * Phần chi tiết sản phẩm
         */
        // Camera
        if (!dataRow["camera"].ToString().Equals(""))
            tdCamera.InnerHtml = dataRow["camera"].ToString();
        else
            tdCamera.InnerHtml = "Không hỗ trợ";
        // 3G
        if (dataRow["3G"].ToString().Equals("True"))
            td3g.InnerHtml = "Có hỗ trợ";
        else
            td3g.InnerHtml = "Không hỗ trợ";

        // Phiên bản Java
        if (!dataRow["Java"].ToString().Equals(""))
            tdJava.InnerHtml = dataRow["Java"].ToString();
        else
            tdJava.InnerHtml = "Không hỗ trợ";

        // Bluetooth
        if (dataRow["bluetooth"].ToString().Equals("True"))
            tdBluetooth.InnerHtml = "Có hỗ trợ";
        else
            tdBluetooth.InnerHtml = "Không hỗ trợ";

        // Chip
        if (!dataRow["chip"].ToString().Equals(""))
            tdChip.InnerHtml = dataRow["chip"].ToString();
        else
            tdChip.InnerHtml = "Chưa có thông tin cập nhật";



        // Bộ nhớ ngoài
        if (!dataRow["FlashMemory"].ToString().Equals(""))
            tdFlashMemory.InnerHtml = dataRow["FlashMemory"].ToString();
        else
            tdFlashMemory.InnerHtml = "Không hỗ trợ";

        // bộ nhớ trong

        //  nhạc 
        if (!dataRow["music"].ToString().Equals(""))
            tdMusic.InnerHtml = dataRow["music"].ToString();
        else
            tdMusic.InnerHtml = "Đơn âm";

        // Hệ điều hành
        if (!dataRow["OS"].ToString().Equals(""))
            tdOs.InnerHtml = dataRow["OS"].ToString();
        else
            tdOs.InnerHtml = "Chưa có thông tin";
        //pin
        if (!dataRow["battery"].ToString().Equals(""))
            tdPin.InnerHtml = dataRow["Battery"].ToString();
        else
            tdPin.InnerHtml = "Chưa có thông tin";

        // định dạng quay camera hỗ trợ

        //tivi

        if (dataRow["Tivi"].ToString().Equals("True"))
            tdTivi.InnerHtml = "Có hỗ trợ";
        else
            tdTivi.InnerHtml = "Không hỗ trợ";
        // video call
        if (dataRow["VideoCall"].ToString().Equals("True"))
            tdVideoCall.InnerHtml = "Có hỗ trợ";
        else
            tdVideoCall.InnerHtml = "Không hỗ trợ";
        //wifi
        if (dataRow["WiFi"].ToString().Equals("True"))
            tdWifi.InnerHtml = "Có hỗ trợ";
        else
            tdWifi.InnerHtml = "Không hỗ trợ";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }
}