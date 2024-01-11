namespace GetInfoRepoGithub
{
    public struct Repo
    {
        public string name; // name
        public string url; // html_url
        public string description; // description
        public  string createdAt; // created_at
        public  int star; // stargazers_count
        public int watch; // watchers_count
        public int fork; // forks_count
    }
}
