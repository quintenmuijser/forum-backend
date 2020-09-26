using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_backend_semester3;
using forum_backend_semester3.Controllers;

namespace forum_backend_semester3.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
