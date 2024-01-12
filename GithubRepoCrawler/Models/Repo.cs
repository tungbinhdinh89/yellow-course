using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubRepoCrawler.Models
{
    public class Repo
    {
        public string FullName { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public int Star { get; set; }
        public int Watch { get; set; }
        public int Fork { get; set; }

    }
}
