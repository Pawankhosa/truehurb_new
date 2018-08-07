using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Text;

public partial class Auth_Createpins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    
    public string pins2 = "",pins="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            int length = Convert.ToInt32(ddlpin.SelectedItem.Text);
            for (int i = 0; i < length; i++)
            {

                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                pins = objsql.GenerateRandomOTP(15, saAllowedCharacters);
                objsql.ExecuteNonQuery("insert into pins(pin,pintype,status,allotted,regno,subregno,dated,datecreate) values('" + Guid.NewGuid().ToString().Substring(1, 15) + "','" + ddlpintype.SelectedItem.Text + "','n','y','" + txtpin.Text + "','','" + DateTime.Now + "','" + DateTime.Now + "')");
                pins = "";
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            Response.Redirect("Succespins.aspx?pin=" + ddlpin.SelectedItem.Text + "&user=" + txtpin.Text);
        }
        catch (Exception a)
        {
            string message = a.Message;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);
            throw;
        }


        clear();

    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtpin.Text + "'"));
    }
    protected void clear()
    {
        txtpin.Text = "";
    }
    protected void randomgenerate( int length)
    {
         Random random = new Random();
        for (int i = 1 ; i < length ; i++)
        {
            pins = random.Next().ToString();
        }
   }
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }
}