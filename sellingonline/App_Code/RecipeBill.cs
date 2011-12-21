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
/// Summary description for RecipeBill
/// </summary>
/// 
public class RecipeDataInfo
{
    public string CustomerName;
    public string PhoneNumber;
    public string DateCreat ;
    public string Email;
    public string CMT;
    private string p;
    private TextBox txtPhone;
    private string CurrentTime;
    private TextBox txtEmail;
    private TextBox txtCMT;
    public RecipeDataInfo(string CustomerName, string PhoneNumber, string DateCreat, string Email, string CMT)
	{
        this.CustomerName = CustomerName;
        this.PhoneNumber = PhoneNumber;
        this.DateCreat = DateCreat;
        this.Email = Email;
        this.CMT = CMT;
	}

    
}
public class SellProductInfo
{
    public string ProductId;
    public string Quantity;
    public SellProductInfo(string ProductId, string Quantity)
    {
        this.ProductId = ProductId;
        this.Quantity = Quantity;
    }
}
public class SellProductArray
{
    public int NumberProduct;
    public SellProductInfo[]  SellProductArr;
    public SellProductArray(int NumberProduct)
    {
        this.NumberProduct = NumberProduct ;
        SellProductArr = new SellProductInfo[NumberProduct];
    }
    public void SetValue(int index , SellProductInfo sellProductInfo)
    {
        SellProductArr[index] = sellProductInfo;
    }
}
public class RecipeBill
{
    
	public RecipeBill()
	{
        
	}
    public void AddRecipe(RecipeDataInfo recipeData, SellProductArray sellProductArr)
    {
        int iUserID = 0;
        int i;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Recipe (CustomerName,PhoneNumber,DateCreat,Email,CMT) VALUES ('"+recipeData.CustomerName+"','"+recipeData.PhoneNumber+"','"+recipeData.DateCreat+"','"+recipeData.Email+"','"+recipeData.CMT+"') SELECT @@IDENTITY AS 'ident';", connection);
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.Read())
        {
            object obValue = myReader.GetValue(0);
            iUserID = Convert.ToInt32(obValue.ToString());

        }
        myReader.Close();
        for (i = 0; i < sellProductArr.NumberProduct; i++)
        {
            cmd = new SqlCommand("INSERT INTO SellProduct (RecipeId,ProductId,Quantity) VALUES ('" + iUserID + "','"+sellProductArr.SellProductArr[i].ProductId+"','"+sellProductArr.SellProductArr[i].Quantity+"')", connection);
            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
}