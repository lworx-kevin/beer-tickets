using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            error.Text = "";
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                email.Text = Request.Cookies["UserName"].Value;
                password.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
        if (IsPostBack) {
             error.Text = "";
        }
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        var user =   email.Text.ToString();
        var pass = password.Text.ToString();

        var NewPwd = Cryption.GetEncryptedSHA256(pass);
        DataTable dt = BAL.Login(user, NewPwd);
        if (dt.Rows.Count > 0)
        {
            Session["login"] = dt.Rows[0][0].ToString();
            Session["role"] = dt.Rows[0][1].ToString();
            Session["permissions"] = dt.Rows[0][2].ToString();
            Session["permissionscsv"] = uniqPermissions(dt.Rows[0][2].ToString());
            Session["UserId"] = dt.Rows[0]["Id"].ToString();
            //get permissions from roles table and store it in session

            if (remember.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = email.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();

            Response.Redirect("default.aspx");
        }
        else {
            error.Text = "Please Check Email And PassWord";
        }
    }

    public string uniqPermissions(string permissions)
    {
        permissions = permissions.Replace("a", "");
        permissions = permissions.Replace("e", "");
        permissions = permissions.Replace("d", "");
        permissions = permissions.Replace("s", "");
        permissions = permissions.Replace("v", ""); 
        permissions = permissions.Replace("p", "");

        List<string> uniqueValues = permissions.Split(',').Where(x => x != string.Empty).Distinct().ToList();
        permissions = string.Join(",", uniqueValues);
        if (permissions == string.Empty) permissions = "0";
        return permissions;
    }
}