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

            if (!string.IsNullOrWhiteSpace(search) && comboBox1.SelectedItem != null)
            {
                if (int.TryParse(comboBox1.SelectedItem.ToString(), out var selectedValue))
                {

                    var take = selectedValue;


                    var repos = await crawlerRepoService.SearchRepoGitHub(search, take);
                    if(repos is null || repos.Count == 0)
                    {
                        MessageBox.Show("Repository not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //if(take > repos.Count)
                        //{
                        //    MessageBox.Show("Repository count is less than the your choose value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        //else
                        //{
                            
                        //}
                        RenderToListView(repos);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid integer value from the ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please provide a valid search term and select a value from the ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
