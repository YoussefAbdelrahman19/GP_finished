using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace GradProjectV5
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    for (int i = 0; i < context.Request.Files.Count; i++)
                    {
                        HttpPostedFile postedFile = context.Request.Files[i];

                        string savepath = "";
                        string tempPath = "uploads";
                         
                        savepath = context.Server.MapPath(tempPath);
                     

                        string filename = RandomString(4)+"_" + postedFile.FileName;
                        
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        string FileNameNoSpace = String.Concat(filename.Where(c => !Char.IsWhiteSpace(c)));
                        postedFile.SaveAs(savepath + @"\" + FileNameNoSpace);

                        context.Response.Write(FileNameNoSpace);
                        context.Response.StatusCode = 200;
                    }

                }
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        
    }
}