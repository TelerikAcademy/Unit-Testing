using Academy.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstractions.Mocks
{
    internal class UserMock : User
    {
        public UserMock(string username) : base(username)
        {
        }
    }
}
