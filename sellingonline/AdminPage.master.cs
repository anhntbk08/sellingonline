using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchNavigate.Click += new EventHandler(SearchNavigate_Click);
    }

    void SearchNavigate_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResultAdmin.aspx?" + "searchby=" + SearchBy.SelectedValue.ToString() + "&searchkeyword=" + SearchKeyword.Text);
    }
}
