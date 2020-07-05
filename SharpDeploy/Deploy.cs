using System;

namespace SharpDeploy
{
    public class Deployer
    {
        string version;
        
        public Deployer(string version)
        {
            this.version = version;
        }
        
        public void Deploy(string path)
        {
            var git = new GitClient(path);
            string _from = "";
            string to = "";
            var files = git.DiffFiles(_from, to);
        }
    }
}
