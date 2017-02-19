using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Academy.Core.Providers
{
    public class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            // Takes the command name from the string
            var commandName = fullCommand.Split(' ')[0];

            // Tries to find a class that matches that command
            var commandTypeInfo = this.FindCommand(commandName);

            // Creates an instance of that classes and passes to the constructor:
            //   The singleton instance of the AcademyFactory class
            //   The singleton instance of the Engine class
            // Then it casts the whole thing from object to ICommand
            var command = Activator.CreateInstance(commandTypeInfo, AcademyFactory.Instance, Engine.Instance) as ICommand;

            return command;
        }
        
        public IList<string> ParseParameters(string fullCommand)
        {
            // Takes the parameters from the string
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            // If there are no params, return an empty list
            // This violates part of the Command-Querry Seperation principle
            // Made this way to keep things simple
            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
        
        private TypeInfo FindCommand(string commandName)
        {
            // Gets the current assembly (visual studio project)
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;

            // Gets a list of all the defined classes in the current assembly
            //   Then filters only the classes that implement the interface ICommand
            //   Then filters only the classes that contain the passed command name within it's name with the suffix command
            //   Then takes the class that it has found or takes null
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
                .SingleOrDefault();

            // If it has not found the class, an exception is thrown
            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
