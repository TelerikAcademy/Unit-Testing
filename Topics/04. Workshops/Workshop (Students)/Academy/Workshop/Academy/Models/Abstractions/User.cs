using System;

namespace Academy.Models.Abstractions
{
    public abstract class User : IUser
    {
        private string username;

        protected User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) 
                    || value.Length < 3 
                    || value.Length > 16)
                {
                    throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                }

                this.username = value;
            }
        }
    }
}
