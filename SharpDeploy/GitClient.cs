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
        
        public List<string> DiffFiles(string _from, string to)
        {
            var files = new List<string>();
            
//            foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
//                                                                          DiffTargets.Index | DiffTargets.WorkingDirectory)) {
//                Console.WriteLine(c.Path);
//            }

CommitFilter cf = new CommitFilter
    {
        SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
        ExcludeReachableFrom = repo.Branches["develop"].Tip,
        IncludeReachableFrom = repo.Head.Tip
    };

    var results = repo.Commits.QueryBy(cf);

    foreach (var result in results)
    {
        //Process commits here.
        Console.WriteLine(result);
    }
            
            return files;
        }
    }
}
