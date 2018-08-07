using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_CRITERIA : System.Web.UI.Page
{
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public int cl = 0, cr = 0, Cl = 0, Cr = 0, Activeid = 0, se = 0, ActiveidL = 0, c = 0, leftthismont = 0, thismonthinst = 0, thismonthinstleft = 0, counterdata = 0, counterdata2 = 0;
    public string single, single2, single3;
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            pNodeL(Session["user"].ToString(), "one");
            pNodeR(Session["user"].ToString(), "two");

        }
        else
        {
            Response.Redirect("~/login.aspx");
        }


    }
    protected string lastnode(string sponser, string node)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("Crateria", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", sponser.Trim());           // sponser id
                cmd.Parameters.AddWithValue("@node", node);                            // node
                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.Parameters["@printvalue"].Value.ToString();

            }

        }
    }
    private void pNodeL(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' and node='" + place + "'";


        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveL(node);
            Cl = Cl + 1;
            pNodeLL(dt.Rows[0]["regno"].ToString(), "");

        }
        else if (dt.Rows.Count > 1)
        {
            ActiveL(node);
            Cl = Cl + 2;

            pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");
            pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

        }
        if (dt.Rows.Count == 0)
        {
            ActiveL(node);

        }
    }
    // Calculate after 1 count left
    private void pNodeLL(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' ";
        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveL(node);
            Cl = Cl + 1;
            single = single + ',' + node;
            pNodeLL(dt.Rows[0]["regno"].ToString(), "");
        }
        else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
        {
            ActiveL(node);
            Cl = Cl + 2;
            single2 = single2 + ',' + node;
            pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");


            pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

            //   ActiveL(node);


        }
        if (dt.Rows.Count == 0)
        {

            ActiveL(node);
            single3 = single3 + ',' + node;
        }

    }
    protected void ActiveL(string id)
    {
        leftthismont += 1;
        if (Convert.ToInt32(id) != 0)
        {
            int check = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + id + "'")));
            if (check >= 2)
            {
                string datemax = Common.Get(objsql.GetSingleValue("select max(dated) from installments where regno='" + id + "'"));
                if (datemax != "")
                {

                    DateTime today = System.DateTime.Now;
                    DateTime mx = Convert.ToDateTime(datemax);
                    // string month = (Convert.ToDateTime(today).Month - Convert.ToDateTime(datemax).Month).ToString();
                    int Diff = ((today.Year - mx.Year) * 12) + today.Month - mx.Month;
                    if (Diff < 0)
                    {
                        Diff = Convert.ToInt32(Diff) * Convert.ToInt32(-1);
                    }
                    else
                    {

                    }
                    if (Diff <= 3)
                    {
                        counterdata += 1;
                        lblleft.Text = counterdata.ToString();
                    }

                }
            }
        }
        ////count = id;
        //if (se != Convert.ToInt32(id))
        //{



        //    totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='" + from + "'"));
        //    if (Convert.ToInt32(totalinst) >= 6)
        //    {
        //        count = count + "," + id;
        //        ActiveidL += 1; // then active
        //    }
        //    else
        //    {
        //        getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //        if (getid != "")
        //        {
        //            int totaldep = (Convert.ToInt32(totalinst) + Convert.ToInt32(getid));
        //            if (totaldep >= 2)
        //            {
        //                if (Convert.ToInt32(getid) > 0)
        //                {
        //                    ActiveidL += 1; // active
        //                }
        //            }
        //            if (totaldep >= 6)
        //            {
        //                // ActiveidL += 1;
        //            }

        //        }
        //    }
        //    #region check this month joining and last month active
        //    string thismonthjoin = Common.Get(objsql.GetSingleValue("select date_entry from member_creation where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //    if (thismonthjoin != "")
        //    {

        //        string getid1 = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //        if (getid1 != "")
        //        {
        //            if (Convert.ToInt32(getid1) > 0)
        //            {

        //                thismonthinstleft += 1;
        //            }
        //        }

        //    }

        //    #endregion
        //}
    }



    private void pNodeR(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' and node='" + place + "'";


        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveR(node);
            Cl = Cl + 1;
            pNodeRR(dt.Rows[0]["regno"].ToString(), "");

        }
        else if (dt.Rows.Count > 1)
        {
            ActiveR(node);
            Cl = Cl + 2;

            pNodeRR(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");
            pNodeRR(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

        }
        if (dt.Rows.Count == 0)
        {
            ActiveR(node);
            single3 = single3 + ',' + node;
        }
    }
    // Calculate after 1 count left
    private void pNodeRR(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' ";
        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveR(node);
            Cl = Cl + 1;
            single = single + ',' + node;
            pNodeRR(dt.Rows[0]["regno"].ToString(), "");
        }
        else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
        {
            ActiveR(node);
            Cl = Cl + 2;
            single2 = single2 + ',' + node;
            pNodeRR(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");


            pNodeRR(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

            //   ActiveL(node);


        }
        if (dt.Rows.Count == 0)
        {

            ActiveR(node);
            single3 = single3 + ',' + node;
        }

    }
    protected void ActiveR(string id)
    {
        leftthismont += 1;
        if (Convert.ToInt32(id) != 0)
        {
            int check = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + id + "'")));
            if (check >= 2)
            {
                string datemax = Common.Get(objsql.GetSingleValue("select max(dated) from installments where regno='" + id + "'"));
                if (datemax != "")
                {

                    DateTime today = System.DateTime.Now;
                    DateTime mx = Convert.ToDateTime(datemax);
                    // string month = (Convert.ToDateTime(today).Month - Convert.ToDateTime(datemax).Month).ToString();
                    int Diff = ((today.Year - mx.Year) * 12) + today.Month - mx.Month;
                    if (Diff < 0)
                    {
                        Diff = Convert.ToInt32(Diff) * Convert.ToInt32(-1);
                    }
                    else
                    {

                    }
                    if (Diff <= 3)
                    {
                        counterdata2 += 1;
                        lblright.Text = counterdata2.ToString();
                    }

                }
            }
        }
        ////count = id;
        //if (se != Convert.ToInt32(id))
        //{



        //    totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='" + from + "'"));
        //    if (Convert.ToInt32(totalinst) >= 6)
        //    {
        //        count = count + "," + id;
        //        ActiveidL += 1; // then active
        //    }
        //    else
        //    {
        //        getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //        if (getid != "")
        //        {
        //            int totaldep = (Convert.ToInt32(totalinst) + Convert.ToInt32(getid));
        //            if (totaldep >= 2)
        //            {
        //                if (Convert.ToInt32(getid) > 0)
        //                {
        //                    ActiveidL += 1; // active
        //                }
        //            }
        //            if (totaldep >= 6)
        //            {
        //                // ActiveidL += 1;
        //            }

        //        }
        //    }
        //    #region check this month joining and last month active
        //    string thismonthjoin = Common.Get(objsql.GetSingleValue("select date_entry from member_creation where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //    if (thismonthjoin != "")
        //    {

        //        string getid1 = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
        //        if (getid1 != "")
        //        {
        //            if (Convert.ToInt32(getid1) > 0)
        //            {

        //                thismonthinstleft += 1;
        //            }
        //        }

        //    }

        //    #endregion
        //}
    }
}