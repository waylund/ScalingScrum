using ScalingScrum.objects;
using System;
using System.Collections;

namespace ScalingScrum.data
{
    public class TestDataConnector : IDataConnector
    {
        public AgileFramework getFrameworkById(Guid id)
        {
            AgileFramework framework = new AgileFramework();
            if (id.ToString().Equals("118d3186-7193-47cb-9897-fea51b81c030"))
                framework.name = "Scrum-of-Scrums";
            else if (id.ToString().Equals("218d3186-7193-47cb-9897-fea51b81c030"))
            {
                framework.name = "Large Scale Scrum";
                framework.link = "http://less.works/";
            }
            return framework;
        }

        public ArrayList getAllFrameworks()
        {
            ArrayList frameworks = new ArrayList();
            frameworks.Add(getFrameworkById(new Guid("118d3186-7193-47cb-9897-fea51b81c030")));
            frameworks.Add(getFrameworkById(new Guid("218d3186-7193-47cb-9897-fea51b81c030")));
            return frameworks;
        }
    }
}