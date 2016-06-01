using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GithubMaster.Controllers;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GithubMaster.Tests.Controllers
{
    [TestClass]
    public class DashboardControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            DashboardController controller = new DashboardController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task GetResult_Should_Return_List_Of_Repositiers()
        {
            string UserName = "natemcmaster";

            // Arrange
            DashboardController controller = new DashboardController();

            // Act
            ViewResult result = await controller.GetResult(UserName) as ViewResult;


            Assert.IsNotNull(result);
        }
    }
}
