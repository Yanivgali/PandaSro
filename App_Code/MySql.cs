using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// מרחב השמות בה נמצאת המחלקה דאטה סט(DataSet)
using System.Data;
// מרחה השמות בה נמצאים המחלקות המטפלות בבסיס הנתונים
using System.Data.OleDb;

/// <summary>
/// Summary description for MySql
/// </summary>
public class MySql
{
    //פעולה ששולפת נתונים מבסיס הנתונים
    public DataSet testdata(string sqlstr)
    {
        string path = HttpContext.Current.Server.MapPath("~/App_Data/");
        string fileName = "YanivGali_DB.mdb";
        path += fileName;
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    //פעולה -עדכון,מחיקה והכנסה
    public void updelin(string sqlstr)
    {
        string path = HttpContext.Current.Server.MapPath("~/App_Data/");
        string fileName = "YanivGali_DB.mdb";
        path += fileName;
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand build = new OleDbCommand(sqlstr, conn);
        conn.Open();
        build.ExecuteNonQuery();
        conn.Close();
    }
}
