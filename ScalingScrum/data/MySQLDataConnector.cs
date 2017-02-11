using ScalingScrum.objects;
using System;
using System.Collections;
using System.Xml;

namespace ScalingScrum.data
{

    public class MySQLDataConnector : IDataConnector
    {
        private string server = String.Empty;
        private string uname = String.Empty;
        private string passwd = String.Empty;

        private void pullServerInfo()
        {
            // Read XML File
            XmlDocument doc = new XmlDocument();
            doc.Load("../../dataconnector.config");
            XmlNode node = doc.SelectSingleNode("/dataconfigs/dataconfig");
            foreach (XmlNode cNode in node.ChildNodes)
            {
                switch(cNode.Name)
                {
                    case "target":
                        this.server = cNode.InnerText;
                        break;
                    case "username":
                        this.uname = cNode.InnerText;
                        break;
                    case "password":
                        this.passwd = cNode.InnerText;
                        break;
                }
            }
            // Is Encrypted?
            // If Not, Encrypt
            // Save connection stuff to variables
        }

        public MySQLDataConnector()
        {
            pullServerInfo();
        }

        public bool testConnection()
        {
            return false;
        }

        public AgileFramework getFrameworkById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ArrayList getAllFrameworks()
        {
            throw new NotImplementedException();
        }
    }
}