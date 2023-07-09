using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_UpdateStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Label1.Visible = false;
        lblsuucall.Visible = false;
        pnlupdateall.Visible = false;
        Panel1.Visible = false;
        lbl.Visible = false;
        txtupdateprice.Visible = false;
        lblsucc.Visible = false;
        if (ddlname.SelectedItem.Text == "Choose weapon")
        {
            Button1.Visible = false;
        }
        if (ddlname.SelectedItem.Text != "Choose weapon")
        {
            txtupdateprice.Visible = true;
            Button1.Visible = true;
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblupdate.SelectedItem.Text == "Update 1 Item")
        {
            Panel1.Visible = true;
        }
        if (rblupdate.SelectedItem.Text == "Update All Items")
        {
            MySql sqlStore = new MySql();
            DataSet dsStore = new DataSet();
            string stStore1 = "SELECT TblWeapon.ID, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.description FROM TblWeapon;";
            dsStore = sqlStore.testdata(stStore1);
            grdupdateall.DataSource = dsStore.Tables[0];
            grdupdateall.DataBind();
            grdupdateall.HeaderRow.Cells[2].Visible = false;
            for (int i = 0; i < grdupdateall.Rows.Count; i++)
            {
                grdupdateall.Rows[i].Cells[2].Visible = false;
            }
            pnlupdateall.Visible = true;
        }
    }
    protected void grdStore_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdupdateall.PageIndex = e.NewPageIndex;
        //show items on gridview
        MySql sqlStore = new MySql();
        DataSet dsStore = new DataSet();
        string stStore1 = "SELECT TblWeapon.ID, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.description FROM TblWeapon;";
        dsStore = sqlStore.testdata(stStore1);
        grdupdateall.DataSource = dsStore.Tables[0];
        grdupdateall.DataBind();
        grdupdateall.HeaderRow.Cells[2].Visible = false;
        for (int i = 0; i < grdupdateall.Rows.Count; i++)
        {
            grdupdateall.Rows[i].Cells[2].Visible = false;
        }
        pnlupdateall.Visible = true;
    }

    protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlname.SelectedItem.Text == "Choose weapon")
        {
            grdStore.Visible = false;
        }
        if (ddlname.SelectedItem.Text != "Choose weapon")
        {
            grdStore.Visible = true;
        }
        txtupdateprice.Text = "";
        lbl.Visible = false;
        lblBPrice.Visible = false;
        lblsucc.Visible = false;
        MySql sqldisplay = new MySql();
        DataSet dsdisplay = new DataSet();
        string stdisplay = "SELECT TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.ID, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.WeaponName) ='" + ddlname.SelectedItem.Text + "'));";
        dsdisplay = sqldisplay.testdata(stdisplay);
        if (dsdisplay.Tables[0].Rows.Count > 0)
        {
            grdStore.DataSource = dsdisplay.Tables[0];
            grdStore.DataBind();
        }
        grdStore.HeaderRow.Cells[2].Visible = false;
        for (int i = 0; i < grdStore.Rows.Count; i++)
        {
            grdStore.Rows[i].Cells[2].Visible = false;
        }
        lblBPrice.Text = dsdisplay.Tables[0].Rows[0][0].ToString();
        Panel1.Visible = true;
    }
    protected void rblRace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlname.Items.Count > 1)
        {
            for (int i = 0; i < ddlname.Items.Count; i++)
            {
                ddlname.Items.Clear();
            }
            ddlname.Items.Add("Choose weapon");
        }
        lblBPrice.Visible = false;
        txtupdateprice.Visible = false;
        Button1.Visible = false;
        grdStore.Visible = false;
        MySql sqlrace = new MySql();
        DataSet dsrace = new DataSet();
        string strace = "SELECT TblWeapon.WeaponName FROM TblWeapon WHERE(((TblWeapon.Race) ='" + rblRace.SelectedValue.ToString() + "'));";
        dsrace = sqlrace.testdata(strace);
        for (int i = 0; i < dsrace.Tables[0].Rows.Count; i++)
        {
            ddlname.Items.Add(dsrace.Tables[0].Rows[i][0].ToString());
        }
        Panel1.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySql sqlStore = new MySql();
        DataSet dsStore = new DataSet();
        DataSet dsPrice = new DataSet();
        string stcheekprice = "SELECT TblWeapon.Price FROM TblWeapon WHERE(((TblWeapon.WeaponName) ='" + ddlname.SelectedItem.Text + "'));";
        string stStore1 = "UPDATE TblWeapon SET TblWeapon.Price ='" + txtupdateprice.Text + "' WHERE(((TblWeapon.WeaponName) ='" + ddlname.SelectedValue.ToString() + "'));";
        dsPrice = sqlStore.testdata(stcheekprice);
        lblBPrice.Text = dsPrice.Tables[0].Rows[0][0].ToString();
        dsStore = sqlStore.testdata(stStore1);
        lblBPrice.Visible = true;
        lbl.Visible = true;
        lblsucc.Visible = true;
        MySql sqldisplay = new MySql();
        DataSet dsdisplay = new DataSet();
        string stdisplay = "SELECT TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.ID, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.WeaponName) ='" + ddlname.SelectedItem.Text + "'));";
        dsdisplay = sqldisplay.testdata(stdisplay);
        if (dsdisplay.Tables[0].Rows.Count > 0)
        {
            grdStore.DataSource = dsdisplay.Tables[0];
            grdStore.DataBind();
        }
        grdStore.HeaderRow.Cells[2].Visible = false;
        for (int i = 0; i < grdStore.Rows.Count; i++)
        {
            grdStore.Rows[i].Cells[2].Visible = false;
        }
        Panel1.Visible = true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        MySql sqlprice = new MySql();
        DataSet dsPrice = new DataSet();
        string stcheekprice = "SELECT TblWeapon.ID, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.description FROM TblWeapon;";
        dsPrice = sqlprice.testdata(stcheekprice);
        for (int i = 0; i < dsPrice.Tables[0].Rows.Count; i++)
        {
            MySql sqlnewprice = new MySql();
            DataSet dsnewPrice = new DataSet();
            string stUser = "SELECT TblWeapon.ID, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description, TblWeapon.ImgSource FROM TblWeapon WHERE(((TblWeapon.ID) = " + dsPrice.Tables[0].Rows[i][0].ToString() + "));";
            dsnewPrice = sqlnewprice.testdata(stUser);
            MySql sqlupdateprice = new MySql();
            double price = int.Parse(dsnewPrice.Tables[0].Rows[0][3].ToString());
            double maha = 100;
            double precent =double.Parse(txtupdateall.Text);
            if (rblPrecent.SelectedItem.Text == "Price increase")
            {
                MySql sqlupdprice = new MySql();
                double newprice = (precent / maha) *price+price;
                string updateprice = "UPDATE TblWeapon SET TblWeapon.Price =" + newprice + " WHERE(((TblWeapon.ID) =" + dsnewPrice.Tables[0].Rows[0][0].ToString() + "));";
                sqlupdprice.updelin(updateprice);
            }
            else
            {
                double newprice = price - (precent / maha) * price ;
                string updateprice = "UPDATE TblWeapon SET TblWeapon.Price = " + newprice + " WHERE(((TblWeapon.ID) =" + dsnewPrice.Tables[0].Rows[0][0].ToString() + "));";
                sqlprice.updelin(updateprice);
            }
        }
        MySql sqlStore = new MySql();
        DataSet dsStore = new DataSet();
        string stStore1 = "SELECT TblWeapon.ID, TblWeapon.WeaponImg, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.description FROM TblWeapon;";
        dsStore = sqlStore.testdata(stStore1);
        grdupdateall.DataSource = dsStore.Tables[0];
        grdupdateall.DataBind();
        grdupdateall.HeaderRow.Cells[2].Visible = false;
        for (int i = 0; i < grdupdateall.Rows.Count; i++)
        {
            grdupdateall.Rows[i].Cells[2].Visible = false;
        }
        lblsuucall.Visible = true;
        pnlupdateall.Visible = true;
    }

    protected void rblPrecent_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlupdateall.Visible = true;
    }
}