using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_DelteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblerr.Visible = false;
        MySql sqlUser = new MySql();
        DataSet dsUser = new DataSet();
        string stUser = "SELECT TblUser.UserName, TblUser.UserPassword, TblUser.Email, TblUser.Phonenumber FROM TblUser;";
        dsUser = sqlUser.testdata(stUser);
        grddelte.DataSource = dsUser.Tables[0];
        grddelte.DataBind();
    }
    protected void grddelte_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grddelte.PageIndex = e.NewPageIndex;
        //show items on gridview
        MySql sqlgrdus = new MySql();
        DataSet dsgrdus = new DataSet();
        string stgrdus = "SELECT TblUser.UserName, TblUser.UserPassword, TblUser.Email, TblUser.Phonenumber FROM TblUser;";
        dsgrdus = sqlgrdus.testdata(stgrdus);
        grddelte.DataSource = dsgrdus.Tables[0];
        grddelte.DataBind();
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        MySql sqldelus = new MySql();
        DataSet dsdelus = new DataSet();
        string stdelus = "DELETE TblUser.UserName, TblUser.UserPassword, TblUser.Email, TblUser.Phonenumber FROM TblUser WHERE(((TblUser.UserName) ='" + txtusername.Text + "'));";
        MySql sqltest = new MySql();
        DataSet dstest = new DataSet();
        string sttest = "SELECT TblUser.UserName FROM TblUser WHERE(((TblUser.UserName) ='" + txtusername.Text + "'));";
        dstest = sqltest.testdata(sttest);
        if (dstest.Tables[0].Rows.Count > 0)
        {
            sqldelus.updelin(stdelus);
            Response.Redirect("DeleteUser.aspx");
        }
        else
        {
            lblerr.Visible = true;
        }
    }
}