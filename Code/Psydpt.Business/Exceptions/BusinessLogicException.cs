using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Business.Exceptions
{
    public class BusinessLogicException :ServiceBaseException
    {
                
        public BusinessLogicException()
            :base()
        { }

        public BusinessLogicException(string message)
            :base(message)
        {  }

        public BusinessLogicException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
