using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_DeletefromStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        MySql sqlComments = new MySql();
        DataSet dsComments = new DataSet();
        string stComments = "SELECT TblWeapon.id, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon;";
        dsComments = sqlComments.testdata(stComments);
        grdWeapons.DataSource = dsComments.Tables[0];
        grdWeapons.DataBind();
        grdWeapons.HeaderRow.Cells[6].Visible = false;
        for (int i = 0; i < grdWeapons.Rows.Count; i++)
        {
            grdWeapons.Rows[i].Cells[6].Visible = false;
        }
    }
    protected void grdWeapons_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdWeapons.PageIndex = e.NewPageIndex;
        //show items on gridview
        MySql sqlcart1 = new MySql();
        DataSet dscart1 = new DataSet();
        string stComments = "SELECT TblWeapon.id, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon;";
        dscart1 = sqlcart1.testdata(stComments);
        grdWeapons.DataSource = dscart1.Tables[0];
        grdWeapons.DataBind();
        grdWeapons.HeaderRow.Cells[6].Visible = false;
        for (int i = 0; i < grdWeapons.Rows.Count; i++)
        {
            grdWeapons.Rows[i].Cells[6].Visible = false;
        }
    }
    protected void grdWeapons_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        MySql sqlDel = new MySql();
        string ID = grdWeapons.Rows[row].Cells[2].Text;
        string stDel = "DELETE TblWeapon.ID, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.ID) =" + ID + "));";
        sqlDel.updelin(stDel);
        Response.Redirect("DeletefromStore.aspx");
    }
}