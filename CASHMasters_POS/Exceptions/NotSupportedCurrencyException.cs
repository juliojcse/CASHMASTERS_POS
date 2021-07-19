using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasters.POS.Exceptions
{    
    /// <summary>
    /// Custom exception by inheriting Exception class.
    /// </summary>
    [Serializable]
    public class NotSupportedCurrencyException : ArgumentException
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "The currency entered is not supported.";
            }
        }
        
        public NotSupportedCurrencyException() : base() { }
        public NotSupportedCurrencyException(string message) : base(message) { }
        public NotSupportedCurrencyException(string message, Exception inner) : base(message, inner) { }
        protected NotSupportedCurrencyException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
