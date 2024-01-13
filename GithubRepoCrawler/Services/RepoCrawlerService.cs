using GitHubRepoCrawler.Models;
namespace GitHubRepoCrawler.Services
{
    public static class RepoCrawlerService
    {
        // Read file from url Repo
        public static async Task<List<Repo>> SearchRepoGitHub(string search, int take)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new ArgumentNullException(search);
            }
            var encodedSearch = Uri.EscapeDataString(search);

            var urlAPI = $"https://api.github.com/search/repositories?q={encodedSearch}";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            var response = await httpClient.GetStringAsync(urlAPI);

            if (string.IsNullOrWhiteSpace(response)) return new List<Repo>();

            List<Repo> repos = [];
            Repo repo = new Repo();

            var lines = response.Split("\n");

            foreach (var line in lines)
            {
                if (GetStringValueFor("full_name", line, out var name))
                {
                    repo = new Repo { FullName = name };

                }
                else if (GetStringValueFor("html_url", line, out var url))
                {
                    repo.Url = url;
                }
                else if (GetStringValueFor("description", line, out var desc))
                {
                    repo.Description = desc;
                }
                else if (GetStringValueFor("created_at", line, out var createdAt))
                {
                    repo.CreatedAt = createdAt;
                }
                else if (GetStringValueFor("stargazers_count", line, out var star))
                {
                    repo.Star = int.Parse(star);
                }
                else if (GetStringValueFor("watchers_count", line, out var watch))
                {
                    repo.Watch = int.Parse(watch);
                }
                else if (GetStringValueFor("forks", line, out var fork))
                {
                    repo.Fork = int.Parse(fork);
                    repos.Add(repo);
                }
            }
            return repos.Take(take).ToList();
        }

        static bool GetStringValueFor(string name, string line, out string value)
        {
            value = "Some value";

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            if (line.Trim().StartsWith($"\"{name}\""))
            {
                value = GetStringValue(line);
                return true;
            }

            return false;
        }

        static string GetStringValue(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException(line);
            }

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
