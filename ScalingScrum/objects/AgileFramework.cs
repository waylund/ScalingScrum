using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScalingScrum.objects
{
    public class AgileFramework
    {
        public enum TeamFramework { SCRUM, KANBAN, XP, CUSTOM, ANY }
        public string name { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public TeamFramework teamFramework { get; set; }
        public string teamFrameworkNote { get; set; }
    }
}