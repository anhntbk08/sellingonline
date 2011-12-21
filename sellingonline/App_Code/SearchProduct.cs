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
/// Summary description for SearchProduct
/// </summary>
//
namespace App_Code
{
    public class SearchProduct
    {
        private SqlConnection connection;
        private SqlDataAdapter sqlAdapter;
        private SqlCommand sqlCommand;

        public SearchProduct()
        {
            //Ket noi toi co so du lieu
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        public void SearchAll(DataSet dataset)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }
        public void SearchByProductID(int ID, DataSet dataset)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product WHERE Product.Id = '" + ID + "' ", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }
        public void SearchByProductName(String strProductName, DataSet dataset)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product  WHERE Product.ProductName = '" + strProductName + "'", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }
        public void SearchByHotProduct(DataSet dataset, float x)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product   WHERE  Available/ Quantity < 1 ", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }
        public void SearchByCategoryAndBrand(DataSet dataset, string Brand, int CategoryId)
        {
            if (Brand == null)
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product  WHERE Product.CatogoryID = '" + CategoryId + "' ", connection);
            }
            else
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product   WHERE Product.CatogoryID = '" + CategoryId + "'and Product.Brand = '" + Brand + "' ", connection);
            }
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }
        public void SearchProductByCostAndCatogoryOrBrand(int ulMinCost, int ulMaxCost, string param ,DataSet dataset)
        {
            if (param == "1")
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE (Price<='" + ulMaxCost + "' and Price >= '" + ulMinCost + "' AND CatogoryID = '1' )", connection);
            }
            else
            if (param == "2")
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE (Price <='" + ulMaxCost + "' and Price>= '" + ulMinCost + "' AND CatogoryID = '2' )", connection);
            }
            else
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE (Price<='" + ulMaxCost + "' and Price >= '" + ulMinCost + "' AND Brand = '"+param+"' )", connection);
          
            }
             sqlAdapter = new SqlDataAdapter(sqlCommand);
             sqlAdapter.Fill(dataset, "Product");

        }
        public void SearchProductByBrand(String strBrandName, DataSet dataset)
        {
            if (strBrandName == "NOKIA")
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE Brand = 'NOKIA'", connection);
            }
            if (strBrandName == "SAMSUNG")
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE Brand = 'SAMSUNG'", connection);
            }
            if (strBrandName == "DELL")
            {
                sqlCommand = new SqlCommand("SELECT * FROM Product WHERE Brand = 'DELL'", connection);
            }
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset, "Product");
        }

        public void CloseDataBase()
        {
            connection.Close();
        }

        public void SearchProductInfoById(string index, DataSet dataset)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product WHERE id = '" + index + "'", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset, "Product");
        }

        public void SearchProductInfoDetailById(string index, DataSet dataset)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Product WHERE Product.ID = '" + index + "'", connection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dataset);
        }


    }
}