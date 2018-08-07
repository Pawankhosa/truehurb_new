using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Report : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public int left = 0, right = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select distinct u.regno,u.fname,l.leftleg,l.rightleg from usersnew u , legs l where l.regno=u.regno and l.leftleg>'1' and l.rightleg>'1'");
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
            HiddenField left1 = (HiddenField)e.Item.FindControl("hfleft");
            HiddenField regno = (HiddenField)e.Item.FindControl("hfregno");
            HiddenField right1 = (HiddenField)e.Item.FindControl("hfright");
            left = Convert.ToInt32(left1.Value);
            right = Convert.ToInt32(right1.Value);
            Label amount = (Label)e.Item.FindControl("lblamt");
            Label charge = (Label)e.Item.FindControl("lblchg");
            Label net = (Label)e.Item.FindControl("lblnet");
            Label paid = (Label)e.Item.FindControl("lblpaid");
            Label to = (Label)e.Item.FindControl("lbltopay");
            if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
            {
                if (left < right)
                {
                    amount.Text = (left * 300).ToString();
                }
                else if (left == right)
                {
                    left = left - 1;
                    if (left < 0)
                    {
                        amount.Text = "0";
                    }

                    else
                    {
                        amount.Text = (left * 300).ToString();
                    }

                    
                }
                else
                {
                    amount.Text = (right * 300).ToString();
                }


            }
            else
            {
                if (left == right)
                {
                    int minus = left - 1;
                    if (minus < 0)
                    {
                        amount.Text = "0";
                    }
                    else
                    {
                        amount.Text = (300 * minus).ToString();
                    }
                }
                else if (left < right)
                {
                    int minus = left - 1;
                    if (minus < 0)
                    {
                        amount.Text = "0";
                    }
                    else
                    {
                        amount.Text = (300 * minus).ToString();
                    }
                    
                }
                else
                {
                    int minus = right - 1;
                    if (minus < 0)
                    {
                        amount.Text = "0";
                    }
                    else
                    {
                        amount.Text = (300 * minus).ToString();
                    }
                }
            }

            int tds = ((Convert.ToInt32(amount.Text) * Convert.ToInt32(5)) / Convert.ToInt32(100));
            int admin = ((Convert.ToInt32(amount.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100));
            charge.Text = (tds + admin).ToString();
            net.Text = (Convert.ToInt32(amount.Text) - Convert.ToInt32(charge.Text)).ToString();
            paid.Text = Common.Get(objsql.GetSingleValue("select sum(amount) from payout where regno='" + regno.Value + "'"));
            if (paid.Text == "")
            {
                paid.Text = "0";
            }
            to.Text = (Convert.ToInt32(net.Text) - Convert.ToInt32(paid.Text)).ToString();
            if (to.Text == "0")
            {
                e.Item.Visible = false;
            }
        }
    }

    protected void lnkclick_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Session["user"] = id.ToString();
        Response.Redirect("~/user/dashboard.aspx");
    }
}