using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.Common.Handlers
{
    using System;
    using System.IO;
    using System.Web;

    public class FLVStreaming : IHttpHandler
    {
        private static readonly byte[] _flvheader = HexToByte("464C5601010000000900000009");

        public FLVStreaming()
        {
        }

        public void ProcessRequest(HttpContext context)
    {
        try
        {
            int pos;
            int length;

            // Check start parameter if present
            string filename = Path.GetFileName(context.Request.FilePath);

            using (FileStream fs = new FileStream(context.Server.MapPath(filename), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string qs = context.Request.Params["start"];

                if (string.IsNullOrEmpty(qs))
                {
                    pos = 0;
                    length = Convert.ToInt32(fs.Length);
                }
                else
                {
                    pos = Convert.ToInt32(qs);
                    length = Convert.ToInt32(fs.Length - pos) + _flvheader.Length;
                }

                // Add HTTP header stuff: cache, content type and length        
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetLastModified(DateTime.Now);

                context.Response.AppendHeader("Content-Type", "video/x-flv");
                context.Response.AppendHeader("Content-Length", length.ToString());

                // Append FLV header when sending partial file
                if (pos > 0)
                {
                    context.Response.OutputStream.Write(_flvheader, 0, _flvheader.Length);
                    fs.Position = pos;
                }

                // Read buffer and write stream to the response stream
                const int buffersize = 16384;
                byte[] buffer = new byte[buffersize];
                
                int count = fs.Read(buffer, 0, buffersize);
                while (count > 0)
                {
                    if (context.Response.IsClientConnected)
                    {
                        context.Response.OutputStream.Write(buffer, 0, count);
						
						//Starts sending to client right away
						context.Response.Flush();
			
                        count = fs.Read(buffer, 0, buffersize);
                    }
                    else
                    {
                        count = -1;
                    }
                }
                context.Response.Close();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

        public bool IsReusable
        {
            get { return true; }
        }

        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

    }
}
