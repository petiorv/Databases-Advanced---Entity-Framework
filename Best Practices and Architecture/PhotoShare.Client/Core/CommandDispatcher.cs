﻿using System.Linq;
using PhotoShare.Client.Core.Commands;
using PhotoShare.Service;

namespace PhotoShare.Client.Core
{
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand(new UserService());
                    result = registerUser.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
            }

            return result;
        }
    }
}
