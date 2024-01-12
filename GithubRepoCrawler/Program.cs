using GithubRepoCrawler.Services;
using GitHubRepoCrawler.Services;

namespace GitHubRepoCrawler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your repo");
            var search = Console.ReadLine()!;
            var repos = await RepoCrawlerService.SearchRepoGithub(search, 10);
                
            GitHubWriteFileService.WriteRepos(repos, "download");
               Console.ReadKey();
        }
    }
}
