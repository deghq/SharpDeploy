using System;
using System.Collections.Generic;
using LibGit2Sharp;

namespace SharpDeploy
{
    public class GitClient
    {
        Repository repo;
        
        public GitClient(string path)
        {
            repo = new Repository(path);
        }
        
        public List<string> DiffFiles(string shaFrom, string shaTo)
        {
            var files = new List<string>();
            
//            var from = repo.Head.Tip.Tree;
//            var to = DiffTargets.WorkingDirectory;
            
            var from = repo.Lookup<Commit>(shaFrom);
            var to = repo.Lookup<Commit>(shaTo);
            
            foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(from.Tree, to.Tree)) {
                files.Add(c.Path);
            }
            return files;
        }
    }
}
