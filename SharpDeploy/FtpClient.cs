using System;
using System.IO;
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
        
        public void Upload(string path)
        {
            using (var client = new WebClient()) {
                client.Credentials = new NetworkCredential(username, password);
                string file = Path.GetFileName(path);
                OnUploading(new MessageEventArgs("Uploading " + file + "..."));
                client.UploadFile("ftp://" + host + "/" + file, WebRequestMethods.Ftp.UploadFile, path);
            }
        }
        
        public event EventHandler<MessageEventArgs> Uploading;
        
        protected virtual void OnUploading(MessageEventArgs e)
        {
            if (Uploading != null) {
                Uploading(this, e);
            }
        }
    }
}
