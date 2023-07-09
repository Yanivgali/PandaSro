using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;

public partial class YanivProject_email_verification : System.Web.UI.Page
{
    public int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["count"] != null)
        {
            counter = int.Parse(Session["count"].ToString()) + 1;
            if (txtemvr.Value == Session["Code"].ToString() && Session["Code"] != null)
            {
                MySql sqlUser = new MySql();
                string stUser = "insert into TblUser(UserName, UserPassword, Email) values('" + Session["User2"] + "', '" + Session["UserPassword2"] + "', '" + Session["UserEmail2"] + "');";
                sqlUser.updelin(stUser);
                Session["Userinfo"] = Session["User2"];
                Session["User"] = Session["User2"].ToString();
                Session["UserPassword"] = Session["UserPassword2"].ToString();
                Session["UserEmail"] = Session["UserEmail2"].ToString();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblcode.Attributes["style"] = "color:red;";
                lblcode.InnerText = "Wrong Code! tries " + counter + "";
            }
            if (counter == 4)
            {
                Response.Redirect("Register.aspx");
            }
            Session["count"] = counter;
        }
        else
        {
            Response.Redirect("Register.aspx");
        }
    }
}