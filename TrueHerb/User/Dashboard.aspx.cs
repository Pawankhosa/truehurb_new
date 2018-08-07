using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Dashboard : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string regno, name, father, date, address, gender, phn, marital;
    public static int pair = 0, pairincome = 0;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Common.Get(objsql.GetSingleValue("select updatepin from usersnew where regno='" + Session["user"] + "'"));
           // pair = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select pintype from pins where pin='"+id+"'")));
            if (pair == 1950)
            {
                pairincome = 300;
            }
            else
            {
                pairincome = 100;
            }
            bind();
            income();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            regno = dt.Rows[0]["regno"].ToString();
            name = dt.Rows[0]["fname"].ToString();
            father= dt.Rows[0]["lname"].ToString();
            date = dt.Rows[0]["joined"].ToString();
            address = dt.Rows[0]["add1"].ToString();
            gender = dt.Rows[0]["sex"].ToString();
            phn = dt.Rows[0]["mobile"].ToString();
            marital = dt.Rows[0]["marital"].ToString();

        }
    }
    protected void income()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from legs where regno='" + Session["user"] + "'");
        if (dt2.Rows.Count > 0)
        {
            int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
            int cappingleft = Convert.ToInt32(dt2.Rows[0]["cappingleft"]);
            if (cappingleft > left)
            {
                left = left;
            }
            else
            {
                left = left - cappingleft;
            }
            int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);
            int cappingright = Convert.ToInt32(dt2.Rows[0]["cappingright"]);
            if (cappingright > right)
            {
              //  right = right - cappingright;
            }
            else
            {
                right = right - cappingright;
            }

            if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
            {
                if (left < right)
                {
                    lblincome.Text = (left * pairincome).ToString();
                }
                else if (left == right)
                {
                    left = left - 1;
                    lblincome.Text = (left * pairincome).ToString();
                }
                else
                {
                    lblincome.Text = (right * pairincome).ToString();
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
                    lblincome.Text = (pairincome * minus).ToString();
                }
                else if (left < right)
                {
                    int minus = left - 1;
                    lblincome.Text = (pairincome * minus).ToString();
                }
                else
                {
                    int minus = right - 1;
                    lblincome.Text = (pairincome * minus).ToString();
                }
            }

            capping();
        }
    }
    protected void capping()
    {
        int left= Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingleft from legs where regno='" + Session["user"] + "' ")));
        int right = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingright from legs where regno='" + Session["user"] + "' ")));
        lblcapping.Text = (left + right).ToString();
        DataTable Dt = new DataTable();
        dt = objsql.GetTable("select * from legs where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            lblleft.Text = dt.Rows[0]["leftleg"].ToString();
            lblright.Text = dt.Rows[0]["rightleg"].ToString();
        }
    }
}