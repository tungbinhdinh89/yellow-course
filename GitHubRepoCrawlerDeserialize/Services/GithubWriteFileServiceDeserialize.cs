﻿using GitHubRepoCrawler.Models;

namespace GitHubRepoCrawler.Services
{
    public class GitHubWriteFileServiceDeserialize
    {
        public static void WriteRepos(List<Repo> repos, string folder)
        {
            if (repos is null || repos.Count == 0)
            {
                throw new ArgumentException("No repo provided");
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(folder);

            foreach (Repo repo in repos)
            {
                var dir = repo.FullName.Split('/');
                var output = Path.Combine(folder, dir[0]);

                if (!Directory.Exists(output))
                {
                    Directory.CreateDirectory(output);
                }

                var fullPath = Path.Combine(output, $"{dir[1]}.txt");
                File.WriteAllText(fullPath, $"Repo {dir[1]} has {repo.Star} stars, {repo.Watch} watchers, and {repo.Fork} forks");
            }
        }
    }
}
