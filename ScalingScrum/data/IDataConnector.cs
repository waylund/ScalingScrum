using ScalingScrum.objects;
using System;

namespace ScalingScrum.data
{
    public interface IDataConnector
    {
        AgileFramework getFrameworkById(Guid id);
        System.Collections.ArrayList getAllFrameworks();
    }
}
