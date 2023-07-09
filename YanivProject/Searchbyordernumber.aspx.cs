using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_Searchbyordernumber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblerr.Visible = false;
        Panel1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        MySql sql = new MySql();
        string selectItem = "SELECT TblOrder.OrderId, TblUser.UserName, TblUser.UserPassword, TblOrder.CardNumber, TblOrder.OrderTime, TblOrder.Phone, TblOrder.Email, TblOrder.VisaHolder, TblOrder.ExpiredDated, TblOrder.CVC, TblOrder.TotalOrderAmount, TblOrder.ProtuctID FROM TblUser INNER JOIN TblOrder ON TblUser.ID = TblOrder.UserId WHERE(((TblOrder.OrderId) ="+txtorder.Text+"));";
        ds = sql.testdata(selectItem);
        if(ds.Tables[0].Rows.Count > 0)
        {
            Panel1.Visible = true;
            grdinfo.DataSource = ds.Tables[0];
            grdinfo.DataBind();

        }
        else
        {
            lblerr.Visible = true;
        }
    }
}