﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ContentNamespace.Web.Code.DataAccess.Fake;
using ContentNamespace.Web.Code.Service.ConfigurationServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web;
using ContentNamespace.Web.Controllers;

namespace ContentNamespace.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new ConfigurationService(new FakeConfigurationRepository()));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(new ConfigurationService(new FakeConfigurationRepository()));

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
