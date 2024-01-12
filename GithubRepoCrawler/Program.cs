using GitHubRepoCrawler.Services;

namespace GitHubRepoCrawler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter your repo: ");
            var search = Console.ReadLine()!;
            var repos = await RepoCrawlerService.SearchRepoGitHub(search, 10);

            Console.Write("Enter your name of directory output: ");
            var nameDir = Console.ReadLine()!;
            GitHubWriteFileService.WriteRepos(repos, nameDir);
            Console.WriteLine("Save file success");

            Console.ReadKey();
        }
    }
}
