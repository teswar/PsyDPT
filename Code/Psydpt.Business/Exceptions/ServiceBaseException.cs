using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Business.Exceptions
{
    public class ServiceBaseException: Exception
    {

        public ServiceBaseException()
            :base()
        { }

        public ServiceBaseException(string message)
            :base(message)
        {  }

        public ServiceBaseException(string message,Exception innerException)
            : base(message, innerException)
        { }

    }
}
