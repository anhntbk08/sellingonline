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
    DataSet datasetProductInfo = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchProduct searchProduct = new SearchProduct();
        string code = Request.QueryString["Productcode"];
        searchProduct.SearchProductInfoById(code, datasetProductDisplay);
        searchProduct.SearchProductInfoDetailById(code, datasetProductInfo);
        DataRow dataRow = datasetProductDisplay.Tables[0].Rows[0];
        DataRow dataRowInfo = datasetProductInfo.Tables[0].Rows[0];
        string ImagePath = dataRow[datasetProductDisplay.Tables[0].Columns[3]].ToString();
        string productcode = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
        string name = dataRow[datasetProductDisplay.Tables[0].Columns[2]].ToString();
        int conhang = Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[6]]);
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
        ProductHeader.InnerHtml += "<div class = 'order' keyproduct="+ productcode+"><a class='ordertext' href ='#' style = 'display:block'> Đặt hàng</a></div>" ;

        /*
         * Phần chi tiết sản phẩm
         */
        // Camera
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[6]].ToString().Equals(""))
            tdCamera.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[6]].ToString();
        else
            tdCamera.InnerHtml = "Không hỗ trợ";
        // 3G
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[13]].ToString().Equals("1"))
            td3g.InnerHtml = "Có hỗ trợ";
        else
            td3g.InnerHtml = "Không hỗ trợ";

        // Phiên bản Java
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[13]].ToString().Equals(""))
            tdJava.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[13]].ToString();
        else
            tdJava.InnerHtml = "Không hỗ trợ";

        // Bluetooth
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[14]].ToString().Equals("1"))
            tdBluetooth.InnerHtml = "Có hỗ trợ";
        else
            tdBluetooth.InnerHtml = "Không hỗ trợ";

        // Chip
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[21]].ToString().Equals(""))
            tdChip.InnerHtml = dataRow[datasetProductInfo.Tables[0].Columns[21]].ToString();
        else
            tdChip.InnerHtml = "Chưa có thông tin cập nhật";

        // Chuẩn định dạng video
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[8]].ToString().Equals("1"))
            tdFilm.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[8]].ToString();
        else
            tdFilm.InnerHtml = "Không hỗ trợ";

        // Bộ nhớ ngoài
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[11]].ToString().Equals(""))
            tdFlashMemory.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[11]].ToString();
        else
            tdFlashMemory.InnerHtml = "Không hỗ trợ";

        //Dải tần Fm
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[9]].ToString().Equals(""))
            tdFm.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[9]].ToString();
        else
            tdFm.InnerHtml = "Không hỗ trợ";

        //Tần số : CDMA , ...
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[22]].ToString().Equals(""))
            tdFrequence.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[22]].ToString();
        else
            tdFrequence.InnerHtml = "Chưa có thông tin cập nhật";

        // GPU
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[23]].ToString().Equals(""))
            tdGpu.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[23]].ToString();
        else
            tdGpu.InnerHtml = "Không hỗ trợ";

        // bộ nhớ trong
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[10]].ToString().Equals(""))
            tdInnerMemory.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[10]].ToString();
        else
            tdInnerMemory.InnerHtml = "Chưa có thông tin";

        //  nhạc 
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[7]].ToString().Equals(""))
            tdMusic.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[7]].ToString();
        else
            tdMusic.InnerHtml = "Đơn âm";

        // Hệ điều hành
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[18]].ToString().Equals(""))
            tdOs.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[18]].ToString();
        else
            tdOs.InnerHtml = "Chưa có thông tin";
        //pin
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[17]].ToString().Equals(""))
            tdPin.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[17]].ToString();
        else
            tdPin.InnerHtml = "Chưa có thông tin";

        // định dạng quay camera hỗ trợ
        if (!dataRowInfo[datasetProductInfo.Tables[0].Columns[24]].ToString().Equals(""))
            tdRecord.InnerHtml = dataRowInfo[datasetProductInfo.Tables[0].Columns[24]].ToString();
        else
            tdRecord.InnerHtml = "Không hỗ trợ";
        //tivi
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[25]].ToString().Equals("1"))
            tdTivi.InnerHtml = "Có hỗ trợ";
        else
            tdTivi.InnerHtml = "Không hỗ trợ";
        // video call
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[26]].ToString().Equals("1"))
            tdVideoCall.InnerHtml = "Có hỗ trợ";
        else
            tdVideoCall.InnerHtml = "Không hỗ trợ";
        //wifi
        if (dataRowInfo[datasetProductInfo.Tables[0].Columns[15]].ToString().Equals("1"))
            tdWifi.InnerHtml = "Có hỗ trợ";
        else
            tdWifi.InnerHtml = "Không hỗ trợ";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }
}