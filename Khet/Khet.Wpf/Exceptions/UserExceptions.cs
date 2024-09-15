using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Exceptions
{
    // Base custom exception
    public class UserExceptions : Exception
    {
        // Constructor with error message
        public UserExceptions(string errorMessage)
            : base(errorMessage) // Call the base Exception constructor with the message
        {
        }

        // Constructor with error message and inner exception
        public UserExceptions(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }

    // Derived custom exception for piece rotation errors
    public class PieceRotationException : UserExceptions
    {
        public PieceRotationException(string errorMessage)
            : base(errorMessage) // Call base constructor to pass the message
        {
        }

        public PieceRotationException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException) // Allow chaining exceptions
        {
        }
    }

    public class PieceMoveException : UserExceptions
    {
        public PieceMoveException(string errorMessage)
            : base(errorMessage) // Call base constructor to pass the message
        {
        }

        public PieceMoveException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException) // Allow chaining exceptions
        {
        }
    }

}

