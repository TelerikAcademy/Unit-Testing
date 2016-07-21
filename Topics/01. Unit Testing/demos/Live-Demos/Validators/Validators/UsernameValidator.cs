namespace Validators
{
    using System.Linq;

    using Exceptions;
    using Helpers;

    public class UsernameValidator
    {
        public bool IsUsernameValid(string username, int minRequiredUsernameLength, int maxRequiredUsernameLength)
        {
            if (!this.IsUsernameLengthValid(username, minRequiredUsernameLength, maxRequiredUsernameLength))
            {
                throw new InvalidUsernameException($"Username must have a length between {minRequiredUsernameLength} and {maxRequiredUsernameLength} characters");
            }

            if (this.HasWhitespaceCharacters(username))
            {
                throw new InvalidUsernameException("Username cannot contain whitespace characters");
            }

            if (this.HasSpecialCharacters(username))
            {
                throw new InvalidUsernameException("Username cannot contain special characters");
            }

            return true;
        }

        public bool IsUsernameLengthValid(string username, int minRequiredUsernameLength, int maxRequiredUsernameLength)
        {
            return username.Length >= minRequiredUsernameLength &&
                username.Length <= maxRequiredUsernameLength;
        }

        public bool HasWhitespaceCharacters(string username)
        {
            return username.Any(x => char.IsWhiteSpace(x));
        }

        public bool HasSpecialCharacters(string username)
        {
            return username.Any(x => CharHelper.IsSpecialCharacter(x));
        }
    }
}
