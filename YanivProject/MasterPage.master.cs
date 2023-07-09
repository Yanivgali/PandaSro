using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YanivProject_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        store2.Visible = true;
        guser.Visible = true;
        glog.Visible = true;
        gcart.Visible = false;
        Li2.Visible = false;
        Li1.Visible = false;
        adminstore.Visible = false;
        cart.Visible = false;
        admin2.Visible = false;
        User.Visible = false;
        Admin1.Visible = false;
        lblDelete.Visible = false;
        lbLogout.Visible = false;
        lblchangeacc.Visible = false;
        lblchangeAdminacc.Visible = false;
        adminStatics.Visible = false;
        lbl1.Visible = false;
        lbl2.Visible = false;
        if (Session["User"] != null)
        {
            guser.Visible = false;
            glog.Visible = false;
            gcart.Visible = true;
            User.Visible = true;
            lblchangeacc.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl2.Text = Session["User"].ToString();
            lbLogout.Visible = true;
            lblRegister.Visible = false;
            lblLogin.Visible = false;
            cart.Visible = true;
        }
        else if (Session["Admin"] != null)
        {
            store2.Visible = false;
            guser.Visible = false;
            glog.Visible = false;
            Li2.Visible = true;
            Li1.Visible = true;
            adminstore.Visible = true;
            Admin1.Visible = true;
            admin2.Visible = true;
            adminStatics.Visible = true;
            lblDelete.Visible = true;
            lblchangeAdminacc.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl2.Text = Session["Admin"].ToString();
            lbLogout.Visible = true;
            lblRegister.Visible = false;
            lblLogin.Visible = false;
        }
        else
        {
            lbLogout.Visible = false;
            lblRegister.Visible = true;
            lblLogin.Visible = true;
        }
    }

    protected void LogOut(object sender, EventArgs e)
    {
        lbl1.Visible = false;
        lbl2.Visible = false;
        lblchangeacc.Visible = false;
        Session["user"] = null;
        Session["Admin"] = null;
        Response.Redirect("HomePage.aspx");
    }

    protected void SignUp(object sender, EventArgs e)
    {
       Response.Redirect("Register.aspx");
    }

    protected void LogIn(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void changeUserInfo(object sender, EventArgs e)
    {
        Response.Redirect("ChangeUserInfo.aspx");
    }
    protected void changeAdminInfo(object sender, EventArgs e)
    {
        Response.Redirect("ChangeAdminInfo.aspx");
    }

    protected void Delete(object sender, EventArgs e)
    {
        Response.Redirect("DeleteUser.aspx");
    }

    protected void Cart(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
}
