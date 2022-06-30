using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class SomeException : ApplicationException
    {
        public SomeException(String message) : base(message) 
        {
            Console.WriteLine(message);
        }
        public override string ToString()
        {
            return Message;
        }
    }
    class CarException : ApplicationException
    {
        public CarException(String message) : base(message)
        {
        }
    }
    class SpeedException : CarException
    {
        public SpeedException(String message) : base(message) 
        {
        }
    }
    class TooHighSpeedValueException : SpeedException
    {
        public TooHighSpeedValueException(String message) : base(message)
        {
        }
    }
    class NegativeSpeedValueException : SpeedException
    {
        public NegativeSpeedValueException(String message) : base(message)
        {
        }
    }
    class FuelException : CarException
    {
        public FuelException(String message) : base(message)
        {
        }
    }
}
