namespace Validators.Helpers
{
    public static class CharHelper
    {
        public static bool IsSpecialCharacter(char c)
        {
            string specialCharacters = "!@#$%^&*()_+=";

            for (int i = 0; i < specialCharacters.Length; i++)
            {
                if(specialCharacters[i]==c)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
