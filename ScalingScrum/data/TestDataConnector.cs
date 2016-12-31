using ScalingScrum.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScalingScrum.data
{
    public class TestDataConnector : IDataConnector
    {
        public AgileFramework getFrameworkById(Guid id)
        {
            AgileFramework framework = new AgileFramework();
            if (id.ToString().Equals("118d3186-7193-47cb-9897-fea51b81c030"))
                framework.name = "Scrum-of-Scrums";
            return framework;
        }
    }
}