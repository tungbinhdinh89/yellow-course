using GitHubRepoCrawler.Models;
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
            List<Repo> repos = [];
            Repo repo = new();

            foreach ( var line in lines)
            {
                if (GetValueFor("\"full_name\"", line, out var FullName))
                {
                    repo = new();
                    repo.FullName = FullName;

                    if (repos.Count < take)
                    {
                        repos.Add(repo);
                    }
                    else
                    {
                        break;
                    }
                }

                else if (GetValueFor("\"html_url\"", line, out var url))
                {
                    repo.Url = url;
                }

                else if (GetValueFor("\"description\"", line, out var desc))
                {
                    repo.Description = desc;
                }

                else if (GetValueFor("\"created_at\"", line, out var createdAt))
                {
                    repo.CreatedAt = createdAt;
                }

                else if (GetValueFor("\"stargazers_count\"", line, out var star))
                {
                    repo.Star = int.Parse(star);
                }

                else if (GetValueFor("\"watchers_count\"", line, out var watch))
                {
                    repo.Watch = int.Parse(watch);
                }

                else if (GetValueFor("\"forks_count\"", line, out var fork))
                {
                    repo.Fork = int.Parse(fork);
                }
            }
            
            return repos;   
        }

         static bool GetValueFor(string name, string line, out string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            value = "";

            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            if(line.Trim().StartsWith($"\"{name}\""))
            {
                value = GetValue(line);
                return true;
            }

            return true;
        }

        static string GetValue(string line)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(line);

            return line.Trim()
                        .Trim(',')
                        .Split(':')
                        .Last()
                        .Trim()
                        .Trim('"')
                        .Trim()
                        ;

        }
    }
}
