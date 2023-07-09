using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class YanivProject_AddToStore : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=D:\YanivGaliProject\App_Data\YanivGali_DB.mdb;Persist Security Info=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        img.Visible = false;
        lblSucc.Visible = false;
        lblrace.Visible = false;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {

        if (ddlrace.SelectedItem.Value == "Choose Race")
        {
            lblrace.Visible = true;
        }
        else
        {

            MySql sqlStore = new MySql();
            DataSet dsStore = new DataSet();
            string stStore = "insert into TblWeapon( WeaponName, Price, Race, WeaponImg, description, ImgSource) values('" + txtname.Text + "', '" + txtprice.Text + "', '" + ddlrace.SelectedItem.Value + "','" +ddlrace.SelectedItem.Text+"/"+ f1.FileName.ToString() + "','" + txtdescription.Value + "','" + txtweaponurl.Text + "')";
            sqlStore.updelin(stStore);
            lblSucc.Visible = true;
            lblrace.Visible = false;
            f1.SaveAs(Request.PhysicalApplicationPath + "/YanivProject/Pictures/zWeapons/" + ddlrace.SelectedItem.Text + "/" + f1.FileName.ToString());
        }
    }
}