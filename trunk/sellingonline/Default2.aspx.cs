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
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int iUserID = 0;
        //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //connection.Open();
        ////SqlCommand cmd = new SqlCommand("INSERT INTO Product  VALUES ('" + textCatogory.Text + "','" + textProductName.Text + "','" + textImageLink.Text + "','" + textSumInfo.Text + "','" + textQuantity.Text + "','" + textAvailable.Text + "','" + textPrice.Text + "','" + textBrand.Text + "','" + textPromotionPrice.Text + "','" + textDateIn.Text + "','" + textPromotionAddtion.Text + "','" + textWaranty.Text + "' , '" + textColor.Text + "', '" + textScreen + "','" + textModel.Text + "', '" + textCamera.Text + "', '" + textMusic.Text + "', '" + textFilm.Text + "','" + textFm.Text + "','" + textMemory.Text + "','" + textFlashMemory.Text + "', '" + textJava.Text + "' ,  '" + textBatterry.Text + "', '" + textOS.Text + "' ,'" + textSize.Text + "' ,  '" + textWeight.Text + "' , '" + textChip.Text + "')", connection);
        //SqlCommand cmd = new SqlCommand("INSERT INTO Recipe (CustomerName,PhoneNumber,DateCreat,Email,CMT) VALUES ('nghia dia','0979653902','12/11/2011','nghiadia@yahoo','123456789') SELECT @@IDENTITY AS 'ident';", connection);
        ////SqlCommand cmd = new SqlCommand("INSERT INTO Product (CatogoryID , ProductName )  VALUES ('" + textCatogory.Text + "' , '" + textProductName.Text + "') WHERE Product.ID = '" + ID + "' ", connection);             
        //SqlDataReader myReader = cmd.ExecuteReader();
        //while (myReader.Read())
        //{
        //    object obValue = myReader.GetValue(0);
        //    iUserID = Convert.ToInt32(obValue.ToString());
            
        //}
        //myReader.Close();
        //cmd = new SqlCommand("INSERT INTO SellProduct (RecipeId,ProductId,Quantity) VALUES ('" + iUserID + "','26','100')", connection);
        //cmd.ExecuteNonQuery();
        //connection.Close();
        RecipeDataInfo recvInfo = new RecipeDataInfo("nghia", "0979653902", "10/10/2011", "nghiadia@yahoo", "123456789");
        SellProductArray sellProAddr = new SellProductArray(2);
        SellProductInfo sell1 = new SellProductInfo("27", "2");
        SellProductInfo sell2 = new SellProductInfo("28", "2");
        sellProAddr.SetValue(0, sell1);
        sellProAddr.SetValue(1, sell2);
        RecipeBill recvBill = new RecipeBill();
        recvBill.AddRecipe(recvInfo, sellProAddr);

    }
}