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
    public class NotEnoughMoneyException : ArgumentException
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "The money given is less than the item price.";
            }
        }  
        
        public NotEnoughMoneyException() : base() { }
        public NotEnoughMoneyException(string message) : base(message) { }
        public NotEnoughMoneyException(string message, Exception inner) : base(message, inner) { }
        protected NotEnoughMoneyException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
