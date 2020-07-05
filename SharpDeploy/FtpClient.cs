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
        
        public void Upload(string path, string file)
        {
            using (var client = new WebClient()) {
                client.Credentials = new NetworkCredential(username, password);
                OnUploading(new MessageEventArgs("Uploading " + file + "..."));
                CreateDirectory("test");
                client.UploadFile("ftp://" + host + "/" + file, WebRequestMethods.Ftp.UploadFile, path);
            }
        }
        
        public void CreateDirectory(string directory)
        {
            OnUploading("Creating " + directory + " directory...");
            var request = WebRequest.Create("ftp://" + host + "/" + directory);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(username, password);
            using (var response = (FtpWebResponse)request.GetResponse()) {
                // TODO:
            }
        }
        
        public event EventHandler<MessageEventArgs> Uploading;
        
        protected virtual void OnUploading(string message)
        {
            OnUploading(new MessageEventArgs(message));
        }
        
        protected virtual void OnUploading(MessageEventArgs e)
        {
            if (Uploading != null) {
                Uploading(this, e);
            }
        }
    }
}
