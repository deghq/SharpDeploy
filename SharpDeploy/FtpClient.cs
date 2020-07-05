using System;
using System.Net;

namespace SharpDeploy
{
    public class FtpClient
    {
        string host;
        string username;
        string password;
        
        public FtpClient(string host, string username, string password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
        }
        
        public void Upload(string filename)
        {
            using (var client = new WebClient()) {
                client.Credentials = new NetworkCredential(username, password);
                client.UploadFile("ftp://" + host + "/" + filename, WebRequestMethods.Ftp.UploadFile, filename);
            }
        }
    }
}
