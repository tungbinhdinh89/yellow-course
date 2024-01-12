using GithubRepoCrawler.Models;

namespace GithubRepoCrawler.Services
{
    public static class RepoCrawlerService
    {
        // Read file from url Repo
        public static async Task<List<Repo>> SearchRepoGithub(string search, int take)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(search, nameof(search));

            // request api service
            var urlAPI = "https://api.github.com/search/repositories?q=";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C#");

            var response = await httpClient.GetStringAsync(urlAPI+search);
            if (string.IsNullOrWhiteSpace(response))
            {
                return [];
            }

            // read fille
            var lines = response.Split("\n");
            

            return [];
        }
    }
}
