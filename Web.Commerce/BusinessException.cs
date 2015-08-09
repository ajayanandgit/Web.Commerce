using System;

namespace Web.Commerce.Entity
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage)
            : base(errorMessage)
        {
        }

        public BusinessException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }
}