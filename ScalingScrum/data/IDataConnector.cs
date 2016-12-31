using ScalingScrum.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalingScrum.data
{
    public interface IDataConnector
    {
        AgileFramework getFrameworkById(Guid id);
    }
}
