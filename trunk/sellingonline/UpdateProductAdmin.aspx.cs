using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using App_Code;
public partial class UpdateProductAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param"] != null)
        {
            if (!IsPostBack)
            {
                String strId;
                int numberColum;
                int i;
                DataRow dataRow;
                strId = Request.QueryString["param"];
                DataSet dataset = new DataSet();
                int ID = Convert.ToInt32(strId);
                SearchProduct searchProduct = new SearchProduct();
                searchProduct.SearchByProductID(ID, dataset);
                numberColum = dataset.Tables[0].Columns.Count;
                dataRow = dataset.Tables[0].Rows[0];
                textCatogory.Text = dataRow[dataset.Tables[0].Columns[1]].ToString();
                textProductName.Text = dataRow[dataset.Tables[0].Columns[2]].ToString();
                textImageLink.Text = dataRow[dataset.Tables[0].Columns[3]].ToString();
                textSumInfo.Text = dataRow[dataset.Tables[0].Columns[4]].ToString();
                textQuantity.Text = dataRow[dataset.Tables[0].Columns[5]].ToString();
                textAvailable.Text = dataRow[dataset.Tables[0].Columns[6]].ToString();
                textPrice.Text = dataRow[dataset.Tables[0].Columns[7]].ToString();
                textBrand.Text = dataRow[dataset.Tables[0].Columns[8]].ToString();
                textPromotionPrice.Text = dataRow[dataset.Tables[0].Columns[9]].ToString();
                textDateIn.Text = dataRow[dataset.Tables[0].Columns[10]].ToString();
                textPromotionAddtion.Text = dataRow[dataset.Tables[0].Columns[11]].ToString();
                textWaranty.Text = dataRow[dataset.Tables[0].Columns[12]].ToString();
                textColor.Text = dataRow[dataset.Tables[0].Columns[13]].ToString();
               // TextBox14.Text = dataRow[dataset.Tables[0].Columns[16]].ToString();
                textScreen.Text = dataRow[dataset.Tables[0].Columns[14]].ToString();
                textModel.Text = dataRow[dataset.Tables[0].Columns[15]].ToString();
                textCamera.Text = dataRow[dataset.Tables[0].Columns[16]].ToString();
                textMusic.Text = dataRow[dataset.Tables[0].Columns[17]].ToString();
                textFilm.Text = dataRow[dataset.Tables[0].Columns[18]].ToString();
                textFm.Text = dataRow[dataset.Tables[0].Columns[19]].ToString();
                textMemory.Text = dataRow[dataset.Tables[0].Columns[20]].ToString();
                textFlashMemory.Text = dataRow[dataset.Tables[0].Columns[21]].ToString();
                textJava.Text = dataRow[dataset.Tables[0].Columns[22]].ToString();
                textBatterry.Text = dataRow[dataset.Tables[0].Columns[23]].ToString();
                textOS.Text = dataRow[dataset.Tables[0].Columns[24]].ToString();
                textSize.Text = dataRow[dataset.Tables[0].Columns[25]].ToString();
                textWeight.Text = dataRow[dataset.Tables[0].Columns[26]].ToString();
                textChip.Text = dataRow[dataset.Tables[0].Columns[27]].ToString();
              
               // TextBox30.Text = dataRow[dataset.Tables[0].Columns[36]].ToString();
               // TextBox31.Text = dataRow[dataset.Tables[0].Columns[37]].ToString();
                // TextBox31.Text = dataRow[dataset.Tables[0].Columns[35]].ToString();
                //if (dataRow[dataset.Tables[0].Columns[26]].ToString() == "1")
                //{
                //    CheckBox1.Checked = true;
                //}
                //if (dataRow[dataset.Tables[0].Columns[27]].ToString() == "1")
                //{
                //    CheckBox2.Checked = true;
                //}
                //if (dataRow[dataset.Tables[0].Columns[28]].ToString() == "1")
                //{
                //    CheckBox3.Checked = true;
                //}
                //if (dataRow[dataset.Tables[0].Columns[29]].ToString() == "1")
                //{
                //    CheckBox4.Checked = true;
                //}
                //if (dataRow[dataset.Tables[0].Columns[38]].ToString() == "1")
                //{
                //    CheckBox4.Checked = true;
                //}
                //if (dataRow[dataset.Tables[0].Columns[39]].ToString() == "1")
                //{
                //    CheckBox4.Checked = true;
                //}



            }
            else
            {
                if (Request.QueryString["param1"] != "add")
                { 
                    
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["param"] != null)
        {
            string strId = Request.QueryString["param"];
            int ID = Convert.ToInt32(strId);
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product SET CatogoryID = '" + textCatogory.Text + "', ProductName = '" + textProductName.Text + "', ImageLink = '" + textImageLink.Text + "', SumInfo = '" + textSumInfo.Text + "', Quantity = '" + textQuantity.Text + "', Available = '" + textAvailable.Text + "', Price = '" + textPrice.Text + "' ,  Brand = '" + textBrand.Text + "' , PromotionPrice = '" + textPromotionPrice.Text + "' , DateIn = '" + textDateIn.Text + "' , PromotionAddition = '" + textPromotionAddtion.Text + "' , Warranty = '" + textWaranty.Text + "', Color = '" + textColor.Text + "', Screen = '" + textScreen + "' , Model = '" + textModel.Text + "' , Camera = '" + textCamera.Text + "' , Music = '" + textMusic.Text + "', Film = '" + textFilm.Text + "',Fm = '" + textFm.Text + "',Memory ='" + textMemory.Text + "',FlashMemory = '" + textFlashMemory.Text + "',Java = '" + textJava.Text + "' , Battery = '" + textBatterry.Text + "',OS = '" + textOS.Text + "' ,Size = '" + textSize.Text + "' , Weight = '" + textWeight.Text + "' , Chip = '" + textChip.Text + "'  WHERE Product.ID = '" + ID + "'", connection);
            cmd.ExecuteNonQuery();          
            connection.Close();
        }
        else 
        {
            if (Request.QueryString["param1"] == "add")
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                connection.Open();
               //SqlCommand cmd = new SqlCommand("INSERT INTO Product  VALUES ('" + textCatogory.Text + "','" + textProductName.Text + "','" + textImageLink.Text + "','" + textSumInfo.Text + "','" + textQuantity.Text + "','" + textAvailable.Text + "','" + textPrice.Text + "','" + textBrand.Text + "','" + textPromotionPrice.Text + "','" + textDateIn.Text + "','" + textPromotionAddtion.Text + "','" + textWaranty.Text + "' , '" + textColor.Text + "', '" + textScreen + "','" + textModel.Text + "', '" + textCamera.Text + "', '" + textMusic.Text + "', '" + textFilm.Text + "','" + textFm.Text + "','" + textMemory.Text + "','" + textFlashMemory.Text + "', '" + textJava.Text + "' ,  '" + textBatterry.Text + "', '" + textOS.Text + "' ,'" + textSize.Text + "' ,  '" + textWeight.Text + "' , '" + textChip.Text + "')", connection);
                SqlCommand cmd = new SqlCommand("INSERT INTO Product (CatogoryID , ProductName , ImageLink , SumInfo , Quantity , Available , Price , Brand , PromotionPrice , DateIn ,PromotionAddition ,Warranty , Color , Screen ,Model ,Camera,Music , Film , Fm ,Memory , FlashMemory ,Java ,Battery , OS , Size , Weight , chip)  VALUES ('" + textCatogory.Text + "' , '" + textProductName.Text + "' ,'" + textImageLink.Text + "','" + textSumInfo.Text + "','" + textQuantity.Text + "','" + textAvailable.Text + "' , '" + textPrice.Text + "' , '" + textBrand.Text + "','" + textPromotionPrice.Text + "' , '" + textDateIn.Text + "','" + textPromotionAddtion.Text + "','" + textWaranty.Text + "' , '" + textColor.Text + "', '" + textScreen + "','" + textModel.Text + "', '" + textCamera.Text + "', '" + textMusic.Text + "', '" + textFilm.Text + "','" + textFm.Text + "','" + textMemory.Text + "','" + textFlashMemory.Text + "', '" + textJava.Text + "' ,  '" + textBatterry.Text + "', '" + textOS.Text + "' ,'" + textSize.Text + "' ,  '" + textWeight.Text + "' , '" + textChip.Text + "')", connection);             
                //SqlCommand cmd = new SqlCommand("INSERT INTO Product (CatogoryID , ProductName )  VALUES ('" + textCatogory.Text + "' , '" + textProductName.Text + "') WHERE Product.ID = '" + ID + "' ", connection);             
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
     
    }
}