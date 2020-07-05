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
        
        public List<string> DiffFiles(string shaFrom)
        {
            return DiffFiles(shaFrom, "");
        }
        
        public List<string> DiffFiles(string shaFrom, string shaTo)
        {
            var files = new List<string>();
            
            var from = repo.Lookup<Commit>(shaFrom).Tree;
//            Tree to = DiffTargets.WorkingDirectory;
            TreeChanges treeChanges = null;
            if (shaTo != "") {
//                to = repo.Lookup<Commit>(shaTo).Tree;
                treeChanges = repo.Diff.Compare<TreeChanges>(from, repo.Lookup<Commit>(shaTo).Tree);
            } else {
                treeChanges = repo.Diff.Compare<TreeChanges>(from, repo.Head.Tip.Tree);
            }
            
            foreach (TreeEntryChanges c in treeChanges) {
                files.Add(c.Path);
            }
            return files;
        }
    }
}
