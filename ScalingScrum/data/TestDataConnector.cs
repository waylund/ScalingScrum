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
            {
                framework.name = "Scrum-of-Scrums";
                framework.link = "http://guide.agilealliance.org/guide/scrumofscrums.html";
                framework.description = "An important mechanism that may be enough for smaller organizations but is not a full scaling approach.";
                framework.teamFramework = AgileFramework.TeamFramework.SCRUM;
            }
            else if (id.ToString().Equals("218d3186-7193-47cb-9897-fea51b81c030"))
            {
                framework.name = "Large Scale Scrum";
                framework.link = "http://less.works/";
                framework.description = "Larman / Vodde model as documented in \"Scaling Lean & Agile Development\"";
                framework.teamFramework = AgileFramework.TeamFramework.SCRUM;
            } else if (id.ToString().Equals("318d3186-7193-47cb-9897-fea51b81c030"))
            {
                framework.name = "SAFe";
                framework.link = "http://scaledagileframework.com/";
                framework.description = "The method documented by Dean Leffingwell and  Scaled Agile, Inc.";
                framework.teamFramework = AgileFramework.TeamFramework.CUSTOM;
                framework.teamFrameworkNote = "Scrum // Kanban // specific XP practices mandated";
            }
            return framework;
        }

        public ArrayList getAllFrameworks()
        {
            ArrayList frameworks = new ArrayList();
            frameworks.Add(getFrameworkById(new Guid("118d3186-7193-47cb-9897-fea51b81c030")));
            frameworks.Add(getFrameworkById(new Guid("218d3186-7193-47cb-9897-fea51b81c030")));
            frameworks.Add(getFrameworkById(new Guid("318d3186-7193-47cb-9897-fea51b81c030")));
            return frameworks;
        }
    }
}