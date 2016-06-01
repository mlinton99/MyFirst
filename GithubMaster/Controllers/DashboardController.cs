using GithubMaster.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GithubMaster.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> GetResult(string userName)
        {

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                var github = new GitHubClient(new ProductHeaderValue("GitHubApiApp"));

                var user = await github.User.Get(userName);

                GitHubViewModel model = new GitHubViewModel();
                model.Username = user.Login;
                model.Location = user.Location;
                model.Avatar = user.AvatarUrl;

                //model.RepositoryList = new List<RepositeryViewModel>();
                List<RepositeryViewModel> tempList = new List<RepositeryViewModel>();
                // used to  get reositery for user 
                var reposForUser = await github.Repository.GetAllForUser(userName);
                foreach (var repo in reposForUser)
                {
                    tempList.Add(FromEntity(repo));
                }


                model.RepositoryList = tempList.OrderByDescending(q => q.StargazersCount).Take(5).ToList();

                return View("~/Views/Dashboard/Getresult.cshtml", model);
            }

           
        }

        #region Utility methods
        private static RepositeryViewModel FromEntity(Repository repo)
        {
            return new RepositeryViewModel
            {
                Id = repo.Id,
                Name = repo.Name,
                FullName = repo.FullName,
                Url = repo.Url,
                GitUrl = repo.GitUrl,
                StargazersCount = repo.StargazersCount,
                Description = repo.Description,
                DefalutBranch = repo.DefaultBranch,
                CreatedAt = Convert.ToString(repo.CreatedAt),
                Owner = string.Format("{0}-{1}", repo.Owner.Id, repo.Owner.Login)
            };
        }

        #endregion
    }
}