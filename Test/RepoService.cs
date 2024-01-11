using GetInfoRepoGithub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class RepoService
    {
        public static void WriteToFile(List<Repo> repos, string folder)
        {
            Console.WriteLine("tada");
            if (repos == null || repos.Count == 0) return;
            foreach (Repo repo in repos)
            {
              
                var output = Path.Combine(folder, repo.name);
                if (!Directory.Exists(output))
                {
                    Directory.CreateDirectory(output); 
                }

                var path = Path.Combine(output, repo.name + ".txt"); 
                File.WriteAllText(path, $"{repo.name} is {repo.star} years old");
            }
        }

        public static List<Repo> ReadFile(string path)
        {
            //check input
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            // read all lines
            var lines = File.ReadAllLines(path);
            if (lines is null || lines.Length == 0)
            {
                return [];
            }

            List<Repo> repos = [];
            Repo repo = new();

            string current;
            foreach (var line in lines.Take(10))
            {
                 current = line.Trim();

                if (current.StartsWith("\"name\""))
                {
                    repo = new Repo();
                    repo.name = GetValue(current);
                }
                else if (current.StartsWith("\"html_url\""))
                {
                    repo.url = GetValue(current);
                }
                else if (current.StartsWith("\"description\""))
                {
                    repo.description = GetValue(current);
                }
                else if (current.StartsWith("\"created_at\""))
                {
                    repo.createdAt = GetValue(current);
                }
                else if (current.StartsWith("\"stargazers_count\""))
                {
                    repo.star = int.Parse(GetValue(current));
                }
                else if (current.StartsWith("\"watchers_count\""))
                {
                    repo.watch = int.Parse(GetValue(current));
                }
                else if (current.StartsWith("\"forks_count\""))
                {
                    repo.fork = int.Parse(GetValue(current));
                    repos.Add(repo);
                }
            }
            return repos;
        }

        public static string GetValue(string input)
        {
            //  "name": "John",
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var arr = input
                .Trim() // "  xxx:aaa,   " -> "xxx:aaa,"
                .TrimEnd(',') // "xxx:aaa," -> "xxx:aaa"
                .Split(':'); // "xxx:aaa" -> ["xxx", "aaa"]

            var value = arr.Last()
                .Trim()
                .Trim('"'); // " \"James\" "

            return value;
        }


    }
}
