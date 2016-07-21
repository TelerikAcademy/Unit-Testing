namespace Validators.Exceptions
{
    using System;

    public class InvalidPasswordException : ArgumentException
    {
        public InvalidPasswordException(string message)
            : base(message)
        {
        }
    }
}
