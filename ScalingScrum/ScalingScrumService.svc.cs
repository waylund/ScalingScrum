﻿using ScalingScrum.data;
using ScalingScrum.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ScalingScrum
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ScalingScrumService : IScalingScrumService
    {
        public AgileFramework[] getFrameworks()
        {
            FrameworkManager manager = new FrameworkManager(new TestDataConnector());
            return (AgileFramework[]) manager.getAllFrameworks().ToArray(typeof(AgileFramework));
        }

        public AgileFramework[] searchFrameworks(string searchString)
        {
            FrameworkManager manager = new FrameworkManager(new TestDataConnector());
            return (AgileFramework[])manager.searchFrameworks(searchString).ToArray(typeof(AgileFramework));
        }

        public bool testConnection()
        {
            return true;
        }

        public string GetData(string id)
        {
            return "The ID you entered was: " + id;
        }

        public BSClass getABSClass(string id)
        {
            BSClass bs = new BSClass();
            bs.id = int.Parse(id);
            return bs;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
