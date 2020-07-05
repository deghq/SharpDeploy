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
        
        public void Deploy()
        {
            var git = new GitClient(".");
            string _from = "";
            string _to;
            var files = git.DiffFiles(_from, to);
        }
    }
}
