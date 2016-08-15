using System;
using System.Linq;
using System.Reflection;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel
{
    public class UnitsFactory
    {
        private const int UnitTypeIndex = 2;
        private const int UnitNameIndex = 3;
        private const int UnitIdIndex = 4;

        public IUnit GetUnit(string command)
        {
            try
            {
                var commandParams = command.Split(' ');
                var unitType = commandParams[UnitTypeIndex];
                var unitName = commandParams[UnitNameIndex];
                var unitId = commandParams[UnitIdIndex];

                var typeToInstantiate = Assembly.Load("IntergalacticTravel").GetTypes().FirstOrDefault(x => x.Name == unitType);
                return (IUnit)Activator.CreateInstance(typeToInstantiate, int.Parse(unitId), unitName);
            }
            catch (Exception)
            {
                throw new InvalidUnitCreationCommandException(); 
            }
           
        }
    }
}
