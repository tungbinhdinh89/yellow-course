using GitHubRepoCrawler.Services;

namespace GitHubRepoCrawlerDeserialize
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter your repo: ");
            var search = Console.ReadLine()!;
            var repos = await RepoCrawlerServiceDeserialize.SearchRepoGitHub(search, 10);

            Console.Write("Enter your name of directory output: ");
            var nameDir = Console.ReadLine()!;
            GitHubWriteFileServiceDeserialize.WriteRepos(repos, nameDir);
            Console.WriteLine("Save file success");

            Console.ReadKey();
        }
    }
}
