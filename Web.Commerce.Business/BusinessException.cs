using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Commerce.Business
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage)
            : base (errorMessage)
        {
        }

        public BusinessException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }
}
