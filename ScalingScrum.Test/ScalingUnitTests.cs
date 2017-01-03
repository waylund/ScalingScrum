using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScalingScrum.data;
using ScalingScrum.objects;

namespace ScalingScrum.Test
{
    [TestClass]
    public class ScalingUnitTests
    {

        TestDataConnector dc = new TestDataConnector();

        [TestMethod]
        public void TestGetFrameworkById()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("118d3186-7193-47cb-9897-fea51b81c030"));
            Assert.IsNotNull(framework);
        }

        [TestMethod]
        public void TestGetFrameworkName()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("118d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual("Scrum-of-Scrums", framework.name);
        }

        [TestMethod]
        public void TestGetFrameworkName2()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("218d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual("Large Scale Scrum", framework.name);
        }

        [TestMethod]
        public void TestGetFrameworkLink()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("218d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual("http://less.works/", framework.link);
        }

        [TestMethod]
        public void TestGetFrameworkDescription()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("218d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual("Larman", framework.description.Substring(0,6));
        }

        [TestMethod]
        public void TestGetAllFrameworks()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.getAllFrameworks();
            Assert.AreEqual(2, frameworkSet.Count);
        }
    }
}
