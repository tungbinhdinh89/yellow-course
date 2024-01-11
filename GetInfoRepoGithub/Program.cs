namespace GetInfoRepoGithub
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var reposString = await Service.ReadReposFromUrl("dotnet");

            string filePath = @"Repos.txt";
            File.WriteAllText(filePath, reposString.ToString());

            var parseRepo = Service.ParseRepos("Repos.txt");
            Service.WriteToFile(parseRepo, "Output");

            Console.WriteLine("File is saved successfully");
            Console.ReadKey();
        }
    }
}
