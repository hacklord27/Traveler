using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTraveler
{
    class TestInputData
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string ExpectedMessage { get; set; }

        public TestInputData(string userName, string phoneNumber, string email, string password, string rePassword, string expectedMessage)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            RePassword = rePassword;
            ExpectedMessage = expectedMessage;
        }
    }
}
