using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET_student_project;
using NET_student_project.Controllers;
using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
using NET_student_project.ViewModels;

namespace NET_student_project.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void AllHotMemesPointAbove400()
        {
            // Arrange
            var fakeDb = new FakeGagDbContext();
          
            HomeController controller = new HomeController(fakeDb, new CategoriesRepository(fakeDb), new MemeRepository(fakeDb));

            // Act
            ViewResult result = controller.Hot("Hot") as ViewResult;

            var MemeList = (MemesViewModel)result.ViewData.Model;

            // Assert
            bool a = true;
            foreach(var meme in MemeList.Memes)
            {
                if( meme.Points < 400)
                {
                    a = false;
                    break;
                }
            }
            Assert.IsTrue(a);
        }

        [TestMethod]
        public void AllTrendigMemesPointBetween100_400()
        {
            // Arrange
            var fakeDb = new FakeGagDbContext();

            HomeController controller = new HomeController(fakeDb, new CategoriesRepository(fakeDb), new MemeRepository(fakeDb));

            // Act
            ViewResult result = controller.Hot("Trending") as ViewResult;

            var MemeList = (MemesViewModel)result.ViewData.Model;

            // Assert
            bool a = true;
            foreach (var meme in MemeList.Memes)
            {
                if (!(meme.Points <= 400 && meme.Points > 100))
                {
                    a = false;
                    break;
                }
            }
            Assert.IsTrue(a);
        }
        [TestMethod]
        public void AllFreshMemesPointUnder100()
        {
            // Arrange
            var fakeDb = new FakeGagDbContext();

            HomeController controller = new HomeController(fakeDb, new CategoriesRepository(fakeDb), new MemeRepository(fakeDb));

            // Act
            ViewResult result = controller.Hot("Fresh") as ViewResult;

            var MemeList = (MemesViewModel)result.ViewData.Model;

            // Assert
            bool a = true;
            foreach (var meme in MemeList.Memes)
            {
                if (meme.Points > 100)
                {
                    a = false;
                    break;
                }
            }
            Assert.IsTrue(a);
        }
    }
}
