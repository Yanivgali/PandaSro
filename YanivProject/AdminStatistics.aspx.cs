using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class YanivProject_AdminStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        MySql sqlstatistics = new MySql();
        DataSet dsstatistics = new DataSet();
        string ststatistics = "SELECT First(TblUser.UserName) AS UserNameWhomadethelargestamountofpurchases, Max(TblOrder.ProtuctID) AS MaxOfpurchasedproductId, Min(TblOrder.ProtuctID) AS MinOfpurchasedproductId FROM TblUser INNER JOIN TblOrder ON TblUser.ID = TblOrder.UserId;";
        dsstatistics = sqlstatistics.testdata(ststatistics);
        if (dsstatistics.Tables[0].Rows.Count > 0)
        {
               grdstatistics.DataSource = dsstatistics.Tables[0];
               grdstatistics.DataBind();
        }
    }
}