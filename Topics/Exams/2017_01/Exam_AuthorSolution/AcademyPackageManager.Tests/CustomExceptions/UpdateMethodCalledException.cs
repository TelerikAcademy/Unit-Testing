using System;

namespace AcademyPackageManager.Tests.CustomExceptions
{
    public class UpdateMethodCalledException : Exception
    {
        public UpdateMethodCalledException(string msg)
            : base(msg)
        {
        }
    }
}
