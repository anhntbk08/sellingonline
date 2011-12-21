using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Summary description for DisplayProduct
/// </summary>
public class DisplayProduct
{
    private HtmlGenericControl divMainDisplay;
    public DisplayProduct(HtmlGenericControl divMainDisplay)
    {
        this.divMainDisplay = divMainDisplay;

    }
    public void Display(DataSet datasetProductDisplay, bool isDisplayPromotion, bool isAdmin = false, string currentpath = "")
    {
        int i, j, temp, numberRow;
        float x;
        float y;
        int[] a;
        a = new int[1000];
        DataRow dataRowI, dataRowJ;
        numberRow = datasetProductDisplay.Tables[0].Rows.Count;

        for (i = 0; i < datasetProductDisplay.Tables[0].Rows.Count; i++)
        {
            a[i] = i;
        }
        for (i = 0; i < datasetProductDisplay.Tables[0].Rows.Count - 1; i++)
        {

            dataRowI = datasetProductDisplay.Tables[0].Rows[i];
            if (isDisplayPromotion)
            {
                x = (float)Convert.ToInt32(dataRowI[datasetProductDisplay.Tables[0].Columns[9]]) / (float)Convert.ToInt32(dataRowI[datasetProductDisplay.Tables[0].Columns[7]]);
            }
            else
            {
                x = (float)Convert.ToInt32(dataRowI[datasetProductDisplay.Tables[0].Columns[6]]) / (float)Convert.ToInt32(dataRowI[datasetProductDisplay.Tables[0].Columns[5]]);
            }
            for (j = i + 1; j < datasetProductDisplay.Tables[0].Rows.Count; j++)
            {
                dataRowJ = datasetProductDisplay.Tables[0].Rows[j];
                if (isDisplayPromotion)
                {
                    y = (float)Convert.ToInt32(dataRowJ[datasetProductDisplay.Tables[0].Columns[9]]) / (float)Convert.ToInt32(dataRowJ[datasetProductDisplay.Tables[0].Columns[7]]);
                }
                else
                {
                    y = (float)Convert.ToInt32(dataRowJ[datasetProductDisplay.Tables[0].Columns[6]]) / (float)Convert.ToInt32(dataRowJ[datasetProductDisplay.Tables[0].Columns[5]]);
                }
                if (y < x)
                {
                    // dataRowTemp
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;

                }

            }


        }
        if (!isAdmin)
        {
            divMainDisplay.InnerHtml += "<ul class='list-product'>";
            for (i = 0; i < 2; i++)
            {
                DataRow dataRow = datasetProductDisplay.Tables[0].Rows[a[i]];
                string strProductName = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
                string ImagePath = dataRow[datasetProductDisplay.Tables[0].Columns[3]].ToString();

                x = (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[9]]) / (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[7]]);
                string productcode = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
                
                if (i % 2 == 0)
                {
                    if (i < datasetProductDisplay.Tables[0].Rows.Count - 1)
                    {
                        divMainDisplay.InnerHtml += "<li style = 'margin-left:10px; margin-right:10px; '>";
                        divMainDisplay.InnerHtml += "<div class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div  >" +
                                "Khuyến mai" + x + "%" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='#' style = 'display:block'> Đặt hàng</a></div>" +
                            "</div>" +
                            "</div>";

                    }
                    else
                    {
                        divMainDisplay.InnerHtml += "<li style = 'margin-left:10px; margin-right:10px; '><div  class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div >" +
                                "Khuyến mai : " + x + "%  :" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                               "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='#' style = 'display:block'> Đặt hàng</a></div>" +
                            "</div>" +
                            "</div>";
                        divMainDisplay.InnerHtml += "</li>";
                    }

                }
                else
                {

                    divMainDisplay.InnerHtml += "<div class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div >" +
                                "Khuyến mai  " + x + "%" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='#' style = 'display:block'> Đặt hàng</a></div>" +
                            "</div>" +
                            "</div></li>";

                }
            }
            divMainDisplay.InnerHtml += "</ul>";
        }
        else
        {
            divMainDisplay.InnerHtml += "<ul class='list-product'>";
            for (i = 0; i < numberRow; i++)
            {
                DataRow dataRow = datasetProductDisplay.Tables[0].Rows[a[i]];
                string strProductName = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
                string ImagePath = dataRow[datasetProductDisplay.Tables[0].Columns[3]].ToString();
                string ID = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
                x = (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[9]]) / (float)Convert.ToInt32(dataRow[datasetProductDisplay.Tables[0].Columns[7]]);
                string productcode = dataRow[datasetProductDisplay.Tables[0].Columns[0]].ToString();
                if (i % 2 == 0)
                {
                    if (i < datasetProductDisplay.Tables[0].Rows.Count - 1)
                    {
                        divMainDisplay.InnerHtml += "<li  style = 'margin-left:10px; margin-right:10px; '>";
                        divMainDisplay.InnerHtml += "<div class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div  >" +
                                "Khuyến mai" + x + "%" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='UpdateProductAdmin.aspx?param=" + ID + "' style = 'display:block'> UPDATE</a></div>" +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='?" + currentpath + "&delete=" + ID + "' style = 'display:block'> DELETE</a></div>" +

                            "</div>" +
                            "</div>";
                    }
                    else
                    {
                        divMainDisplay.InnerHtml += "<li style = 'margin-left:10px; margin-right:10px; '><div  class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div >" +
                                "Khuyến mai : " + x + "%  :" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                               "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='UpdateProductAdmin.aspx?param=" + ID + "' style = 'display:block'> UPDATE</a></div>" +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='?" + currentpath + "&delete=" + ID + "' style = 'display:block'> DELETE</a></div>" +
                            "</div>" +
                            "</div>";
                        divMainDisplay.InnerHtml += "</li>";
                    }

                }
                else
                {

                    divMainDisplay.InnerHtml += "<div class ='productcell' style = 'float:left;'>" +
                            "<a href = 'DisplayProductPage.aspx?Productcode=" + productcode + "'><img class = 'producting' src=" + ImagePath + " alt='HTML tutorial' width = 100px height = 100px style ='float:left' hiddenId=" + productcode + "/></a>" +
                            "<div >" +
                                "Khuyến mai  " + x + "%" + dataRow[datasetProductDisplay.Tables[0].Columns[7]].ToString() +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='UpdateProductAdmin.aspx?param=" + ID + "' style = 'display:block'> UPDATE</a></div>" +
                                "<div class = 'order' keyproduct=" + productcode + "><a class='ordertext' href ='?" + currentpath + "&delete=" + ID + "' style = 'display:block'> DELETE</a></div>" +

                            "</div>" +
                            "</div></li>";
                }

            }
            divMainDisplay.InnerHtml += "<ul>";
        }
    }
}