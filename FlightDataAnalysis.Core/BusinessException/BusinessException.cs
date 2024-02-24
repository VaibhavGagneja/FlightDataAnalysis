using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDataAnalysis.Core.BusinessException
{
    public abstract class BusinessException(string message) : Exception(message);
}
