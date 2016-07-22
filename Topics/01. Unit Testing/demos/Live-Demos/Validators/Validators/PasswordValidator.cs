namespace Validators
{
    using System;
    using System.Linq;

    using Exceptions;
    using Helpers;

    public class PasswordValidator
    {
        public bool IsPasswordValid(
            string password,
            int minRequiredPasswordLength,
            int maxRequiredPasswordLength,
            int minRequiredDigitsCount,
            int minRequiredLowercaseLettersCount,
            int minRequiredUppercaseLettersCount,
            int minRequiredSpecialCharactersCount)
        {
            if (!this.IsPasswordLengthValid(password, minRequiredPasswordLength, maxRequiredPasswordLength))
            {
                throw new InvalidPasswordException($"Password length must be between {minRequiredPasswordLength} and {maxRequiredPasswordLength} characters long, inclusive");
            }

            if (!this.PasswordHasDigits(password, minRequiredDigitsCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredDigitsCount} digits");
            }

            if (!this.PasswordHasLowercaseLetters(password, minRequiredLowercaseLettersCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredLowercaseLettersCount} lowercase letters");
            }

            if (!this.PasswordHasUppercaseLetters(password, minRequiredUppercaseLettersCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredUppercaseLettersCount} uppercase letters");
            }

            if (!this.PasswordHasSpecialCharacters(password, minRequiredSpecialCharactersCount))
            {
                throw new InvalidPasswordException($"Password must have at least {minRequiredSpecialCharactersCount} special characters");
            }

            return true;
        }

        public bool IsPasswordLengthValid(string password, int minRequiredPasswordLength, int maxRequiredPasswordLength)
        {
            return password.Length >= minRequiredPasswordLength && 
                password.Length <= maxRequiredPasswordLength;
        }

        public bool PasswordHasUppercaseLetters(string password, int minRequiredNumberOfUppercaseLetters)
        {
            return password.Where(x => Char.IsLetter(x) && Char.IsUpper(x))
                .Count() >= minRequiredNumberOfUppercaseLetters;
        }

        public bool PasswordHasLowercaseLetters(string password, int minRequiredNumberOfKLowercaseLetters)
        {
            return password.Where(x => Char.IsLetter(x) && Char.IsLower(x))
                .Count() >= minRequiredNumberOfKLowercaseLetters;
        }

        public bool PasswordHasDigits(string password, int minRequiredNumberOfDigits)
        {
            return password.Where(x => Char.IsDigit(x))
                .Count() >= minRequiredNumberOfDigits;
        }

        public bool PasswordHasSpecialCharacters(string password, int minRequiredNumberOfSpecialCharacters)
        {
            return password.Where(x => CharHelper.IsSpecialCharacter(x))
                .Count() >= minRequiredNumberOfSpecialCharacters;
        }
    }
}
