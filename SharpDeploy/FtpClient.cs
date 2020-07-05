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
                var p = ExtendedPath.GetPath(file);
                if (p.HasDirectory && !DoesFtpDirectoryExist(p.Directory)) {
                    CreateDirectory(p.Directory);
                }
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
        
        public bool DoesFtpDirectoryExist(string dir)
        {
            try {
                var request = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + dir);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);
                var response = (FtpWebResponse)request.GetResponse();
                return true;
            } catch(WebException ex) {
                return false;
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
    
    public class ExtendedPath
    {
        public string Directory { get; set; }
        public string Filename { get; set; }
        public bool HasDirectory {
            get { return Directory != ""; }
        }
        
        public static ExtendedPath GetPath(string path)
        {
            string filename = Path.GetFileName(path);
            string directory = Path.GetDirectoryName(path);
            
            return new ExtendedPath { Filename = filename, Directory = directory };
        }
    }
}
