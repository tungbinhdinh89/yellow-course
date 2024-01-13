using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderInfoRepoGitHubToListView.Models
{
    public struct Repo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int Star { get; set; }
        public int Watch { get; set; }
        public int Fork { get; set; }
    }
}
