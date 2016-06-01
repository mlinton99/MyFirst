using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubMaster.Models
{
    public class GitHubViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string Username { get; set; }
        public string Location { get; set; }
        public string Avatar { get; set; }
        public string Repositories { get; set; }

        public List<RepositeryViewModel> RepositoryList { get; set; }
    }

    public class RepositeryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Url { get; set; }
        public string GitUrl { get; set; }
        public int StargazersCount { get; set; }
        public string Description { get; set; }
        public string DefalutBranch { get; set; }
        public string CreatedAt { get; set; }
        public string Owner { get; set; }

    }
}
