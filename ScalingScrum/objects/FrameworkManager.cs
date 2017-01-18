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
            ArrayList workingFrameworkList = getAllFrameworks();
            return searchFrameworks(input, workingFrameworkList);
        }
        private ArrayList searchFrameworks(string input, ArrayList workingFrameworkList)
        {
            ArrayList frameworks = new ArrayList();
            char[] splitDelimiters = { ';' };
            string[] stringList = input.Split(splitDelimiters);

            if (stringList.Length > 0)
            {
                foreach (string str in stringList)
                {
                    if (str.Contains(":"))
                    {
                        switch (str.Split(':')[0].ToLower())
                        {
                            case "name":
                                workingFrameworkList = searchFrameworkNames(str.Split(':')[1], workingFrameworkList);
                                break;
                            case "link":
                                workingFrameworkList = searchFrameworkLinks(str.Split(':')[1], workingFrameworkList);
                                break;
                            case "description":
                                workingFrameworkList = searchFrameworkDescriptions(str.Split(':')[1], workingFrameworkList);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        workingFrameworkList = searchAllFrameworks(str, workingFrameworkList);
                    }
                }
                return workingFrameworkList;
            }
            else
            {
                return getAllFrameworks();
            }
        }
        private ArrayList searchAllFrameworks(string input, ArrayList frameworks)
        {
            ArrayList results = new ArrayList();
                foreach (AgileFramework a in searchFrameworkNames(input, frameworks))
                {
                    bool present = false;
                    foreach (AgileFramework f in results)
                    {
                        if (a.name.Equals(f.name) && a.link.Equals(f.link) && a.description.Equals(f.description))
                        {
                            present = true;
                        }
                    }
                    if (!present)
                        results.Add(a);
                }

                foreach (AgileFramework a in searchFrameworkLinks(input, frameworks))
                {
                    bool present = false;
                    foreach (AgileFramework f in results)
                    {
                        if (a.name.Equals(f.name) && a.link.Equals(f.link) && a.description.Equals(f.description))
                        {
                            present = true;
                        }
                    }
                    if (!present)
                        results.Add(a);
                }

                foreach (AgileFramework a in searchFrameworkDescriptions(input, frameworks))
                {
                    bool present = false;
                    foreach (AgileFramework f in results)
                    {
                        if (a.name.Equals(f.name) && a.link.Equals(f.link) && a.description.Equals(f.description))
                        {
                            present = true;
                        }
                    }
                    if (!present)
                        results.Add(a);
                }
                return results;
            }
        

        private ArrayList searchFrameworkNames(string input)
        {
            ArrayList frameworks = dataConnect.getAllFrameworks();
            return searchFrameworkNames(input, frameworks);
        }
        private ArrayList searchFrameworkNames(string input, ArrayList frameworks)
        { 
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
            return searchFrameworkLinks(input, frameworks);
        }
        private ArrayList searchFrameworkLinks(string input, ArrayList frameworks)
        {
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
            return searchFrameworkDescriptions(input, frameworks);
        }
        private ArrayList searchFrameworkDescriptions(string input, ArrayList frameworks)
        {
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