using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_unusedpinstatus : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select distinct p.regno,r.fname from pins p,usersnew r where p.status='n' and p.regno=r.regno");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void gvpins_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label total = (Label)e.Item.FindControl("lbltotal");
            Label reg = (Label)e.Item.FindControl("lblreg");
            total.Text= Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + reg.Text + "' and status='n'"));
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("unusedpins.aspx?id="+id);
    }
}