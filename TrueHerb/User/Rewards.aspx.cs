using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Rewards : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bind(Session["user"].ToString());
        }
    }
    protected void bind(string regno)
    {
        dt = objsql.GetTable("select * from legs where regno='" + regno + "'");
        if (dt.Rows.Count > 0)
        {
            lblleft.Text = dt.Rows[0]["leftleg"].ToString();
            lblright.Text = dt.Rows[0]["rightleg"].ToString();
        }
        dt = objsql.GetTable("select * from tblrewarddetails");
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
            Label income = (Label)e.Item.FindControl("lblincome");
            HiddenField id = (HiddenField)e.Item.FindControl("hfid");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
            if (pins.Text == "2:1")
            {
                pins.Text = "1";
            }
            if (Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblright.Text))
            {
                level.Text = "Achieved";
                income.Text = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + Session["user"].ToString() + "' and rewardname='" + id.Value + "'"));
            }
            else
            {
                level.CssClass = "text-danger";
            }


        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from usersnew where regno='" + Session["user"].ToString() + "'");
        if (dt2.Rows.Count > 0)
        {
            pnllist.Visible = true;
            // txtreg.Text = txtregid.Text;
            bind(Session["user"].ToString());

        }
        else
        {
            pnllist.Visible = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

        }
    }
}