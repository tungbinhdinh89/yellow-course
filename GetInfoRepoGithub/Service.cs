using Newtonsoft.Json.Linq;

namespace GetInfoRepoGithub
{
    public class Service
    {
        public static async Task<JArray> ReadReposFromUrl(string repo)
        {
            string urlAPI = $"https://api.github.com/search/repositories?q= + {repo}";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");

            var response = await httpClient.GetAsync(urlAPI);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to retrieve data. Status code: {response.StatusCode}");
            }

            string content = await response.Content.ReadAsStringAsync();

            // Take 10 element from api
            // Parse the JSON response
            JObject data = JObject.Parse(content);

            // Access the "items" array
            JArray items = (JArray)data["items"];

            // Take the first 10 elements
            JArray first10Items = new JArray(items.Take(10));
            //

            return first10Items;
        }

        public static List<Repo> ParseRepos(string path)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            var lines = File.ReadAllLines(path);
            if (lines is null || lines.Length == 0)
            {
                return [];
            }

            List<Repo> repos = [];
            Repo repo = new();

            foreach (var line in lines)
            {
                string[] parts = line.Split(new[] { "," }, StringSplitOptions.None);
                foreach (var part in parts.Take(10))
                {
                    var current = part.Trim();

                    if (current.StartsWith("\"name\""))
                    {
                        repo = new Repo();
                        repo.name = GetValue(current);
                    }
                    if (current.StartsWith("\"full_name\""))
                    {
                        repo.fullName = GetValue(current);
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
            }
            return repos;
        }

        public static string GetValue(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var arr = input
                .Trim()
                .TrimEnd(',')
                .Split(':');

            var value = arr.Last()
                .Trim()
                .Trim('"');

            return value;
        }

        public static void WriteToFile(List<Repo> repos, string folder)
        {
            if (repos == null || repos.Count == 0) return;
            foreach (Repo repo in repos)
            {
                string[] parts = repo.fullName.Split('/');
                var output = Path.Combine(folder, parts[0]);
                if (!Directory.Exists(output))
                {
                    Directory.CreateDirectory(output);
                }
                var fullName = repo.name.Replace('/', '\\');

                var path = Path.Combine(output, parts[1] + ".txt");

                Console.WriteLine($"Writing to file: {path}");

                File.WriteAllText(path, $"Full name is: {repo.fullName}, Name is: {repo.name}, Url is: {repo.url}, Description is: {repo.description}, Created At is: {repo.createdAt}, Star is: {repo.star}, Watch is: {repo.watch}, Fork is: {repo.fork}");
            }
        }
    }
}
