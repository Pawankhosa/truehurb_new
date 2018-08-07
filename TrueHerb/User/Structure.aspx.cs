using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
public partial class User_Structure : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["user"]!=null)
            {
                bind(Session["user"].ToString());
            }
            
        }
    }
    protected void bind(string regno)
    {
        dt = objsql.GetTable("select u.fname,u.regno,u.joined,i.cregno  from inststruc i, usersnew u where i.cregno=u.regno and pregno='" + regno + "' order by i.cregno asc");
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
            HiddenField hid = (HiddenField)e.Item.FindControl("hfid");
            Label installment = (Label)e.Item.FindControl("lbltotalinst");
            Label last = (Label)e.Item.FindControl("lbllastpaid");
            TextBox txtpaid = (TextBox)e.Item.FindControl("txtpaid");

            installment.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + hid.Value + "'"));
            string id = Common.Get(objsql.GetSingleValue("select max(serial) from installments where regno='" + hid.Value + "'"));
            string date = Common.Get(objsql.GetSingleValue("select dated from installments where serial='" + id + "'"));
            last.Text = Convert.ToDateTime(date).ToString("dd/MM/yyyy");
        }
    }
    protected void btnpay_Click(object sender, EventArgs e)
    {
        string countpins = Common.Get(objsql.GetSingleValue("select count(*) from duepins where regno='" + Session["user"] + "'"));
        foreach (ListViewItem lv in gvpins.Items)
        {
            TextBox pay = (TextBox)lv.FindControl("txtpaid");
            HiddenField id = (HiddenField)lv.FindControl("hfid");
            using (TransactionScope ts = new TransactionScope())
            {
                if (pay.Text != "")
                {
                    if (Convert.ToInt32(countpins) >= Convert.ToInt32(pay.Text))
                    {
                        int length = Convert.ToInt32(pay.Text);
                        for (int i = 1; i <= length; i++)
                        {
                            int maxid = int.Parse(Common.Get(objsql.GetSingleValue("select max(serial) from duepins where regno='" + Session["user"] + "' and status='n'")));
                            if (maxid != null)
                            {
                                objsql.ExecuteNonQuery("update duepins set status='y',dated='" + System.DateTime.Now + "' where serial='" + maxid + "'");
                                objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated) values('" + id.Value + "','1','1000','" + System.DateTime.Now + "')");
                            }
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Sucessfully')", true);
                        ts.Complete();
                        ts.Dispose();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insufficient Pins only " + countpins + " are availables')", true);
                        ts.Dispose();
                        pay.Text = "";
                    }
                }

            }


        }


    }
}