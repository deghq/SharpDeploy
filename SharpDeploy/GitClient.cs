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
        
        public List<string> DiffFiles()
        {
            var files = new List<string>();
            
            foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                                          DiffTargets.Index | DiffTargets.WorkingDirectory)) {
                files.Add(c.Path);
            }
            return files;
        }
    }
}
