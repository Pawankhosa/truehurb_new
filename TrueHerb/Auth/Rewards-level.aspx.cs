using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Rewards_level : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string reg, total;
    public int totalpurchase = 0,paidamt=0,payabl=0, bal = 0,totalpayabl=0;
    protected void Page_Load(object sender, EventArgs e)
    {
       // reg = Session["user"].ToString();
        if (!IsPostBack)
        {
          //  bind();
        }
    }
    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = bindmember();

    }
    protected string bindmember()
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
        }
        else
        {
            bind();
            bindPayments();
            return lblname.Text; 
        }
        return "";
    }
    protected void bind()
    {
        string chk = Common.Get(objsql.GetSingleValue("select regno from tblmasterorder where regno='" + txtregid.Text + "'"));
        if (chk == "")
        {
            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please puchase first')", true);
        }
        else
        {
            totalpurchase = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where regno='" + txtregid.Text + "'")));
        }
        dt = objsql.GetTable("select * from legs where regno='" + txtregid.Text + "'");
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
        else
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
            Label lblamount = (Label)e.Item.FindControl("lblamount");
            HiddenField id = (HiddenField)e.Item.FindControl("hfid");
            Label sale = (Label)e.Item.FindControl("lblsale");
           // HiddenField sale = (HiddenField)e.Item.FindControl("lblsale");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
         //   Label lblreward = (Label)e.Item.FindControl("lblreward");
            //LinkButton rbtn = (LinkButton)e.Item.FindControl("lnkreward");

            if (totalpurchase >= Convert.ToInt32(sale.Text))
            {
                level.Text = "Purchase";
                level.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                level.Text = "Pending";
                level.ForeColor = System.Drawing.Color.Red;
            }
            //if (level.Text == "Purchase")
            //{
            //    string check = Common.Get(objsql.GetSingleValue("select rewardname from tblrewardincome where regno='" + txtregid.Text + "' and rewardname='" + id.Value + "'"));
            //    if (check != "")
            //    {
            //        lblreward.Text = "Reward Done";
            //        lblreward.Enabled = false;
            //        lblreward.CssClass = "btn btn-primary";
            //        lblreward.ForeColor = System.Drawing.Color.White;
            //    }
            //    else
            //    {
            //        lblreward.Text = "Apply Reward";

            //    }
            //}
            if (level.Text == "Purchase")
            {
                string pin = pins.Text;
                if (pin == "2:1")
                {
                    pin = "1";
                }
                else
                {
                    pin = pins.Text;
                }
                if (Convert.ToInt32(pin) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pin) <= Convert.ToInt32(lblright.Text))
                {
                    level.Text = "Achieved";
                    level.CssClass = "btn btn-primary";
                    payabl += Convert.ToInt32(lblamount.Text);
                    //         income.Text = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + txtregid.Text + "' and rewardname='" + id.Value + "'"));
                }
            }
            else
            {
                level.CssClass = "text-danger";
            }
    }
        totalpayabl = payabl;
        txtmnt.Text = payabl.ToString();
    }

    public void bindPayments()
    {
        DataTable dtp = new DataTable();
        dtp = objsql.GetTable("select * from tblPayreward where regno='" + txtregid.Text + "'");
        if (dtp.Rows.Count > 0)
        {
            ListView1.DataSource = dtp;
            ListView1.DataBind();
        }
        else
        {
            ListView1.DataSource = dtp;
            ListView1.DataBind();
        }
    }
    protected void btnpaid_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtmnt.Text) >= bal)
        {
            objsql.ExecuteNonQuery("insert into tblPayreward(regno,date,paid,mode,chqno) values('" + txtregid.Text + "','" + System.DateTime.Now + "','" + txtmnt.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtcheque.Text + "')");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pay Sucessfully')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Low Balance')", true);
        }
        Response.Redirect("Rewards-level.aspx");
        //bindPayments();
    }


    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
       // totalpayabl = 0;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            //Label lblbal = (Label)e.Item.FindControl("lblbal");
            Label amt = (Label)e.Item.FindControl("lblamt");
            paidamt += Convert.ToInt32(amt.Text);
            //bal += Convert.ToInt32(lblbal.Text);
            //total += int.Parse(amt.Text);
        }
        totalpayabl = ((payabl - paidamt));
        txtmnt.Text = totalpayabl.ToString();
     //   bal = Convert.ToInt32(lblnet.Text) - total;
    }


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "Cheque")
        {
            txtcheque.Visible = true;
        }
        else
        {
            txtcheque.Visible = false;
        }
    }

    //protected void txtmnt_TextChanged(object sender, EventArgs e)
    //{
    //if (Convert.ToInt32(txtmnt.Text) != totalpayabl)
    //{
    //    txtbalance.Text = (totalpayabl - Convert.ToInt32(txtmnt.Text)).ToString();
    //}
    //else
    //{
    //    txtbalance.Text = "0";
    //}
    //}
}