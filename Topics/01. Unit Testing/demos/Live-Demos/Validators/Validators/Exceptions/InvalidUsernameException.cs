namespace Validators.Exceptions
{
    using System;

    public class InvalidUsernameException : ArgumentException
    {
        public InvalidUsernameException(string message) 
            : base(message)
        {
        }
    }
}
