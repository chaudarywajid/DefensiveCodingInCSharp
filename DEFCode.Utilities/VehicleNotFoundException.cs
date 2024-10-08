using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFCode.Utilities
{

    [Serializable()]
    public class VehicleNotFoundException : System.Exception
    {

        public VehicleNotFoundException() : base() { }

        public VehicleNotFoundException(string message) : base(message) { }

        public VehicleNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected VehicleNotFoundException(System.Runtime.Serialization.SerializationInfo info,
                                            System.Runtime.Serialization.StreamingContext context)
                                                                                                : base(info, context) { }

    }

    [Serializable()]
    public class BusinessRuleException : System.Exception
    {

        public BusinessRuleException() : base() { }

        public BusinessRuleException(string message) : base(message) { }

        public BusinessRuleException(string message, Exception inner) : base(message, inner) { }

        protected BusinessRuleException(System.Runtime.Serialization.SerializationInfo info,
                                            System.Runtime.Serialization.StreamingContext context)
                                                                                                : base(info, context) { }

    }
}
