using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_CheckDailyIncome : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string id = Common.Get(objsql.GetSingleValue("select regno from usersnew where regno='" + txtregno.Text + "'"));
        if (id != "")
        {
            income(txtregno.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry User Not Found')", true);

        }

    }
    protected void income(string regno)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from legs where regno='" + regno + "'");
        if (dt2.Rows.Count > 0)
        {
            int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
            int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);
            if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
            {
                if (left < right)
                {
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
            lblname.Text = "Your Daily Total Income is : ";


        }
    }
}