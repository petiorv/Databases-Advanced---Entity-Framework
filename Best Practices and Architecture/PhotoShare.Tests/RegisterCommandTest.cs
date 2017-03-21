using PhotoShare.Tests.Mocks;

namespace PhotoShare.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core.Commands;

    [TestClass]
    public class RegisterCommandTest
    {
        [TestMethod]
        public void Register_NewUser_Should_SuccessMessage()
        {
            //Arrange, Act, Assert
            string[] commandParameters = new[]
            {
                "username",
                "passw0rd",
                "passw0rd",
                "user@u.com"
            };
            RegisterUserCommand registerUser = new RegisterUserCommand(new UserServiceMock());
            string result = registerUser.Execute(commandParameters);

            Assert.AreEqual($"User {commandParameters[0]} was registered successfully!", result);
        }
    }
}
