using GithubRepoCrawler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepoCrawler.Services
{
    public class GitHubWriteFileService
    {
        public static void WriteRepos(List<Repo> repos, string folder)
        {
            //return [];
            if (repos is null || repos.Count == 0)
            {
                throw new ArgumentException("No repo provided");
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(folder);

        }
    }
}
