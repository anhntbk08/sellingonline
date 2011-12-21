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

/// <summary>
/// Summary description for ManageCast
/// </summary>
public class ManageCast
{
    private String strCast;
    public ManageCast(String Giohang)
    {
        strCast = Giohang;
    }
    public void Init()
    {
        if (strCast[strCast.Length - 1] == ' ')
        {
            strCast = strCast.Substring(0, strCast.Length - 1);

        }
    }
    public int GetNumbreProductInCast()
    {
        int i;
        int dem = 0;
        for (i = 0; i < strCast.Length; i++)
        {
            if (strCast[i] == ' ')
            {
                dem++;
            }
        }
        return (dem + 1);
    }
    public String GetNameProductInCast(int index)
    {
        char[] strTemp;
        String sTemp;
        int dem = 0;
        int i = 0;
        int k = 0;
        strTemp = new char[1000];
        if (index == 0)
        {
            do
            {
                strTemp[i] = strCast[i];
                i++;
            }
            while ((i < strCast.Length) && (strCast[i] != ' '));
            strTemp[i] = (char)0;
        }
        else
        {
            for (i = 0; i < strCast.Length; i++)
            {
                if (strCast[i] == ' ')
                {
                    dem++;
                    if (dem == index)
                    {
                        break;
                    }
                }
            }
            i++;
            while ((i < strCast.Length) && (strCast[i] != ' '))
            {
                strTemp[k] = strCast[i];
                i++;
                k++;
            }
            strTemp[i] = (char)0;

        }
        sTemp = new string(strTemp);
        return sTemp;
    }
}
