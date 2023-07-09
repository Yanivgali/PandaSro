using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;


public partial class YanivProject_StoreTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            MySql sqlUser = new MySql();
            DataSet ds = new DataSet();
            string stUser = "SELECT TblWeapon.id, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon;";
            ds = sqlUser.testdata(stUser);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                f1_container.InnerHtml += "<div id='f1_container" + i + "' style='float:left; position: relative; margin: 10px auto; width: 242px; height: 360px; z-index: 1; margin: 20px 0px 0px -10px; border:groove; margin-left:10%; perspective: 1000px;'><div id='f1_card" + i + "' style='width: 98%; height: 98%; transform-style: preserve-3d; transition: all 1.2s linear;'><strong id='" + i + "' style='color:white;  margin-left: 30%;'>" + ds.Tables[0].Rows[i][2].ToString() + "</strong><hr class='style - two'/><lable style='width:22px; margin-left:0px; color:white;'>Price</lable><lable name='" + i + "' id='TextBox" + i + "' style='width:22px; margin-left:7px; color:white;'>" + ds.Tables[0].Rows[i][3].ToString() + ":</lable><span  dir='rtl' id='Lblname" + i + "' style='margin-right:10px; float:right; color:red;'>" + ds.Tables[0].Rows[i][1].ToString() + "</span><span  dir='rtl' id='Lblname" + i + "' style='margin-right:10px; color:white;'>" + ds.Tables[0].Rows[i][5].ToString() + "</span><div class='flip-card'><div class='flip-card-inner'><div class='flip-card-front'><img id='Image" + i + "' src='/YanivProject/Pictures/zWeapons/" + ds.Tables[0].Rows[i][4].ToString() + "' style='height:205px;width:100%;border-width:0px; margin-left:3px; margin-top:23px;' /></div><div class='flip-card-back'><h1 style='color:green;'>" + ds.Tables[0].Rows[i][2].ToString() + "</h1><p style='color:white;'>" + ds.Tables[0].Rows[i][5].ToString() + "</p></div></div></div><a  href='Store.aspx?id=" + ds.Tables[0].Rows[i][0].ToString() + "' action='myForm.jsp' method='POST' onClientClick='return true' onClick='reply_click(this.id)' id='AddToStore" + i + "' class='AddToStore' style='border: none; outline: 0; padding: 12px; color: white; background-color: #000; text-align: center; cursor: pointer; width: 100%; font-size: 18px; margin-top:230px;'>Add to Cart</a></div></div>";
            }
            if (Session["User"] != null && Request.QueryString["id"] != null)
            {
                MySql sqlusid = new MySql();
                DataSet dsusid = new DataSet();
                string stusid = "SELECT TblUser.[ID] FROM TblUser WHERE(((TblUser.[UserName]) ='" + Session["User"] + "'));";
                dsusid = sqlusid.testdata(stusid);
                Session["Userid"] = dsusid.Tables[0].Rows[0][0].ToString();
                MySql sqlitem = new MySql();
                DataSet dsitem = new DataSet();
                string stitem = "SELECT TblShoppingCart.Amount,TblShoppingCart.OrderId FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + ") AND((TblShoppingCart.ProtuctID) =" + Request.QueryString["id"] + "));";
                dsitem = sqlitem.testdata(stitem);
                int i;
                for (i = 0; i < dsitem.Tables[0].Rows.Count; i++)
                {
                    if (dsitem.Tables[0].Rows.Count > 0 && int.Parse(dsitem.Tables[0].Rows[i][0].ToString()) < 5)
                    {
                        int addone = 1;
                        string amount = (int.Parse(dsitem.Tables[0].Rows[i][0].ToString()) + addone).ToString();
                        MySql sqlupdstore = new MySql();
                        string stupdstore = "UPDATE TblShoppingCart SET TblShoppingCart.Amount = '" + amount + "' WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + ") AND ((TblShoppingCart.OrderId)=" + dsitem.Tables[0].Rows[i][1].ToString() + ") AND((TblShoppingCart.ProtuctID) =" + Request.QueryString["id"] + "));";
                        sqlupdstore.updelin(stupdstore);
                        i = dsitem.Tables[0].Rows.Count - 1;
                    }
                }
                if (i != 0)
                {
                    if (int.Parse(dsitem.Tables[0].Rows[i - 1][0].ToString()) >= 5)
                    {
                        MySql sqlAddtocart1 = new MySql();
                        DataSet dsAddtocart1 = new DataSet();
                        string stAddtocart1 = "SELECT TblWeapon.WeaponImg, TblWeapon.Price FROM TblWeapon WHERE(((TblWeapon.ID) = " + Request.QueryString["id"] + "));";
                        dsAddtocart1 = sqlAddtocart1.testdata(stAddtocart1);
                        string img = "Pictures/zWeapons/" + dsAddtocart1.Tables[0].Rows[0][0].ToString();
                        char one = '1';
                        MySql sqlAddtocart = new MySql();
                        DataSet dsAddtocart = new DataSet();
                        string stAddtocart = "INSERT INTO TblShoppingCart(UserId, ProtuctID, Weaponimg, Price, Amount) values (" + Session["Userid"] + ", " + Request.QueryString["id"] + ",'" + img + "','" + dsAddtocart1.Tables[0].Rows[0][1].ToString() + "','" + one + "');";
                        dsAddtocart = sqlAddtocart.testdata(stAddtocart);
                    }
                }
                if (dsitem.Tables[0].Rows.Count == 0)
                {
                    MySql sqlAddtocart1 = new MySql();
                    DataSet dsAddtocart1 = new DataSet();
                    string stAddtocart1 = "SELECT TblWeapon.WeaponImg, TblWeapon.Price FROM TblWeapon WHERE(((TblWeapon.ID) = " + Request.QueryString["id"] + "));";
                    dsAddtocart1 = sqlAddtocart1.testdata(stAddtocart1);
                    string img = "Pictures/zWeapons/" + dsAddtocart1.Tables[0].Rows[0][0].ToString();
                    char one = '1';
                    MySql sqlAddtocart = new MySql();
                    DataSet dsAddtocart = new DataSet();
                    string stAddtocart = "INSERT INTO TblShoppingCart(UserId, ProtuctID, Weaponimg, Price, Amount) values (" + Session["Userid"] + ", " + Request.QueryString["id"] + ",'" + img + "','" + dsAddtocart1.Tables[0].Rows[0][1].ToString() + "','" + one + "');";
                    dsAddtocart = sqlAddtocart.testdata(stAddtocart);
                    
                }
                Response.Redirect("Store.aspx");

            }
            if (Session["User"] == null && Request.QueryString["id"] != null)
            {
                Response.Redirect("Store.aspx");
            }
        }

    }
}