using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Life_Time_Rewards : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from legs where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            lblleft.Text = dt.Rows[0]["leftleg"].ToString();
            lblright.Text = dt.Rows[0]["rightleg"].ToString();
        }
        dt = objsql.GetTable("select * from tblrewards");
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
            Label pins = (Label)e.Item.FindControl("lblpins");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
            if (Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblright.Text))
            {
                level.Text = "Achieved";

            }
            else
            {
                level.CssClass = "text-danger";
            }


        }
    }
}