using GitHubRepoCrawler.Models;
namespace GitHubRepoCrawler.Services
{
    public static class RepoCrawlerService
    {
        // Read file from url Repo
        public static async Task<List<Repo>> SearchRepoGitHub(string search, int take)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(search);

            // todo: encode whitespace name
            var encodedSearch = Uri.EscapeDataString(search);

            var urlAPI = $"https://api.github.com/search/repositories?q={encodedSearch}";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            var response = await httpClient.GetStringAsync($"{urlAPI}");
            if (string.IsNullOrWhiteSpace(response))
            {
                return new List<Repo>();
            }

            //read file
            var lines = response.Split("\n");
            List<Repo> repos = [];
            Repo repo = new();

            foreach (var line in lines)
            {
                if (GetValueFor("full_name", line, out var name))
                {
                    repo = new();
                    repo.FullName = name;
                   
                }
                else if (GetValueFor("html_url", line, out var url)) 
                {
                    // todo: duplicate with owner url
                    repo.Url = url;
                }
                else if (GetValueFor("description", line, out var desc))
                {
                    repo.Description = desc;
                }
                else if (GetValueFor("created_at", line, out var createdAt))
                {
                    repo.CreatedAt = createdAt;
                }
                else if (GetValueFor("stargazers_count", line, out var star))
                {
                    repo.Star = int.Parse(star);
                }
                else if (GetValueFor("watchers_count", line, out var watch))
                {
                    repo.Watch = int.Parse(watch);
                }
                else if (GetValueFor("forks", line, out var fork))
                {
                    repo.Fork = int.Parse(fork);
                    repos.Add(repo);
                }
            }
            return repos.Take(take).ToList();
        }

        static bool GetValueFor(string name, string line, out string value)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name);
            value = "";

            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            if (line.Trim().StartsWith($"\"{name}\""))
            {
                value = GetValue(line);
                return true;
            }

            return false;
        }

        static string GetValue(string line)
        {
            return line
                .Trim() 
                .Trim(',') 
                .Split(':')
                .Last()
                .Trim()
                .Trim('"')
                .Trim();
        }
    }
}
