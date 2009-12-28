﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.Service.Base;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Fake;

namespace ContentNamespace.Web.Tests.Services
{
    [TestClass]
    public class ContentServiceTest
    {

        [TestMethod]
        public void ContentService_Get_IsNotNull()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            IQueryable<HtmlContent> contents = cs.Get();
            Assert.IsNotNull(contents);
        }
        [TestMethod]
        public void ContentService_Get_ReturnsMoreThanZero()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            IQueryable<HtmlContent> contents = cs.Get();
            Assert.IsTrue(contents.Count() > 0);
        }
        [TestMethod]
        public void ContentService_GetById_HasCorrectData()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            HtmlContent content = cs.Get(1);
            Assert.IsTrue( content.ContentData.StartsWith( "<h1>Hello 1 </h1>"));
        }

        [TestMethod]
        public void ContentService_SaveNewContent_ReturnsContent()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            HtmlContent content = new HtmlContent();
            content.ContentData = "a";
            HtmlContent content2 = cs.Save(content);
            Assert.AreEqual("a", content2.ContentData);
        }

    }
}
