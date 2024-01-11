namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            var repos = RepoService.ReadFile("Repo.txt");
            Console.WriteLine(repos);
            RepoService.WriteToFile(repos, "output");

            Console.WriteLine("File is saved successfully");
            Console.ReadKey();
        }
    }
}
