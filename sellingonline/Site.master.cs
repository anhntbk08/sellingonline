using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchNavigate.Click += new EventHandler(SearchNavigate_Click);
    }

    void SearchNavigate_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx?" + "searchby=" + SearchBy.SelectedValue.ToString() + "&searchkeyword=" + SearchKeyword.Text);
    }

    public void Navigate(Object sender, EventArgs e)
    {
        
    }


}
