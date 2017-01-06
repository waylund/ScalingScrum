using ScalingScrum.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ScalingScrum.objects
{
    public class FrameworkManager
    {
        private IDataConnector dataConnect = null;

        public FrameworkManager()
        {
            this.dataConnect = new MySQLDataConnector();
        }

        public FrameworkManager(IDataConnector dc)
        {
            this.dataConnect = dc;
        }

        public AgileFramework getFrameworkById(Guid id)
        {
            AgileFramework framework = dataConnect.getFrameworkById(id);
            return framework;
        }

        public ArrayList getAllFrameworks()
        {
            ArrayList frameworks = dataConnect.getAllFrameworks();
            return frameworks;
        }

        public ArrayList searchFrameworks(string input)
        {
            ArrayList frameworks = searchFrameworkNames(input);

            foreach (AgileFramework a in searchFrameworkLinks(input))
            {
                bool present = false;
                foreach (AgileFramework f in frameworks)
                {
                    if (a.name.Equals(f.name) && a.link.Equals(f.link) && a.description.Equals(f.description))
                    {
                        present = true;
                    } 
                }
                if (!present)
                    frameworks.Add(a);
            }
            foreach (AgileFramework a in searchFrameworkDescriptions(input))
            {
                bool present = false;
                foreach (AgileFramework f in frameworks)
                {
                    if (a.name.Equals(f.name) && a.link.Equals(f.link) && a.description.Equals(f.description))
                    {
                        present = true;
                    }
                }
                if (!present)
                    frameworks.Add(a);
            }
            return frameworks;
        }

        private ArrayList searchFrameworkNames(string input)
        {
            ArrayList frameworks = dataConnect.getAllFrameworks();
            ArrayList results = new ArrayList();

            foreach (AgileFramework a in frameworks)
            {
                if (a.name.ToLower().Contains(input.ToLower()))
                    results.Add(a);
            }

            return results;
        }

        private ArrayList searchFrameworkLinks(string input)
        {
            ArrayList frameworks = dataConnect.getAllFrameworks();
            ArrayList results = new ArrayList();

            foreach (AgileFramework a in frameworks)
            {
                if (a.link.ToLower().Contains(input.ToLower()))
                    results.Add(a);
            }

            return results;
        }

        private ArrayList searchFrameworkDescriptions(string input)
        {
            ArrayList frameworks = dataConnect.getAllFrameworks();
            ArrayList results = new ArrayList();

            foreach (AgileFramework a in frameworks)
            {
                if (a.description.ToLower().Contains(input.ToLower()))
                    results.Add(a);
            }

            return results;
        }
    }
}