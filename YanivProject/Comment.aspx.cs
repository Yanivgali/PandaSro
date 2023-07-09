using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class YanivProject_Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblerr.Visible = false;
        txtDate.Text = DateTime.Now.ToString();
        lblSucc.Visible = false;
        if (Session["User"] != null)
        {
            MySql sqlMail = new MySql();
            DataSet dsMail = new DataSet();
            string stMail = "SELECT TblUser.UserName, TblUser.Email FROM TblUser WHERE(((TblUser.UserName) ='" + Session["User"] + "'));";
            dsMail = sqlMail.testdata(stMail);
            txtMail.Text = dsMail.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (ddlCommentType.Text != "בחר סוג תגובה")
        {

            MySql sqlComment = new MySql();
            DataSet dsComment = new DataSet();
            string stComment = "insert into tblComment(Mail, CommentDate, CommentType, CommentContent) values('" + txtMail.Text + "', '" + txtDate.Text + "', '" + ddlCommentType.SelectedItem.Value + "', '" + txtComment.Text + "')";
            sqlComment.updelin(stComment);
            lblSucc.Visible = true;
        }
        else
        {
            lblerr.Visible = true;
        }
    }
}