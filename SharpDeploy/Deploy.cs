using System;
using System.IO;

namespace SharpDeploy
{
    public class Deployer
    {
        string path;
        string host;
        string username;
        string password;
        
        public Deployer(string path, string host, string username, string password)
        {
            this.path = path;
            this.host = host;
            this.username = username;
            this.password = password;
        }
        
        public void Deploy(string _from, string to)
        {
            var git = new GitClient(path);
            var files = git.DiffFiles(_from, to);
            
            var ftp = new FtpClient(host, username, password);
            ftp.Uploading += delegate(object sender, MessageEventArgs e) { 
                OnDeploying(e);
            };
            
            foreach (var f in files) {
                string filename = Path.Combine(path, f);
                
                OnDeploying(new MessageEventArgs("Deploying " + filename + "..."));
                string file = filename.Replace(path + "\\", "");
                ftp.Upload(filename, file);
            }
        }
        
        public event EventHandler<MessageEventArgs> Deploying;
        
        protected virtual void OnDeploying(MessageEventArgs e)
        {
            if (Deploying != null) {
                Deploying(this, e);
            }
        }
    }
    
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        
        public MessageEventArgs(string message) 
        {
            this.Message = message;
        }
    }
}
