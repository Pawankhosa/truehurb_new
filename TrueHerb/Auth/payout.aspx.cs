using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_payout : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int leftpair = 0, rightpair = 0;
    DataTable dt = new DataTable();
    public int total = 0,bal=0;
    public string value1 = "",value2="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

        }
    }
    protected void bind(string reg)
    {
        lblregno.Text = reg.ToString();
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" +reg + "'"));
        leftpair = int.Parse(Common.Get(objsql.GetSingleValue("select leftleg from legs where regno='" + reg + "'")));
        rightpair = int.Parse(Common.Get(objsql.GetSingleValue("select rightleg from legs where regno='" + reg + "'")));
        income();
        lbltotal.Text = lblincome.Text;
      //  lblptotal.Text = (Convert.ToInt32(lblpincome.Text) * Convert.ToInt32(proposer)).ToString();
        //lbltotal.Text = (Convert.ToInt32(lblstotal.Text) + Convert.ToInt32(lblptotal.Text)).ToString();
        lbltds.Text = ((Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(5)) / Convert.ToInt32(100)).ToString();
        lbladmin.Text = ((Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        lblnet.Text = (Convert.ToInt32(lbltotal.Text) - (Convert.ToInt32(lbltds.Text)+Convert.ToInt32(lbladmin.Text))).ToString();
        dt = objsql.GetTable("select * from payout where regno='" + reg + "'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        else
        {
            bal =Convert.ToInt32(lblnet.Text);
        }
    }
    protected void income()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from legs where regno='" + txtregid.Text + "'");
        if (dt2.Rows.Count > 0)
        {
            int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
            int cappingleft = Convert.ToInt32(dt2.Rows[0]["cappingleft"]);
            if (cappingleft > 0)
            {
                left = left - cappingleft;
            }
            int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);
            int cappingright = Convert.ToInt32(dt2.Rows[0]["cappingright"]);
            if (cappingright > 0)
            {
                right = right - cappingright;
            }
            if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
            {
                if (left < right)
                {
                    lblincome.Text = (left * 300).ToString();
                }
                else if (left == right)
                {
                    left = left - 1;
                    lblincome.Text = (left * 300).ToString();
                }
                else
                {
                    lblincome.Text = (right * 300).ToString();
                }

                //if (left == right)
                //{
                //    int minus = left - 1;
                //    lblincome.Text = (300 * minus).ToString();
                //}
                //if (left < right)
                //{
                //    int minus = left - 1;
                //    lblincome.Text = (300 * minus).ToString();
                //}
                //else
                //{
                //    int minus = right - 1;
                //    lblincome.Text = (300 * minus).ToString();
                //}

            }
            else
            {
                if (left == right)
                {
                    int minus = left - 1;
                    lblincome.Text = (300 * minus).ToString();
                }
                else if (left < right)
                {
                    int minus = left - 1;
                    lblincome.Text = (300 * minus).ToString();
                }
                else
                {
                    int minus = right - 1;
                    lblincome.Text = (300 * minus).ToString();
                }
            }

            capping();
        }
    }
    protected void capping()
    {
        int left = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingleft from legs where regno='" + txtregid.Text + "' ")));
        int right = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingright from legs where regno='" + txtregid.Text + "' ")));
        lblcapping.Text = (left + right).ToString();
        
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from usersnew where regno='" + txtregid.Text + "'");
        if (dt2.Rows.Count > 0)
        {
            Panel1.Visible = true;
            txtreg.Text = txtregid.Text;
            bind(txtregid.Text);

        }
        else
        {
            Panel1.Visible = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from payout where serial='" + id + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Successfully')", true);
        bind(txtregid.Text);    

    }

    protected void btnpaid_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtmnt.Text) >= bal)
        {
            if (RadioButtonList1.SelectedItem.Text == "Cash")
            {
                value1 = RadioButtonList1.SelectedItem.Text;
            }
            else
            {
                value2 = RadioButtonList1.SelectedItem.Text;
            }
            objsql.ExecuteNonQuery("insert into payout(regno,dated,amount,cash,chqno,remarks) values('" + txtregid.Text + "','" + System.DateTime.Now + "','" + txtmnt.Text + "','" + value1 + "','" + value2 + "','" + txtreason.Text + "')");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pay Sucessfully')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Low Balance')", true);
        }
        bind(txtregid.Text);
    }
   

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label amt = (Label)e.Item.FindControl("lblamt");
            total +=int.Parse( amt.Text);

        }
        bal = Convert.ToInt32(lblnet.Text) - total;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("payout-edit.aspx?id=" + id);
    }
}