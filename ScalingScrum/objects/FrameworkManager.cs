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
    }
}