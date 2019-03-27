using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.IO.Compression;
using System.Globalization;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for BaseClass
/// </summary>
public class BaseClass : System.Web.UI.Page
{
    public BaseClass()
    {
    }
    protected override void OnInit(EventArgs e)
    {  
        if (Session["role"] == null)
            Response.Redirect("~/login.aspx");

        // this needed to initialize its base page class
        base.OnInit(e);
    }
}