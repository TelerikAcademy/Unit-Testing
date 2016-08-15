using System;
using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    public class ResourcesFactory : IResourcesFactory
    {
        private const int FirstLetterIndex = 0;
        private const int ResourceAmountIndex = 1;
        private const int ResourcesParametersStartIndex = 2;
        private const char BronzeKey = 'b';
        private const char SilverKey = 's';
        private const char GoldKey = 'g';
        private const char OpeningBracket = '(';
        private const char ClosingBracket = ')';

        private readonly IDictionary<char, uint> resourcesParameters;

        public ResourcesFactory()
        {
            this.resourcesParameters = new Dictionary<char, uint>();
        }

        public IResources GetResources(string command)
        {
            try
            {
                this.BuildResourcesParametersDictionary(command);

                return new Resources(
                   this.resourcesParameters[BronzeKey],
                   this.resourcesParameters[SilverKey],
                   this.resourcesParameters[GoldKey]);
            }
            catch (Exception exc)
            {
                if (exc.GetType() == typeof(OverflowException))
                {
                    throw new OverflowException();
                }

                throw new InvalidOperationException("Invalid command");
            }
        }

        private void BuildResourcesParametersDictionary(string command)
        {
            var commandParams = command.Split(' ');

            for (int i = ResourcesParametersStartIndex; i < commandParams.Length; i++)
            {
                var resourceType = commandParams[i];
                var key = resourceType[FirstLetterIndex];
                var paramz = resourceType.Split(
                    new char[] { OpeningBracket, ClosingBracket },
                    StringSplitOptions.RemoveEmptyEntries);

                var value = uint.Parse(paramz[ResourceAmountIndex]);

                this.resourcesParameters[key] = value;
            }
        }
    }
}
