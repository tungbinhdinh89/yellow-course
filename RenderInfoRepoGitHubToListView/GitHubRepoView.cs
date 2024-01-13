using RenderInfoRepoGitHubToListView.Models;
using RenderInfoRepoGitHubToListView.Services;

namespace RenderInfoRepoGitHubToListView
{
    public partial class GitHubRepoView : Form
    {
        private GitHubRepoCrawlerService crawlerRepoService = new GitHubRepoCrawlerService();
        public GitHubRepoView()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            var repos = await crawlerRepoService.SearchRepoGitHub(search, 10);
             RenderToListView(repos);

        }

        private void RenderToListView(List<Repo> repos)
        {
            lvRepoList.Items.Clear();

            foreach (var repo in repos)
            {
                ListViewItem item = new ListViewItem(repo.Name);
                item.SubItems.Add(repo.Url);
                item.SubItems.Add(repo.Description);
                item.SubItems.Add(repo.CreatedAt);
                item.SubItems.Add(repo.Star.ToString());
                item.SubItems.Add(repo.Watch.ToString());
                item.SubItems.Add(repo.Fork.ToString());
                item.Tag = repo;

                lvRepoList.Items.Add(item);
            }
        }
    }
}
