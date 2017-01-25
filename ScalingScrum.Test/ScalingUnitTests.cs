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

        #region Get Framework Information Pulled By ID

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
        public void TestGetFrameworkTeamFrameworkCompatability()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("118d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual(AgileFramework.TeamFramework.SCRUM, framework.teamFramework);
            Assert.IsTrue(String.IsNullOrEmpty(framework.teamFrameworkNote));
        }

        [TestMethod]
        public void TestGetFrameworkTeamFrameworkCompatability_Custom()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            AgileFramework framework = manager.getFrameworkById(new Guid("318d3186-7193-47cb-9897-fea51b81c030"));
            Assert.AreEqual(AgileFramework.TeamFramework.CUSTOM, framework.teamFramework);
            Assert.AreEqual("Scrum // Kanban // specific XP practices mandated", framework.teamFrameworkNote);
        }

        #endregion

        [TestMethod]
        public void TestGetAllFrameworks()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.getAllFrameworks();
            Assert.AreEqual(3, frameworkSet.Count);
        }

        #region Framework Search Tests

        [TestMethod]
        public void TestSearchFrameworks()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("Scrum");
            Assert.AreEqual(2, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks2()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("Large Scale Scrum");
            Assert.AreEqual(1, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks3()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("AgiLeallIanCe");
            Assert.AreEqual(1, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks4()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("vodde");
            Assert.AreEqual(1, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks5()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("name:scrum");
            Assert.AreEqual(2, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks6()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("name:scrum;vodde");
            Assert.AreEqual(1, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks7()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks("team:Scrum");
            Assert.AreEqual(2, frameworkSet.Count);
        }

        [TestMethod]
        public void TestSearchFrameworks8()
        {
            FrameworkManager manager = new FrameworkManager(dc);
            System.Collections.ArrayList frameworkSet = manager.searchFrameworks(";name:scrum;vodde");
            Assert.AreEqual(1, frameworkSet.Count);
        }

        #endregion
    }
}
