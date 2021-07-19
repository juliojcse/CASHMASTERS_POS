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
    public class ParsingDenominationException : FormatException
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "There was an error parsing the denominations for the currency.";
            }
        } 
        
        public ParsingDenominationException() : base() { }
        public ParsingDenominationException(string message) : base(message) { }
        public ParsingDenominationException(string message, Exception inner) : base(message, inner) { }
        protected ParsingDenominationException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
