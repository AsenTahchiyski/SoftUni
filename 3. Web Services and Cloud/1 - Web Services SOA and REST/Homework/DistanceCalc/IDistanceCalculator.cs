using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalc
{
    [ServiceContract]
    public interface IDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(int x1, int y1, int x2, int y2);
    }
}
