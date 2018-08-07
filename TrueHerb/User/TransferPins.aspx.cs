using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
public partial class User_TransferPins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            try
            {
                int countpins = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + Session["user"] + "'")));
                if (countpins >= Convert.ToInt32(txtpins.Text))
                {
                    for (int i = 1; i <= Convert.ToInt32(txtpins.Text); i++)
                    {
                        DataTable dt = new DataTable();
                        dt = objsql.GetTable("select top(1) * from pins where regno='" + Session["user"] + "' and status='n'");
                        if (dt.Rows.Count > 0)
                        {
                            objsql.ExecuteNonQuery("insert into pintransfers(pin,oldregno,newregno,dated) values('" + dt.Rows[0]["pin"] + "','" + Session["user"] + "','" + txtid.Text + "','" + DateTime.Now + "')");
                            objsql.ExecuteNonQuery("update pins set subregno='',regno='" + txtid.Text + "' where serial='" + dt.Rows[0]["serial"] + "'");
                            lblpins.Text = txtpins.Text;
                            lblto.Text = lblname.Text;
                            Panel1.Visible = true;
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + countpins + " are lefts')", true);

                }
                ts.Complete();
                ts.Dispose();
                txtid.Text = "";
                txtpins.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    protected void txtid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text= Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtid.Text + "'"));
    }
}