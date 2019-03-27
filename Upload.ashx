<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;

public class Upload : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string filename = "";
                string ext = "";
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fn = file.FileName.ToString();
                    ext =  System.IO.Path.GetExtension(fn);
                    filename = DateTime.Now.Ticks.ToString();
                    string fname = context.Server.MapPath("~/media/" + filename+ext);
                    file.SaveAs(fname);
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write(filename+ext);
            }
        }
        catch (Exception e) {
            context.Response.ContentType = "text/plain";
            context.Response.Write(e.Message.ToString());
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}