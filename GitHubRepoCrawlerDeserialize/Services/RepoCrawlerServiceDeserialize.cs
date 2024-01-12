using GitHubRepoCrawler.Models;
using Newtonsoft.Json;
using System.Text.Json;
namespace GitHubRepoCrawler.Services
{
    public static class RepoCrawlerServiceDeserialize
    {
        // Read file from url Repo
        public static async Task<List<Repo>> SearchRepoGitHub(string search, int take)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(search);
            var encodedSearch = Uri.EscapeDataString(search);

            var urlAPI = $"https://api.github.com/search/repositories?q={encodedSearch}";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            var response = await httpClient.GetStringAsync($"{urlAPI}");
            if (string.IsNullOrWhiteSpace(response))
            {
                return new List<Repo>();
            }

            List<Repo> repos = new List<Repo>();

            var jsonDoc = JsonDocument.Parse(response);

            foreach (var item in jsonDoc.RootElement.GetProperty("items").EnumerateArray())
            {
                var repo = new Repo
                {
                    FullName = item.GetProperty("full_name").GetString(),
                    Url = item.GetProperty("html_url").GetString(),
                    Description = item.GetProperty("description").GetString(),
                    CreatedAt = item.GetProperty("created_at").GetString(),
                    Star = item.GetProperty("stargazers_count").GetInt32(),
                    Watch = item.GetProperty("watchers_count").GetInt32(),
                    Fork = item.GetProperty("forks_count").GetInt32()
                };

                repos.Add(repo);
            }
            return repos.Take(take).ToList();
        }

    }
}
